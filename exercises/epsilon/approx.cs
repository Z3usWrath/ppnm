

public class Approx{
	public static bool approx (double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(b-a) < acc) return true;
		else if(Abs(b-a) < Max(Abs(a),Abs(b))*eps) return true;
		else return false;
	}
}
