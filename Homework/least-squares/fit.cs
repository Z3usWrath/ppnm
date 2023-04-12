using System;
using static System.Console;
using static System.Math;

public static class Fit{
	
	public static (vector, matrix) lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
		
		int n = x.size , m = fs.Length;
		var A = new matrix (n,m);
		var b = new vector (n);
		for(int i = 0; i < n; i++){
			b[i] = y[i] / dy[i];
			for(int j = 0; j < m; j++) A[i,j] = fs[j](x[i])/dy[i];
		}
		(matrix Q, matrix R) = QRGS.decomp(A);
		vector c = QRGS.solve(Q, R, b);
		var inv_A = QRGS.inverse(Q,R);
		var S = inv_A * inv_A.T;
		return(c,S);
	}
}

