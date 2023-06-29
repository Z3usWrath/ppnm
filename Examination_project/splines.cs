using System;
using static System.Console;
using static System.Math;
public static class splines {

	public static int binsearch(double[] x, double z){
		/* locates the interval for z by bisection */
		if(!(x[0] <= z && z <= x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i = 0, j = x.Length-1;
		while(j - i > 1){
			int mid = (i + j)/2;
			if(z > x[mid]) i = mid; else j = mid;
		}
		return i;
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
		//Integral_sum += y[Max] * (z - x[Max]) + p(x, y, Max)/2 * Pow(z-x[Max],2);

		return Integral_sum;
	}

	public static double Interpolate(double[] x, double[] y, matrix F, double px, double py)
	{
		int n = x.Length;
		int m = y.Length;
		// Find the indices (i, j) corresponding to the given point (px, py)
		int i = binsearch(x, px);
		int j = binsearch(y, py);
		if (i < 0 || i >= n - 1 || j < 0 || j >= m - 1) throw new ArgumentException("Coordinates do not correspond with grid");
		// Get the four corner points of the cell
		double x0 = x[i];
		double x1 = x[i + 1];
		double y0 = y[j];
		double y1 = y[j + 1];
		//WriteLine($"This is x0 {x0} and x1 {x1} and y0 {y0} and y1 {y1}");
		// Get the corresponding function values at the corner points
		double f00 = F[i, j];
		double f01 = F[i, j + 1];
		double f10 = F[i + 1, j];
		double f11 = F[i + 1, j + 1];

		//WriteLine($"This is f00 {f00} and f01 {f01} and f10 {f10} and f11 {f11}");
		// Perform bi-linear interpolation
		double dx = (px - x0) / (x1 - x0);
		double dy = (py - y0) / (y1 - y0);

		//fitting to a bilinear func F(x,y) ≈ a + b * dx + c * dy + d * dx * dy
		double a = f00;
		double b = f10 - f00;
		double c = f01 - f00;
		double d = f11 - f10 - f01 + f00;
		double result  = a + b * dx + c * dy + d * dx * dy;
		return result;

	}
}

