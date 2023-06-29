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
		Func<vector,double> f = delegate(vector d){return (Pow(d[0],2) + Pow(d[1],2) + 1);};
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
		double ans;
		for(int i = 0; i <= nx; i++){
			for(int j = 0; j <= ny; j++){
				px = (x[i]);
				py = (y[j]);
				ans = splines.Interpolate(x,y,F,px,py);
				WriteLine($"{x[i]} {y[j]} {ans}");
			}
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

		/*for(int i = 0; i <= nx; i++){
		xs.add(dx * i + start[0]);
		ys.add(dy * j + start[1]);
		}

		for(int i = 0; i <= nx; i++){
		int j = 0;
		for(j = 0; j <= ny; j++){
		x[i] = dx * i + start[0];
		y[j] = dy * j + start[1];

		}
		}
		*/
		WriteLine("\n Wish me luck :)");
		return 0;
	}
}
