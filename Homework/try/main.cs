using System;
using static System.Math;
using static System.Console;

public static class main{

	public static int Main(string[] args){


		vector start = new vector(-1.0,-1.0);
		vector end = new vector(1.0,1.0);
		int nx = 20;
		int ny = 20;
		double dx = (end[0] - start[0])/(nx+1);
		double dy = (end[1] - start[1])/(ny+1);


		Func<vector,double> f = delegate(vector S){return (1/(S[0] * S[0] + S[1]*S[1] + 1.0));};
		double[] x = new double[nx + 1];
		double[] y = new double[ny + 1];
		matrix F = new matrix(nx + 1, ny + 1);
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
                                WriteLine($"{x[i]} {y[j]} {F[i,j]}");
                        }
                }
	return 0;
	}
}

