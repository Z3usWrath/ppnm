using System;
using static System.Math;
using static System.Console;

public static class main{


	public static int Main(){
		
		//initialize some values
		int data_length = 10;
		double start = -2.5;
		double end = 2.5;
		double dx = (end - start)/data_length;

		// Our linear function
		Func<double,double> f = delegate(double d){return 1/(Pow(d,2)+0.5);};

		int spline_points = 100;
		double[] x = new double[data_length + 1];
		double[] y = new double[data_length + 1];

		for(int i = 0; i <= data_length; i++){
			x[i] = dx*i + start;
			y[i] = f(dx * i + start);
			WriteLine($"{x[i]}, {y[i]}");
		}

		dx = (end - start) / spline_points;
		WriteLine("\nCalculating the spline points\n");
		for(int i = 0; i < spline_points; i++){
                        WriteLine($"{dx*i + start}, {splines.linterp(x,y,dx*i + start)}");
                }
		WriteLine("\nCalculating the integral of the spline points\n");
		for(int i = 0; i < spline_points; i++){
                        WriteLine($"{dx*i + start}, {splines.linterpInteg(x,y,dx*i + start)}");
                }


		return 0;
	}
}
