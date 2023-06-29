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
		double px,py;
		double dx = (end[0] - start[0])/nx;
		double dy = (end[1] - start[1])/ny;

		//var xs = new genlist<double>();
		//var ys = new genlist<double>();
		//var Fs = new genlist<double>();
		//Chose some random func, similar to HW
		Func<vector,double> f = delegate(vector d){return (1/(Pow(d[0],2) + Pow(d[1],2) + 1));};
		double[] x = new double[nx + 1];
		double[] y = new double[ny + 1];
		matrix F = new matrix(nx + 1, ny + 1);
		//initializing x and y and F values
		for(int i = 0; i <= nx; i++){
			x[i] = dx * i + start[0];
			for(int j = 0; j <= ny; j++){
				y[j] = dy * j + start[1];
				vector d = new vector(x[i], y[j]);
				F[i, j] = f(d);
				WriteLine($"{x[i]} {y[j]} {F[i,j]}");
			}
		}

		WriteLine("\n");

		for(int i = 0; i <= nx; i++){
			x[i] = dx * i + start[0];
			for(int j = 0; j <= ny; j++){
				if(i ==0){
				       px = x[i];
				       continue;
				}
				if(j ==0){
					py = y[j];
					continue;
				}
				px = (x[i] + x[i - 1])/2;
				py = (y[j] + y[j - 1])/2;
				double ans = splines.Interpolate(x,y,F,px,py);
				WriteLine($"{x[i]} {y[j]} {ans}");
			}
		}



		/*
		//initialize some values
		vector start = new vector(-5,-5);
		vector end = new vector(5,5);
		//int spline_points = 100;
		int nx = 10;
		int ny = 10;
		double px = 0, py = 0;
		double dx = (end[0] - start[0])/nx;
		double dy = (end[1] - start[1])/ny;
		var xs = new genlist<double>();
		var ys = new genlist<double>();
		var Fs = new genlist<double>();

		// need to add users list
		foreach(var arg in args){
		var words = arg.Split(":");
		if(words[0] == "-startx") start[0] = double.Parse(words[1]);
		if(words[0] == "-endx") end[0] = double.Parse(words[1]);
		if(words[0] == "-starty") start[1] = double.Parse(words[1]);
		if(words[0] == "-endy") end[1] = double.Parse(words[1]);
		//		if(words[0] == "-spline_points") spline_points = int.Parse(words[1]);
		if(words[0] == "-px") py = double.Parse(words[1]);
		if(words[0] == "-py") py = double.Parse(words[1]);

		}
		/*
		var separators = new char[] { ' ', '\t' };
		var options = StringSplitOptions.RemoveEmptyEntries;
		string line;
		int sum = 0;
		do
		{
		sum++;
		line = Console.ReadLine();
		//throw new ArgumentException($"After sum++ and line, {sum}");
		if (line == null) break;
		string[] words = line.Split(separators, options);
		if (words.Length >= 3)
		{
		WriteLine("In the loop");
		xs.add(double.Parse(words[0]));
		ys.add(double.Parse(words[1]));
		Fs.add(double.Parse(words[2]));}
		else
		{
		WriteLine("Invalid input. Please provide values for x, y, and f separated by spaces.");
		}
		if(sum > 10) throw new ArgumentException("Too many times");
		} while (true);


		double[] x = new double[nx + 1];
		double[] y = new double[ny + 1];
		double[,] F = new double[nx + 1,ny + 1];

		Func<vector,double> f = delegate(vector d){return (1/(Pow(d[0],2)) + 1/(Pow(d[1],2) + 1.0));};

		/*for(int i = 0; i <= nx; i++){
		xs.add(dx * i + start[0]);
		ys.add(dy * j + start[1]);
		}

		for(int i = 0; i <= nx; i++){
		int j = 0;
		for(j = 0; j <= ny; j++){
		x[i] = dx * i + start[0];
		y[j] = dy * j + start[1];
		//px = x[i]; 
		//py = y[j];

		F[i,j] = (splines.Interpolate(x,y,F,px,py));
		//WriteLine($"{x[i]}, {y[j]}, {F[i,j]}");
		//WriteLine($"This is the result {F[i,j]}");
		}
		}
		//dx = (end - start) / spline_points;
		*/
		WriteLine("Wish me luck :)");
		return 0;
	}
}
