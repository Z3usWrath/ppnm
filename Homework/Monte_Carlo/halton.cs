using System;
public class halton{

	int[] bs = new int[]
	{2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
	int n = 0,s=0,d=1;

	public halton(int dim=1,int shift=0){
		d=dim;s=shift;
		if(d>bs.Length)throw new Exception($"halton d>{bs.Length}");
		if(d+s>bs.Length)throw new Exception($"halton d+s>{bs.Length}");
	}

	public static double corput(int n, int b){
		double q=0,bk=1.0/b;
		while(n>0){q+=(n%b)*bk;n/=b;bk/=b;}
		return q;
	}

	public vector next(){
		n++;
       		vector x=new vector(d);
	       	for(int i=0;i<d;i++)x[i]=corput(n,bs[i+s]);
	       	return x;
	}

}//class
