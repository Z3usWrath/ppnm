using System;
using static System.Math;
using static System.Console;

public static class main{

	public static int Main(string[] args){

		double a = 0, b = 1;
		//double acc = 1e-2, eps = 1e-2;

		bool plot = true;
		foreach(var arg in args){
		var words = arg.Split(":");
		if(words[0] == "-a") a = double.Parse(words[1]); 
		if(words[0] == "-b") b = double.Parse(words[1]); 
		if(words[0] == "-plot") plot = bool.Parse(words[1]); 
		//if(words[0] == "-a") a = double.Parse(words[1]);  Should check if I can recieve a function from user
		}
		if(plot){
			Func<double, double> f = (x) => Math.Sqrt(x);
			WriteLine($"The intgral from 0 to 1 of f(x) = √(x) is {Integrate.integrate(f,a,b)}");
			
			Func<double, double> f_1 = (x) => 1/Math.Sqrt(x);
			WriteLine($"The intgral from 0 to 1 of f(x) = 1/√(x) is {Integrate.integrate(f_1,a,b)}");

			Func<double, double> f_2 = (x) => 4/(1 - Pow(x,2));
			WriteLine($"The intgral from 0 to 1 of f(x) = 4/(1-x^2) is {Integrate.integrate(f_2,a,b)}");

			Func<double, double> f_3 = (x) => Math.Log(x)/Math.Sqrt(x);
			WriteLine($"The intgral from 0 to 1 of f(x) = ln(x)/√(x) is {Integrate.integrate(f_3,a,b)}\n");
			//Section B

			WriteLine($"The intgral from 0 to 1 of using CC integration of f(x) = 1/√(x) is {Integrate.Clenshaw_Certis(f_1,a,b)}\n");
			
			WriteLine($"The intgral from 0 to 1 using CC integration of f(x) = ln(x)/√(x) is {Integrate.Clenshaw_Certis(f_3,a,b)}\n");
			
		}
		else{
			int partition = 101;
			double z = 1;

			for (int i = partition; i > 0; i--){


                                double x_axis = -4 * i * z / partition;
                                double y_axis = -Integrate.erf(x_axis);
                                WriteLine($"{x_axis}  {y_axis}");
                        }

			for (int i = 1; i < partition; i++){
			

				double x_axis = 4 * i * z / partition;
				double y_axis = Integrate.erf(x_axis);
				WriteLine($"{x_axis}  {y_axis}");
			}

		}






		return 0;
	}
}
