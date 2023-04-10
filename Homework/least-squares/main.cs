using System;
using static System.Math;
using static System.Console;

public static class main{


	public static (double, double) HalfTime(matrix S, vector c)
	{
		double T = Log(2)/(-c[0]);
		double error = Log(2)*Sqrt(S[0,0])/Pow((c[0]),2);
		return (T, error);
	}

	public static int Main(string[] args){

	



		foreach (var arg in args) {
			var words = arg.Split(":");
			if(words[0] == "-x")
			{
				var x = ???
		
			}	
			if(words[0] == "-y") y = int.Parse(words[1]);
			if(words[0] == "-start") y = double.Parse(words[1]);
			if(words[0] == "-end") y = double.Parse(words[1]);
			if(words[0] == "-y") y = int.Parse(words[1]);
		}


		return 0;
	}

}
