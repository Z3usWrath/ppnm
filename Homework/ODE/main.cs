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


		return 0;
	}

}
