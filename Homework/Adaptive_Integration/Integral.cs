using System;
using static System.Math;
using static System.Console;

public static class Integrate{


	public static double integrate
	(Func<double,double> f, double a, double b,
	double δ=0.001, double ε=0.001, double f2=double.NaN, double f3=double.NaN)
	{
		double h = b - a;
		if(double.IsNaN(f2)){ f2 = f(a + 2 * h/6); f3 = f(a + 4 * h/6); } // first call, no points to reuse
		double f1 = f(a + h/6), f4 = f(a+5*h/6);
		double Q = (2 * f1 + f2 + f3 + 2 * f4)/6 * (b - a); // higher order rule
		double q = (  f1 + f2 + f3 + f4)/4 * (b - a); // lower order rule
		double err = Abs(Q - q);
		if (err <= δ + ε * Abs(Q)) return Q;
	
		else{
			return integrate(f,a,(a+b)/2,δ/Sqrt(2),ε,f1,f2) + integrate(f,(a+b)/2,b,δ/Sqrt(2),ε,f3,f4);
		}
	}

	public static double erf(double z){


		double normal = 2/Sqrt(PI);
		double zero = 0;
		double one = 1;
		Func<double, double> f = (x) => normal * Exp(-Pow(x,2));
		Func<double, double> g = (x) => 1 - normal * Exp(-Pow(z+(1-x)/x,2))/x/x;

		if(z < 0) return -erf(-z);

		else if (z > 0 && z < 1) return normal * integrate(f, zero, z);

		else return integrate(g, zero, one);

	}

	public static double Clenshaw_Certis(Func<double,double> f, double a, double b,
		 double acc=0.001, double eps=0.001, double f2=double.NaN, double f3=double.NaN, int count = 0){

		double h = (b - a) / 2;
		//changing the function with the right transformation
		Func<double, double> F = (x) => f((a+b)/2+h*Cos(x))*Sin(x)*h; 
		return integrate(F, 0 ,PI);


	}





}
