using System;
using static System.Math;
using static System.Console;

public static class main{

	public static int Main(string[] args){


		vector start = new vector(-2.0,-2.0);
		vector end = new vector(2.0,2.0);
		int nx = 20;
		int ny = 20;
		double px,py;
		double dx = (end[0] - start[0])/(nx);
		double dy = (end[1] - start[1])/(ny);

		foreach(var arg in args){
			var words = arg.Split(":");
			if(words[0] == "-startx") start[0] = double.Parse(words[1]);
			if(words[0] == "-endx") end[0] = double.Parse(words[1]);
			if(words[0] == "-starty") start[1] = double.Parse(words[1]);
			if(words[0] == "-endy") end[1] = double.Parse(words[1]);
			if(words[0] == "-nx") nx = int.Parse(words[1]);
			if(words[0] == "-ny") ny = int.Parse(words[1]);
		}

		//Chose some random func..
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
		WriteLine("Wish me luck :)");
		return 0;
	}
}
