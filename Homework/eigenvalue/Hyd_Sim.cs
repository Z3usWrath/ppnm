using System;
using static System.Console;
using static System.Math;

public static class hsim{

	public static int Main(string[] args){
		double dr = 0.1, rmax = 10;
		int num_of_functions = 2;
		foreach(var arg in args){
			var words = arg.Split(":");

			if(words[0] == "-dr") dr = double.Parse(words[1]);
			if(words[0] == "-rmax") rmax = double.Parse(words[1]);
		}
		int npoints = (int)(rmax/dr)-1;
		vector r = new vector(npoints);
		for(int i = 0; i < npoints; i++) r[i] = dr*(i+1);
		matrix H = new matrix(npoints,npoints);
		for(int i = 0; i < npoints - 1; i++){
			H[i,i]  =-2;
			H[i,i+1]= 1;
			H[i+1,i]= 1;
		}
		H[npoints-1,npoints-1]=-2;
		matrix.scale(H, -0.5 / (dr * dr));
		for(int i = 0; i < npoints; i++) H[i,i]-=1/r[i];

		(vector w, matrix V) = jacobi.cyclic(H);

		for(int sol = 0; sol < num_of_functions+1; sol++){
			WriteLine($"{H[sol,sol]}");
			for (int i = 0; i < npoints; i++) WriteLine($"{r[i]} {V[i,sol]/Sqrt(dr)}");
			WriteLine($"\n");
		}
		w.print();

		return 0;
	}


}

