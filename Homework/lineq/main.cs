
using System;
using static System.Math;
using static System.Console;

public static class main{

	public static vector RandVector(int n, Random rand){
		vector random_vector = new vector(n);
		for(int i = 0; i < n; i++){
			random_vector[i] = rand.NextDouble();
		}
		return random_vector;
	}
	public static matrix MatGen(int n, int m, Random rnd){
		var Rand_Mat = new matrix(n,m);
		for(int i = 0; i < m; i++){
		       Rand_Mat[i] = RandVector(n, rnd);
		}
		return Rand_Mat;
	}		

	public static int Main(string[] args){
		int n = 4;
		int m = 4;

		foreach(var arg in args){
			var words = arg.Split(":");
			if(words[0] == "-n") n = int.Parse(words[1]);
			if(words[0] == "-m") m = int.Parse(words[1]);
		}
		WriteLine($"n={n} m={m}");

		var rand = new Random();
		var b = RandVector(n,rand);
		matrix A = MatGen(n,m,rand);
		WriteLine("The Matrix is:");
		A.print();
		WriteLine("The Vector b is:");
		b.print();

		(matrix Q, matrix R) = QRGS.decomp(A);
		WriteLine("The right Triangular matrix is:");
		R.print();
		WriteLine("Our Q matrix in this decomposition is:");
		Q.print();
		WriteLine("{Q^T}Q = Identity");
		((Q.T)*Q).print();
		WriteLine("Checking that QR = A");
		((Q)*(R)).print();
		
		var x = QRGS.solve(Q,R,b);
		WriteLine("The vector which solves the set of linear equations is:");
		x.print();
		vector c = ((Q)*(R))*(x);
		WriteLine("Multiplying A * x and checking if Ax = b we obtain:");
		c.print();
		for(int i = 4; i < 4; i++){
			if(c[i] == b[i])
				WriteLine("We are good");
		}

		matrix B = QRGS.inverse(Q,R);
		WriteLine("The inverse of A is");
		B.print();
		WriteLine("We check that AA^-1 is indeed the identity:");
		((B)*(A)).print();
	
		return 0;
	}





}
