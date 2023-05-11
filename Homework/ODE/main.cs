using System;
using static System.Math;
using static System.Console;

public static class main{

	static bool approx(double a,double b, double acc=1e-6, double eps=1e-6){
		if(Abs(a - b) < acc ) return true;
		if(Abs(a - b) < eps*Max(Abs(a),Abs(b))) return true;
		return false;
	}


	public static int Main(){


		var xs = new genlist<double>();
		var ys = new genlist<vector>();

		Func<double,vector,vector> f = delegate(double x, vector y){
			return new vector(y[1], -y[0]);
		};

		double a = -2 * PI, b = 2 * PI;
		double h = 1e-2, acc = 1e-2, eps = 1e-2;
		vector ya = new vector(0,1);

		ODE.driver(f,a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);

		for (int i = 0; i < xs.size; i++){
			WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
		}
		// continue with the dampend oscillator
		Func<double, vector, vector> damp_oscillator = delegate(double t, vector y)
		{
			return new vector(y[1], -0.5 * y[1] - 5.0 * Sin(y[0]));
		};
		var xs_2 = new genlist<double>();
		var ys_2 = new genlist<vector>();
		ODE.driver(damp_oscillator,a,ya,b,acc:acc,eps:eps,h:h,xlist:xs_2,ylist:ys_2);
		WriteLine("\n");
		for (int i = 0; i < xs_2.size; i++){
			WriteLine($"{xs_2[i]} {ys_2[i][0]} {ys_2[i][1]}");
		}

		WriteLine("\n");

		//part B Homework

		a = 0;
		b = 100 * PI;

		double epsilon = 0;
		Func<double, vector, vector> two_bodies_f = delegate(double t, vector y)
		{
			return new vector(y[1], 1 - y[0] + epsilon * y[0] * y[0] );
		};

		//part  1

		var xs_3 = new genlist<double>();
		var ys_3 = new genlist<vector>();
		ya[0] = 1;
		ya[1] = 0;
		ODE.driver(two_bodies_f,a,ya,b,1e-5,1e-5,h = 1e-7,xlist:xs_3,ylist:ys_3);
		WriteLine("\n");
		for (int i = 0; i < xs_3.size; i++){
			WriteLine($"{xs_3[i]} {ys_3[i][0]} {ys_3[i][1]}");
		}
		WriteLine("\n");

		//part 2

		var xs_4 = new genlist<double>();
		var ys_4 = new genlist<vector>();
		ya[0] = 1;
		ya[1] = -0.5;
		ODE.driver(two_bodies_f,a,ya,b,acc:acc,eps:eps,h:h,xlist:xs_4,ylist:ys_4);
		WriteLine("\n");
		for (int i = 0; i < xs_4.size; i++){
			WriteLine($"{xs_4[i]} {ys_4[i][0]} {ys_4[i][1]}");
		}
		WriteLine("\n");
		//part 3

		var xs_5 = new genlist<double>();
		var ys_5 = new genlist<vector>();
		ya[0] = 1;
		ya[1] = -0.5;
		epsilon = 1e-1;
		ODE.driver(two_bodies_f,a,ya,b,acc:acc,eps:eps,h:h,xlist:xs_5,ylist:ys_5);
		for (int i = 0; i < xs_5.size; i++){
			WriteLine($"{xs_5[i]} {ys_5[i][0]} {ys_5[i][1]}");
		}

		//part C
		//
		double m1 = 1, m2 = 1, m3 = 1;
		Func<double, vector, vector> three_body_ode = delegate(double t, vector y)
		{
			double G = 1; // gravitational constant

			double x1 = y[0], y1 = y[1];
			double x2 = y[2], y2 = y[3];
			double x3 = y[4], y3 = y[5];

			double r12 = Sqrt((x2-x1)*(x2-x1) + (y2-y1)*(y2-y1));
			double r13 = Sqrt((x3-x1)*(x3-x1) + (y3-y1)*(y3-y1));
			double r23 = Sqrt((x3-x2)*(x3-x2) + (y3-y2)*(y3-y2));

			vector dydt = new vector(6);
			dydt[0] = y[6];
			dydt[1] = y[7];
			dydt[2] = y[8];
			dydt[3] = y[9];
			dydt[4] = y[10];
			dydt[5] = y[11];
			dydt[6] = G * ((y[9]-y[7])*m2/r12/r12/r12 + (y[11]-y[7])*m3/r13/r13/r13);
			dydt[7] = G * ((y[10]-y[8])*m2/r12/r12/r12 + (y[11]-y[8])*m3/r23/r23/r23);
			dydt[8] = G * ((y[11]-y[9])*m3/r23/r23/r23 + (y[7]-y[9])*m1/r13/r13/r13);
			dydt[9] = G * ((y[11]-y[10])*m3/r23/r23/r23 + (y[7]-y[10])*m1/r12/r12/r12);
			dydt[10] = G * ((y[7]-y[11])*m1/r12/r12/r12 + (y[8]-y[11])*m2/r23/r23/r23);
			dydt[11] = G * ((y[7]-y[9])*m1/r13/r13/r13 + (y[8]-y[10])*m2/r23/r23/r23);

			return dydt;
		};
		var x_3_bodies = new genlist<vector>();
		var y_3_bodies = new genlist<vector>();
		var y_init = new vector(12);



		return 0;
	}

}
