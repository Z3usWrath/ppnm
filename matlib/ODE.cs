using System;
using static System.Math;
using static System.Console;

public static class ODE{


	public static (vector,vector) rkstep12(
	Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
	double x,                    /* the current value of the variable */
	vector y,                    /* the current value y(x) of the sought function */
	double h                     /* the step to be taken */
	)
	{	
		vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
		vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
		vector yh = y+k1*h;              /* y(x+h) estimate */
		vector er = (k1-k0)*h;           /* error estimate */
		return (yh,er);
	}

	public static (vector,vector) driver(
			Func<double,vector,vector> f,
			double a,
			vector ya,
			double b,
			double h = 0.01,
			double acc = 0.01,
			double eps = 0.01,
			genlist<double> xlist = null,
			genlist<vector> ylist = null
			){
		if (a>b) throw new ArgumentException("driver: a>b");
		double x=a; vector y=ya.copy();
		double hmax = 0.1;

		vector err = y*0;
		
		bool recordPath = (xlist != null && ylist != null);
		if (recordPath){
			recordPath = true;
			xlist.add(x);
			ylist.add(y);
		}

		vector tol = new vector(y.size);
		
		do	{
			if(x >= b){
				if (recordPath) {
             				xlist.add(x);
                			ylist.add(y.copy());
            			}
				return (y,err);
			}

			//not crossing
			if(x + h > b) h = b - x;
			
			var (yh,erv) = rkstep12(f,x,y,h);

			bool ok = true;
			for (int i = 0; i < y.size; i++){
				tol[i] = Max(acc, Abs(yh[i]) * eps) * Sqrt(h/(b - a));
				if (!(erv[i]<tol[i])) ok = false;
			}
			
			if (ok){ //accept step
				x += h; y = yh; err = erv;
				if (recordPath){
					xlist.add(x);
					ylist.add(y);
				}
			}

			double factor = tol[0]/Abs(erv[0]);
			for(int i = 1;i < y.size; i++) factor = Min(factor, tol[i]/Abs(erv[i]));
			h *= Min(Pow(factor,0.25)*0.95,2); //reajust stepsize
			h = Min(h, hmax);

		} while(true);
	
	}
}


		// the former form of drive
		/*
		xlist.add(x);
		ylist.add(y);
		do      {
        		if(x>=b) return (xlist,ylist);  job done 
        		if(x+h>b) h=b-x;                last step should end at b 
		        var (yh,erv) = rkstep12(f,x,y,h);
		        double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
		        double err = erv.norm();
		        if(err<=tol){ // accept step
				x+=h; y=yh;
				xlist.add(x);
				ylist.add(y);
			}
			h *= Min( Pow(tol/err,0.25)*0.95 , 2); // reajust stepsize
 	       }while(true); */

