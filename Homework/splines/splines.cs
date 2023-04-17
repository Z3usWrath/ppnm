using System;
using static System.Math;
using static System.Console;

public static class splines{
	
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
        	int i=binsearch(x,z);
       		double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        	double dy=y[i+1]-y[i];
        	return y[i]+dy/dx*(z-x[i]);
        }

	public static double calc_p(double [] x, double[] y, int Max){
		//get p from notes
		return (y[Max + 1] - y[Max])/(x[Max + 1] - x[Max]);
	}

	public static double linterpInteg(double[] x, double[] y, double z){

		//We integrate a linear function so   intgerate(a*x+b) => a/2*x^2+b*x
		//I chose c = 0 because it is a definite integral
		double Integral_sum = 0;
		// Upper integraition boundry, it returnes the right side of the section
		int Max = binsearch(x, z);
		for(int i = 0; i < Max; i++) Integral_sum += (y[i] * (x[i+1] - x[i]));
		// Adding the contibuation of the constants
		Integral_sum += y[0] + y[Max];
		// Adding the contribution of the quadrature
		Integral_sum += y[Max] * (z - x[Max]) + calc_p(x, y, Max)/2 * Pow(z-x[Max],2);

		return Integral_sum;
	}






}


