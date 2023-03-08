using static System.Math;

public static partiall class sfuns{

	static double erf(double x){
	/// single precision error function (Abramowitz and Stegun, from Wikipedia)
	if(x<0) return -erf(-x);
	double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
	double t=1/(1+0.3275911*x);
	double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
	return 1-sum*Exp(-x*x);
	}
	
	static double gamma(double x){
	///single precision gamma function (Gergo Nemes, from Wikipedia)
	if(x<0)return PI/Sin(PI*x)/gamma(1-x);
	if(x<9)return gamma(x+1)/x;
	double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	return Exp(lngamma);
	}	
  
} \class
