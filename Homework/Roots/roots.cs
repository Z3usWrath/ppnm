using System;
using static System.Math;
using static System.Console;

public static class Roots{

	public static double DELTA = Pow(2,-26);

	public static matrix Jacobian(Func<vector, vector> f, vector x, double epsilon=1e-6) {
    		int n = x.size;
		var J = new matrix(n, n);
    		var dx = new vector(n);
    		for (int j = 0; j < n; j++) {
        		dx = dx * 0;
        		dx[j] = Abs(x[j]) * DELTA;
			if(dx[j] == 0) dx[j] = Pow(2,-27);
        		J[j] = (f(x + dx) - f(x)) / dx[j];
		}
    		return J;
		
	}

	public static vector newton(Func<vector,vector> f, vector x, double eps = 1e-6){
    		while(f(x).norm() >= eps){
        		var J = Jacobian(f, x);
			
        		(matrix Q, matrix R) = QRGS.decomp(J);
		
        		vector Delta_x = QRGS.solve(Q, R, -f(x));
        		double lambda = 1;
        		while(f(x + lambda * Delta_x).norm() > (1 - lambda/2) * f(x).norm() && lambda > 1/1024){
            			lambda /= 2;

        		}
			Delta_x.print();
        		x += Delta_x * lambda;
    		}
    		return x;
	
	}

}
