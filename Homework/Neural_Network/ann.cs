using System;
using static System.Console;
using static System.Math;

public class ann{

	int n; /* number of hidden neurons */
	Func<double,double> f = x => x*Exp(-x*x); /* activation function */
	vector p; /* network parameters */
	ann(int n){
		this.n = n;
		p = new vector(3*n);
	}
	double response(double x){
		/* return the response of the network to the input signal x */
	}
	void train(vector x,vector y){
		/* train the network to interpolate the given table {x,y} */
	}
}
