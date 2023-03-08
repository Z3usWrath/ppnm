using System;
using static System.Console;
using SM=System.Math;

class main{
	public static int Main(){
	complex j = new complex(-1,0);
	complex x = new complex(0,1);
	complex y = new complex(0,Math.PI);
	Write($"\u221A(-1) = "+cmath.sqrt(j)+"\n");
	Write($"We recieved the sqrt of -1 "+complex.approx(-1,x,1e-3,1e-3)+" \n");
	Write($"\u221A(i) = "+cmath.sqrt(x)+"\n");
	Write($"exp(i) = "+cmath.exp(x)+"\n");
	Write($"exp(i*pi) = "+cmath.exp(y)+"\n");
	Write($"exp(i^i) = "+cmath.pow(x,x)+"\n");
	Write($"log(i) = "+cmath.log(x)+"\n");
	Write($"sin(i*pi) = "+cmath.sin(y)+"\n");
	if(complex.approx(cmath.sqrt(x),y,1e-9,1e-9)){
	Write("Im in\n");
	}	

	return 0;
        }
}
