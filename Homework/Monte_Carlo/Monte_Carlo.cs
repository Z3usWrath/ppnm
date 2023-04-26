using System;
using static System.Math;
using static System.Console;

public static class MC{

	public static(double,double) plainmc(Func<vector, double> f, vector a, vector b, int N){

		if(b.size != a.size) throw new ArgumentException("How can I integrate with different dimentions?");

		int dim = a.size; double V = 1; for(int i = 0; i < dim; i++) V *= b[i] - a[i];
        	double sum = 0,sum2 = 0;
		var x = new vector(dim);
		var rnd = new Random();
	        for(int i = 0; i < N; i++){
			for(int k = 0; k < dim; k++){
				x[k] = a[k] + rnd.NextDouble() * (b[k] - a[k]);
			}
			double fx = f(x); sum += fx; sum2 += fx * fx;
			

                }
        	double mean = sum / N, sigma = Sqrt(sum2 / N - mean * mean);
        	var result = (mean * V,sigma * V / Sqrt(N));
      	 	return result;
	}

        public static vector halton(int n, vector x, vector a, vector b){
		int[] Base = new int[] {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
                int dim = a.size;
                if(dim > Base.Length) throw new Exception($"halton dim >{Base.Length}");
		for(int i = 0; i < dim; i++) x[i] = a[i] + (b[i] - a[i])* corput(n , Base[i]);
		return x;
        }

        public static double corput(int n, int b){
                
		double q = 0,bk = 1.0 / b;
                while(n > 0){q += (n % b) * bk; n /= b; bk /=b ;}
                return q;
        }

        public static vector next(){
		int[] bs = new int[]
                {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
                int n = 0, s = 0, d = 1;
                n++;
                vector x=new vector(d);
                for(int i=0;i<d;i++) x[i] = corput(n,bs[i+s]);
                return x;
        }

	public static vector Lattice(int dim, double Base = PI){
		var Alpha = new vector(dim);
		for (int i = 0; i < dim; i++) Alpha[i] = Sqrt(Base+i)%1;
		return Alpha;
	}
	public static vector ConstructLattice(int k, vector x, vector a, vector b, vector Alpha){
		
		for (int i = 0; i < x.size; i++) x[i] = a[i] + (b[i] - a[i]) * ((Alpha[i] * k) % 1);
		return x;
	}

	public static (double, double) qrnd(Func<vector, double> f, vector a, vector b, int N){

		if(b.size != a.size) throw new ArgumentException("How can I integrate with different dimentions?");
		int dim = a.size;
		double Vol = 1;
		for(int i = 0; i < dim; i++) Vol *= (b[i] - a[i]);
		double sum = 0, sum2 = 0;
		var x = new vector (dim);
		var y = new vector (dim);

		var alpha = Lattice(dim);
		for (int i = 0; i < N; i++){
			x = halton(i, x, a, b);
			y = ConstructLattice(i, y, alpha, a, b);
			sum += f(x); sum2 += f(y);
		}

		double mean = sum / N, sigma = Abs(sum - sum2) / N;
		return (mean * Vol,sigma * Vol);		
	}

}
	

