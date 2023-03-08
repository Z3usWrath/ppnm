using System;
using static System.Console;
using SM=System.Math;

class main{
	public static int Main(){
	complex j = new complex(-1,0);
	complex x = new complex(0,1);
	complex s = new complex(0,-1);
	complex y = new complex(0,Math.PI);
	complex sqrti = new complex(Math.Cos(Math.PI/4),Math.Sin(Math.PI/4));

	if(sqrti.approx(cmath.sqrt(x))){
	Write($"After checking we get \u221A(i) = "+cmath.sqrt(x)+"\n");
	}	
	Write($"exp(i) = "+cmath.exp(x)+"\n");
	if(cmath.exp(y).approx(j)){
	Write($"After checking we get Exp(i*PI) = "+cmath.exp(y)+"\n");
	}
	Write($"exp(i^i) = "+cmath.pow(x,x)+" = Exp(-Pi/2)\n");
	Write($"log(i) = "+cmath.log(x)+"\n");
	Write($"sin(i*pi) = "+cmath.sin(y)+"\n");
	if(x.approx(cmath.sqrt(j)) && j.approx(cmath.pow(s,2))){
	Write($"After checking we get \u221A(-1)=\u00B1i\n");
		
	}	
	
	return 0;
        }
}
