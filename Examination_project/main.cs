using System;
using static System.Math;
using static System.Console;

public static class main{

	public static int Main(string[] args){


		vector start = new vector(-2.0,-2.0);
		vector end = new vector(2.0,2.0);
		//double px , py;
		int nx = 20;
		int ny = 20;
		//int spline_points = 3;
		double px,py;
		double dx = (end[0] - start[0])/(nx+1);
		double dy = (end[1] - start[1])/(ny+1);

		foreach(var arg in args){
			var words = arg.Split(":");
			if(words[0] == "-startx") start[0] = double.Parse(words[1]);
			if(words[0] == "-endx") end[0] = double.Parse(words[1]);
			if(words[0] == "-starty") start[1] = double.Parse(words[1]);
			if(words[0] == "-endy") end[1] = double.Parse(words[1]);
			//if(words[0] == "-spline_points") spline_points = int.Parse(words[1]);
			if(words[0] == "-px") py = double.Parse(words[1]);
			if(words[0] == "-py") py = double.Parse(words[1]);

		}

		//Chose some random func..
		//Func<vector,double> f = delegate(vector d){return (1/(Pow(d[0],2) + Pow(d[1],2) + 1));};
		Func<vector,double> f = delegate(vector d){return (1/(Pow(d[0],2) + Pow(d[1],2) + 1.0));};
		double[] x = new double[nx + 1];
		double[] y = new double[ny + 1];
		matrix F = new matrix(nx + 1, ny + 1);
		//initializing x and y and F values
		double ans;
		for(int i = 0; i <= nx; i++){
			x[i] = dx * i + start[0];
			for(int j = 0; j <= ny; j++){
				y[j] = dy * j + start[1];
			}
		}
		for(int i = 0; i <= nx; i++){
                        for(int j = 0; j <= ny; j++){
                                vector d = new vector(x[i], y[j]);
                                F[i, j] = f(d);
                                px = x[i];
                                py = y[j];
                                ans = splines.Interpolate(x,y,F,px,py);
                                WriteLine($"{x[i]} {y[j]} {F[i,j]} {ans}");
                        }
                }

		WriteLine("\n");
/*

		double[] x1 = { 1, 2, 3, 4 };
		double[] y1 = { 1, 2, 3 };
		matrix F1 = new matrix(4,3);
		for(int i = 0; i <= 3; i++){
			for(int j = 0; j <= 2; j++){
				F1[i,j] = x1[i] * y1[j];
			}
		}
		F1.print();
		// Test case 1: Interpolate at point (2.5, 1.5)
		double result1 = splines.Interpolate(x1, y1, F1, 2.5, 1.5);
		double expected1 = 3.75;
		Console.WriteLine($"Test case 1: Result = {result1}, Expected = {expected1}, Passed = {result1 == expected1}");

		// Test case 2: Interpolate at point (3.7, 2.2)
		double result2 = splines.Interpolate(x1, y1, F1, 3.7, 2.2);
		double expected2 = 8.14;
		Console.WriteLine($"Test case 2: Result = {result2}, Expected = {expected2}, Passed = {result2 == expected2}");

		double result3 = splines.Interpolate(x, y, F, 0, 0);
		double expected3 = 1;
		Console.WriteLine($"Test case 3: Result = {result3}, Expected = {expected3}, Passed = {result3 == expected3}");


*/
		WriteLine("\n Wish me luck :)");
		return 0;
	}
}
