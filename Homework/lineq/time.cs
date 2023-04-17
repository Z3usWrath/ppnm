
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
		var rand = new Random();
		var b = RandVector(n,rand);
		matrix A = MatGen(n,m,rand);

		(matrix Q, matrix R) = QRGS.decomp(A);
		return 0;
	}

}
