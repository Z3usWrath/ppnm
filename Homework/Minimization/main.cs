using System;
using static System.Math;
using static System.Console;

public static class main{

	public static int Main(string[] args){

		Func<vector, vector> Rosenbrock = (x) => new vector(new double[] {Pow((1-x[0]),2) + 100 * Pow((x[1] - x[0] * x[0]),2)});

		vector x0 = new vector(1);
		x0[0] = 1;
		var y = qnewton.newton(Rosenbrock,x0);
		y.print();
		return 0;
	}

}
