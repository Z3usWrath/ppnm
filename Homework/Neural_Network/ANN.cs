using System;
using static System.Console;
using static System.Math;
public class ann {
	public int n; //Hidden Neurons
	public Func<double,double> f; //Activation func
	public Func<double,double> fPrime; //Prime of Activation func.
	public Func<double,double> fDPrime; //Double Derivitive of activation func
	public Func<double,double> fInt; //Integral of Activation func.
	public vector p; //Network parms.
	public int itterations; //Training iterations
	public ann(int n, Func<double,double> f,Func<double,double> fPrime = null, Func<double,double> fInt = null, Func<double,double> fDPrime = null ){ //Constructor
																			  //Structure of p is: 
		this.n = n;
		this.f = f;
		this.fPrime = fPrime;
		this.fDPrime = fDPrime;
		this.fInt = fInt;
		this.p = new vector(3*n);//Possibly set this as a random vector
		this.itterations = 0; 
	}
	public double responsePrime(double x,vector p = null){
		if (p == null) p = this.p;
		double Out = 0;
		if (fPrime == null) throw new ArgumentException("ANN: You need to supply derivitive of activation function");
		for (int i = 0; i<n; i++) Out+= this.fPrime((x-getShift(i,p))/getScale(i,p))*getWeight(i,p)/getScale(i,p);
		return Out;
	}
	public double responseDPrime(double x,vector p = null){
		if (p == null) p = this.p;
		double Out = 0;
		if (fDPrime == null) throw new ArgumentException("ANN: You need to supply double derivitive of activation function");
		for (int i = 0; i<n; i++) Out+= this.fDPrime((x-getShift(i,p))/getScale(i,p))*getWeight(i,p)/getScale(i,p)/getScale(i,p);
		return Out;
	}
	public double response(double x,vector p = null){
		if (p == null) p = this.p;
		double Out = 0;
		for (int i = 0; i<n; i++) Out+= this.f((x-getShift(i,p))/getScale(i,p))*getWeight(i,p);
		return Out;
	}

	public double responseInt(double x,vector p = null){
		if (p == null) p = this.p;
		double Out = 0;
		if (fInt == null) throw new ArgumentException("ANN: You need to supply anti-derivitive of activation function");
		for (int i = 0; i<n; i++) Out+= this.fInt((x-getShift(i,p))/getScale(i,p))*getWeight(i,p)*getScale(i,p);
		return Out;
	}
	public void train(vector x,vector y,Func<vector,ann,double> cost = null){
		if (cost == null) {
			//x: input data, y: correct response
			cost = delegate(vector pn,ann net) {
				double Out = 0;
				for (int i = 0; i<x.size;i++) Out+=Pow(net.response(x[i],pn)-y[i],2);
				return Out/x.size;
			};
		}
		Func<vector,double> Cost = delegate(vector pn){return cost(pn,this);};

		(p,itterations) = opt.qnewton(Cost,p,1e-5,null,this.itterations);
	}
	public double getWeight(int i,vector p = null){
		if (p == null) p = this.p;
		return p[3*i];
	}
	public double getScale(int i, vector p = null) {	
		if (p == null) p = this.p;
		return p[3*i+1];
	}
	public double getShift(int i,vector p = null) {	
		if (p == null) p = this.p;
		return p[3*i+2];
	}
	public vector getP(){return this.p;}
	public void setP(vector np){this.p=np;}
	public void setWeight(int i,double A) {this.p[3*i] = A;}
	public void setScale(int i, double A) {this.p[3*i+1] = A;}
	public void setShift(int i,double A) {this.p[3*i+2] = A;}
}
