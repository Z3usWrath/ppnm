using System;
using static System.Math;
using static System.Console;

public static class main{


	public static (double, double) HalfTime(matrix S, vector c)
	{
		double T = Log(2)/(-c[0]);
		double error = Log(2)*Sqrt(S[0,0])/Pow((c[0]),2);
		return (T, error);
	}

	public static int Main(string[] args){
		
		//initialize some values
		int samples = 100;
		double start = 0;
		double end = 1;
		int n = 2;
		vector x = new vector(n);
		vector y = new vector(n);
		vector dy = new vector(n);
		// Incoming info
		foreach(var arg in args){

			var words = arg.Split(":");
			if(words[0] == "-samples") samples = int.Parse(words[1]);
			if(words[0] == "-start") start = double.Parse(words[1]);
			if(words[0] == "-end") end = double.Parse(words[1]);
			//Get arrays of data
			if(words[0] == "-x"){
				var xdata = words[1].Split(",");
				x = new vector(xdata.Length);
				for (int i = 0; i < xdata.Length; i++) x[i] = double.Parse(xdata[i]);

			}
			if(words[0] == "-y"){
                                var ydata = words[1].Split(",");
                                y = new vector(ydata.Length);
                                for (int i = 0; i < ydata.Length; i++) y[i] = double.Parse(ydata[i]);
                        }
			if(words[0] == "-dy"){
                                var dydata = words[1].Split(",");
                                dy = new vector(dydata.Length);
                                for (int i = 0; i < dydata.Length; i++) dy[i] = double.Parse(dydata[i]);
                        }
		}
		// fitting to a logarithem func
		var fs = new Func<double,double>[] {z => z, z => 1};
		for (int i = 0; i < y.size; i++) {
			dy[i] = dy[i] / y[i];
			y[i] = Log(y[i]);
		}
		var (c,S) = Fit.lsfit(fs,x,y,dy);
		double dx = (end-start)/samples;
		//setting the upper and lower limitis
		var c_lower = c.copy();
		var c_upper = c.copy();
		for(int i = 0; i < c.size; i++){

		c_lower[i] = c[i] - Sqrt(S[i,i]);
		c_upper[i] = c[i] + Sqrt(S[i,i]);
		}
		//Writing the info
		for (int i = 0;i < samples; i++) {
			double fit_upper = 0;
			double fit = 0;
			double fit_lower = 0;

			for (int j = 0;j<c.size;j++){
				fit_upper += c_upper[j] * fs[j](dx * i);
				fit += c[j] * fs[j](dx * i);
				fit_lower += c_lower[j] * fs[j](dx * i);
			}
			WriteLine($"{dx*i} {Exp(fit)} {Exp(fit_lower)} {Exp(fit_upper)}");
		}
		// calculating the halflife time
		var (halfTime, error) = HalfTime(S,c);
		WriteLine($"The half time is: {halfTime} +- {error} days");
		WriteLine($"Wikipedia model gives the value of: 3.6319(23) days");
		WriteLine("It seems that it dosen't it dosen't coincide with Wiki, I hope that is correct");





		return 0;
	}
}
