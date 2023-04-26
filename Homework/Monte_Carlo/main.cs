using System;
using static System.Math;
using static System.Console;

public static class main{

	public static int Main(string[] args){


		int N = 1000000;
		var a = new vector(-1 , -1);
		var b = new vector(1, 1);
		bool plot = false;
		bool bpart = false;
		foreach(var arg in args){
			var words = arg.Split(":");
			//if(words[0] == "-a") a = vector.Parse(words[1]);
			if(words[0] == "-bpart") bpart = bool.Parse(words[1]);
			if(words[0] == "-plot") plot = bool.Parse(words[1]);
			if(words[0] == "-N") N = int.Parse(words[1]);
		}
		if(plot){
			
			Func<vector, double> f = (x) => {
		       		if (x.norm() < 1) return 1.0;
		       		else return 0.0;
			};
			var result = MC.plainmc(f, a, b, N);
			WriteLine($"{N} {result.Item1} {result.Item2}");
		}

		else if(!bpart && !plot) {
		//for fun, I wish to calculate the Volume of a sphere
			Func<vector, double> g = (x) => {
				if(x.norm() < 1) return 1.0;
				else return 0.0;
			};
			Func<vector, double> f = (x) => {
        	                if (x.norm() < 1) return 1.0;
        	                else return 0.0;
        	        };
			var result  = MC.plainmc(f, a, b, N);
			WriteLine($"Area of circle: {result.Item1}, error: {result.Item2}");
			var a_3 = new vector(-1, -1, -1);
			var b_3 = new vector(1, 1, 1);	
			var volume = MC.plainmc(g, a_3, b_3, N);
			var func_start  = new vector(0, 0, 0);
			var func_end = new vector(PI, PI, PI);
			WriteLine($"Volume of a sphere: {volume.Item1}, error: {volume.Item2}");
			Func<vector, double> sing_func = (x) => 1 / (1 - Cos(x[0]) * Cos(x[1]) * Cos(x[2]))/PI / PI/ PI;
			var calculation = MC.plainmc(sing_func, func_start, func_end, N);
			WriteLine($"The integral of the singular function is: {calculation.Item1}, error: {calculation.Item2}");
			
		}

		else{
			Func<vector, double> g = (x) => {
                                if(x.norm() < 1) return 1.0;
                                else return 0.0;
				//return Exp(-Abs(x.norm()));
                        };
			var calculation = MC.qrnd(g, a, b, N);
			WriteLine($"{N} {calculation.Item1} {calculation.Item2}");

		}


		return 0;
	}
		
}
