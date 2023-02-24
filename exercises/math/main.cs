using System;
using static System.Console;
using static System.Math;
class main{

	public static void Main(){
	double sqrt2=Sqrt(2.0);
	Write($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");
	double Fifth_Power = Math.Pow(2.0,1.0/5.0);
	Write($"Fifth_Power2^5 = {Fifth_Power*Fifth_Power*Fifth_Power*Fifth_Power*Fifth_Power} (should equal 2)\n");
	double E_ToThe_Pi = Math.Exp(Math.PI);
	Write($"E^PI = approximatley {E_ToThe_Pi}\n");
	double Pi_ToThe_E = Math.Pow(Math.PI,Math.E);
	Write($"PI^E = approximately {Pi_ToThe_E}\n");


	Write($"gamma(1) = "+ Gamma.gamma(1.0)+"\n");
        Write($"gamma(2) = "+ Gamma.gamma(2.0)+"\n");
	Write($"gamma(3) = "+ Gamma.gamma(3)+"\n");
	Write($"gamma(4) = "+ Gamma.gamma(4)+"\n");
        Write($"gamma(10) = "+Gamma.gamma(10.0)+"\n");
	}
}
