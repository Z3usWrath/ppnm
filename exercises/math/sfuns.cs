using static System.Math;
public class Gamma{

	public static double gamma(double x){
	///single precision gamma function (formula from Wikipedia)
	if(x<0)return PI/Sin(PI*x)/gamma(1-x); // Euler's reflection formula
	if(x<9)return gamma(x+1)/x; // Recurrence relation
	double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	return Exp(lngamma);
	}
}
