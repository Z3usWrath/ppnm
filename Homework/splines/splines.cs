using System;
using static System.Console;
using static System.Math;
public static class splines {

	//	for (int i = 0; i<iMax; i++)Out+= ((y[i+1]-y[i])/2+y[i])*(x[i+1]-x[i]);

	public static int binsearch(double[] x, double z){
		/* locates the interval for z by bisection */
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public static double linterp(double[] x, double[] y, double z){
		int i = binsearch(x,z);
		double dx = x[i + 1] - x[i]; if(!(dx > 0)) throw new Exception("In splines.linterp: Array not sorted");
		double dy = y[i + 1] - y[i];
		return y[i] + dy / dx * (z - x[i]);
	}

	public static double p(double [] x, double[] y, int Max){
		//get p from notes
		return (y[Max + 1] - y[Max])/(x[Max + 1] - x[Max]);
	}

	public static double linterpInteg(double[] x, double[] y, double z){

		//We integrate a linear function so we intgerate(a*x+b) => a/2*x^2+b*x
		//I chose c = 0 because it is a definite integral
		double Integral_sum = 0;
		// Upper integraition boundry, it returnes the right side of the section
		int Max = binsearch(x, z);
		for(int i = 0; i < Max; i++) Integral_sum += (y[i] * (x[i+1] - x[i]));
		// Adding the contibuation of the constants
		Integral_sum += (y[Max] - y[0])/2;
		// Adding the contribution of the quadrature
		Integral_sum += y[Max] * (z - x[Max]) + p(x, y, Max)/2 * Pow(z-x[Max],2);

		return Integral_sum;
	}


	public static void qspline(vector x, vector y, vector b, vector c){
		int n = c.size;
		c[0] = 0;
		for(int i = 0; i < n - 1; i++) c[i + 1] = (p(x,y,i + 1) - p(x,y, i) - c[i] * (x[i + 2] - x[i + 1])/(x[i + 1] - x[i]));
		double[] c_down = new double[n];
		c_down[c.size] = 0;
		for(int i = n - 2; i > 0; i--) c_down[i] = (p(x,y,i + 1) - p(x,y, i) - c[i + 1] * (x[i + 2] - x[i - 1])/(x[i + 1] - x[i]));
		for(int i = 0; i < n; i++) c[i] = (c[i] + c_down[i])/2;
	}

	public static double qspline_evaluate(vector x, vector y, vector b, vector c, double z){
		int i = binsearch(x,z);
		return y[i] + b[i] * (z - x[i]) + c[i] * Pow(z - x[i],2);
	}

	public static double qspline_derivative(vector x, vector y, vector b, vector c, double z){
		int i = binsearch(x,z);
		return b[i] + 2 * c[i] * (z-x[i]);
	}


	public static double qspline_integral(vector x, vector y, vector b, vector c, double z){

		int Max = binsearch(x,z);
		double Integral_sum = 0;
		for(int i = 0; i < Max; i++) Integral_sum += (y[i] * (x[i+1] - x[i]) + b[i] / 2 * Pow(x[i+1] - x[i],2) + c[i] / 3 * Pow(x[i+1]-x[i],3));
		return Integral_sum + y[Max] *  (z - x[Max]) + b[Max] * Pow(z - x[Max],2) / 2 + c[Max] * Pow(z - x[Max],3) / 3;
	}







}


