using System;
using static System.Console;
using static System.Math;

public static class opt {
	public static vector fgradiant(Func<vector,double> f, vector x){
		var dx = x.copy()*0;
		var Out = new vector(x.size);
		for (int i = 0; i<x.size;i++) {
		       	if (x[i] == 0.0) {
				dx[i] = Pow(2,-52);
			}
			else {
				dx[i] = Abs(x[i])*Pow(2,-26);
			};
			Out[i] = (f(x+dx)-f(x))/(dx[i]);
			dx[i] = 0;
		}
		return Out;
	
	}
	public static (vector,int) qnewton(Func<vector,double> f, vector start, double acc, matrix B = null, int steps = 0){
		//WriteLine($"f = {f(start)}, B follows");
		var grad = fgradiant(f,start);
		if (grad.dot(grad)<acc) return (start,steps);
		if (B == null) {
			B = matrix.id(start.size);
		}
		//B.print();
		double epsilon = 1e-6;
		var dx = -B*grad;
		double lambda = 1;
		
		while (true) {
		//WriteLine($"lambda = {lambda}, df = {f(start+dx*lambda)-f(start)}");	
		if (f(start+dx*lambda)<f(start)) {
			start+=dx*lambda;
			var s = lambda*dx;
			var y = fgradiant(f,start+s)-fgradiant(f,start);
			var u = s-B*y;
			var gamma = (u.dot(y))/(2*s.dot(y));
			if (Abs(s.dot(y))>epsilon) {
				var a = (u-gamma*s)/(s.dot(y));
				B.update(a,s); B.update(s,a);
			};
			break;
		};
		lambda /=2.0;
		if (lambda < 1.0/64){
			//start.print();
			start+=dx*lambda;
			//start.print();
			B.set_identity();
			break;
			}
		};
		return qnewton(f,start,acc,B,steps+1);

	}
}
