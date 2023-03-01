using System;
using static System.Console;
using static System.Math;
public static class main{

	public static void Main(){
	int i=1; while(i+1>i) {i++;}
	Write("my max int = {0}\n",i);
	Write("Max value is = {0}\n",int.MaxValue);
	
	i=1; while(i-1<i) {i--;}
        Write("my min int = {0}\n",i);
        Write("Min value is = {0}\n",int.MinValue);	
	
	
	double x=1; while(1+x!=1){x/=2;} x*=2;
	Write("my smallest double = {0}\n",x);
        Write("Smallest double is = {0}\n",System.Math.Pow(2,-52));
	
	float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
	Write("my smallest float = {0}\n",y);
        Write("Smallest float is = {0}\n",System.Math.Pow(2,-23));

	int n=(int)1e6;
	double epsilon=Pow(2,-52);
	double tiny=epsilon/2;
	double sumA=0,sumB=0;

	sumA+=1; for(i=0;i<n;i++){sumA+=tiny;}
	for(i=0;i<n;i++){sumB+=tiny;} sumB+=1;

	WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
	WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
	WriteLine("it is because we add a zeroth number to the system");
	
	double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double d2 = 8*0.1;
	WriteLine($"d1={d1:e15}");
	WriteLine($"d2={d2:e15}");
	WriteLine($"d1==d2 ? => {d1==d2}");
	}
}
