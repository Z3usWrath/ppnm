using System;
using static System.Console;
using static System.Math;

public static class main {

	public static void Main(string [] args){
		double eps = 1e-2;
		int steps = 0;
		int steps1 = 0;
		int steps_B = 0;
		vector result = new vector(2);
		vector result2 = new vector(2);
		//guess close to the solution
		vector start = new vector(2);
		start[0] = 0.5;

		//fitting the data to a graph with BritWigner func
		string fit = null;
		double minE = 101;
		double maxE = 159;
		int E_steps = 1000;
		double EnergyStep = (maxE - minE) / E_steps;
		foreach(var arg in args){
			var words = arg.Split(":");
			if (words[0] == "-tofit") fit = words[1];
		}
		if (fit == null) throw new ArgumentException("Can't plot without the data");
		//Continue Part A
		Func<vector, double> f = delegate(vector x){
			return (1 - x[0]) * (1 - x[0]) + 100 * Pow(x[1] - x[0] * x[0],2);
		};
		(result, steps) = opt.qnewton(f, start, eps);
		WriteLine($"The minimum of Rosenbrock's valley function was found at x = {result[0]} y = {result[1]} it took {steps} steps to achieve the result");
		WriteLine("The analytic solution is: (1,1)");
		Func<vector, double> g = delegate(vector x){
			return Pow(x[0] * x[0] + x[1] -  11, 2) + Pow(x[0] + x[1] * x[1] - 7, 2);
		};
		start[1] = 0.5;
		start[0] = 1;
		(result2,steps1) = opt.qnewton(g, start, eps);
		WriteLine($"The minimum of Himmelblau's was found at x = {result2[0]} y = {result2[1]} it took {steps1} steps to achieve the result");
		WriteLine("The analytic solution is: (3,2)");
		WriteLine("There are more but I chose that one");
		var energy = new genlist<double>();
		var signal = new genlist<double>();
		var error  = new genlist<double>();
		var separators = new char[] {' ','\t'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		do{
			string line = Console.In.ReadLine();
			if(line == null) break;
			string[] words = line.Split(separators,options);
			energy.add(double.Parse(words[0]));
			signal.add(double.Parse(words[1]));
			error.add(double.Parse(words[2]));
		}while(true);

		//Part B
		int n = energy.size;

		WriteLine("Enter part B");	
		//0: mass, 1: Gamma, 2: A

		Func<vector, double> B_f = delegate(vector x) {
			double ans = 0;
			for (int i = 0; i < n; i++){
				ans += Pow((x[2] / (Pow(energy[i] - x[0],2) + x[1] * x[1] / 4) - signal[i]) / error[i],2);
			}
			return ans;};
		vector result_B = new vector(3);
		vector start_B = new vector(3);
		//initial guess
		start_B[0] = 120;
		start_B[1] = 10;
		start_B[2] = 1;
		(result_B,steps_B) = opt.qnewton(B_f,start_B,eps*eps);
		WriteLine($"The mass is {result_B[0]}, Gamma is {result_B[1]}, And A is {result_B[2]}, it took {steps_B} steps to solve");
		
		Func<double,double,double,double,double> BritWigner = delegate(double E, double m, double gamma, double A) {
			return A / (Pow(E - m,2) + Pow(gamma,2)/ 4);
		};
		var data = new System.IO.StreamWriter(fit, append : false);

		for (int i = 0; i < E_steps; i++){
			double BW = BritWigner(EnergyStep * i + minE, result_B[0], result_B[1], result_B[2]);
			data.WriteLine($"{EnergyStep * i + minE} {BW}");
//			WriteLine($"The energy is {EnergyStep * i + minE} and the result is  {BW}");
//			WriteLine($"A is {result_B[2]} minE is {minE} ");

			
		}
	}
}

// don't forget to use update from the matrix libarary..

