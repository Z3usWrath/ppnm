using System;
using static System.Math;
using static System.Console;

public static class main{

	public static vector Aux(vector E,double rmin,double rmax,double acc = 1e-2, double eps = 1e-2){

		double h = 0.01;
		vector ya = new vector(2);
		ya[0] = (rmin - rmin * rmin);
		ya[1] = (1.0 - 2 * rmin);

		var xs = new genlist<double>();
		var ys = new genlist<vector>();

		Func<double,vector,vector> f = delegate(double x, vector y){
			return new vector(y[1], -2 * E[0] * y[0] -2 * y[0]/x);
		};

		var y_0 = new vector(2);
		var y_err = new vector(2);
		y_0 = y_err;
		(y_0, y_err) = ODE.driver(f,rmin,ya,rmax,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);
		int n = ys.size;
		ys[n - 1][0] += - rmax + rmax * rmax;
		WriteLine($"the first value of ys is {ys[n-1][0]} the second {ys[n-1][1]}");
		return ys[n - 1];	
	}

	public static int Main(string[] args){

		bool partA = false;
		double rmin = 1.0, rmax = 8.0;
		//var xs = new genlist<double>();
		//var ys = new genlist<vector>();
		//vector ya = new vector(2);
		//ya[0] = rmin - rmin * rmin;
		//ya[1] = 1.0 - 2 * rmin;

		//vector E0 = new vector(-1.0);		

		foreach(var arg in args){
			var words = arg.Split(":");
			//if(words[0] == "-a") a = double.Parse(words[1]);
			//if(words[0] == "-b") b = double.Parse(words[1]);
			if(words[0] == "-partA") partA = bool.Parse(words[1]);
		}
		if(partA){

			Func<vector, vector> f = (x) => new vector(new double[] {x[0]*x[0] +2*x[0] +1, x[1]*x[1] + 2*x[1] +1});

			Func<vector, vector> g = (x) => new vector(new double[] {x[0]*x[0]*x[0] +2*x[0] +10, x[1]*x[1] + 2*x[1] +1});
			vector z = new vector(2);
			z = (new double[]{-1.3,-1.2});
			vector root = Roots.newton(f, z);
			vector root_1 = Roots.newton(g, z);

			WriteLine("Seems like my implementation of Newton works!");	
			root.print();
			root_1.print(); 
			// Rosenbrock's valley func 	
			vector y_guess = new vector(new double[]{-1.0,-2.5});
			Func<vector, vector> Rosenbrock = (x) => new vector(new double[] {Pow((1-x[0]),2) + 100 * Pow((x[1] - x[0] * x[0]),2)});
			Func<vector, vector> Rosenbrock_Grad = (x) => new vector(new double[]
					{2 * (1 - x[0]) + 400 * x[0] * (x[1] - x[0] * x[0]), 200 * (x[1] - x[0] * x[0])});
			var Rosenbrock_sol = Roots.newton(Rosenbrock_Grad,y_guess);
			Rosenbrock_sol.print(); 
			WriteLine($"The extremum of Rosenbrock function is {Rosenbrock(Rosenbrock_sol)[0]}");


		}

		else{
			vector E = new vector(1);
			vector answer = Aux(E, rmin, rmax);
			//Func<vector, vector> M
			//vector result = Roots.newton((vector E) => Aux(E, rmin, rmax, acc, eps), new double[] {-1.0});
			//double E0 = result[0];
			//WriteLine($"E0 = {E0}");	

			//WriteLine($"This is the aux func soltion for E = -1 {Aux(E0[0], rmin, rmax, acc ,eps)[0]}");
		}


		return 0;
	}

}
