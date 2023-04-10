
using System;
using static System.Math;
using static System.Console;

public static class main{

	public static matrix SymMatGen(int n, Random rnd){
		var Rand_Mat = new matrix(n,n);
		for(int i = 0; i < n; i++){
			for(int j = i; j < n; j++){
				Rand_Mat[i,j] = rnd.NextDouble();
				Rand_Mat[j,i] = Rand_Mat[i,j];
			}
		}
		return Rand_Mat;
	}		

	public static int Main(string[] args){
		int n = 2;

		var rand = new Random(1223);
		//var b = RandVector(n,rand);
		matrix A = SymMatGen(n,rand);
		WriteLine("The Matrix is:");
		A.print();
		(vector w, matrix V) = jacobi.cyclic(A);
		WriteLine("\nThe matrix V is:");
		V.print();
		WriteLine("\nThe eigenvalues are:");
		w.print();
		matrix D = (V.T)*A;
		D = D*V;
		WriteLine("\nThe diagonal matrix is D");
		(D).print();
		WriteLine("\nIt is equal to V^T * A * V");
		WriteLine("V^T*V is:");
		((V.T)*(V)).print();
		WriteLine("\n");
		WriteLine("V*V^T is:");
		((V)*(V.T)).print();
		return 0;
	}





}
