using static System.Console;
public class vec{
	public double x,y,z;
	public vec (double x,double y,double z)
		{ this.x=x; this.y=y; this.z=z; }
	public vec (){ x=y=z=0; }
	public void print(string s){Write(s);WriteLine($"{x} {y} {z}");}

	public static vec operator+(vec u,vec v){ /* u+v */
		return new vec(u.x+v.x,u.y+v.y,u.z+v.z);
			}

	public static vec operator-(vec u,vec v){ /* u-v */
		return new vec(u.x-v.x,u.y-v.y,u.z-v.z);
			}

	public static vec operator-(vec v){ /* -v */
		return new vec(-v.x,-v.y,-v.z);
			}

	public static vec operator*(vec u,double c){ /* u*c */
		return new vec(u.x*c,u.y*c,u.z*c);
	}

	public static vec operator*(double c,vec u){ /* c,*u */
		return u*c;
	}

	public static double operator% (vec u,vec v){ /* u%v => dot product */
		return u.x*v.x+u.y*v.y+u.z*v.z;
	}

	public double dot (vec other){ return this%other; }
}
