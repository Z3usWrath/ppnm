using System;
using static System.Console;
using static System.Math;
public class ann {
	public int n; //Hidden Neurons
	public vector par; //Network parameters
	public int itterations; //Training iterations
	public Func<double,double> f; //Activation func
	public Func<double,double> fInt; //Int(f)
	public Func<double,double> fPrime; //f'
	public Func<double,double> fDPrime; //f''
	public double Sum;
	public ann(int n, Func<double,double> f,Func<double,double> fPrime = null, Func<double,double> fInt = null, Func<double,double> fDPrime = null ){ 
		//Ann class
		//parameters 
		this.n = n;
		this.f = f;
		this.fPrime = fPrime;
		this.fDPrime = fDPrime;
		this.fInt = fInt;
		this.par = new vector(3*n);
		this.itterations = 0; 
	}
	//Aux funcs:
	public double Scale(int i, vector par = null) {	
		if (par == null) par = this.par;
		return par[3 * i + 1];
	}
	public double Weight(int i,vector par = null){
                if (par == null) par = this.par;
                return par[3 * i];
        }
        public double Shift(int i,vector par = null) {
                if (par == null) par = this.par;
                return par[3 * i + 2];
        }

	public double responsePrime(double x,vector par = null){
		Sum = 0;
		if (par == null) par = this.par;
		if (fPrime == null) throw new ArgumentException("Forgot to add the derivitive of activation function?");
		for (int i = 0; i < n; i++) Sum += this.fPrime((x - Shift(i,par))/Scale(i,par)) * Weight(i,par)/Scale(i,par);
		return Sum;
	}

	public double responseDPrime(double x,vector par = null){
		Sum = 0;
		if (par == null) par = this.par;
		if (fDPrime == null) throw new ArgumentException("Forgot to add the second derivitive of activation function?");
		for (int i = 0; i < n; i++) Sum += this.fDPrime((x - Shift(i,par))/Scale(i,par)) * Weight(i,par)/Scale(i,par)/Scale(i,par);
		return Sum;
	}
	public double response(double x,vector par = null){
		if (par == null) par = this.par;
		Sum = 0;
		for (int i = 0; i < n; i++) Sum += this.f((x - Shift(i,par))/Scale(i,par)) * Weight(i,par);
		return Sum;
	}

	public double responseInt(double x,vector par = null){
		if (par == null) par = this.par;
		Sum = 0;
		if (fInt == null) throw new ArgumentException("Forgot to add the anti derivitive of activation function?");
		for (int i = 0; i < n; i++) Sum += this.fInt((x - Shift(i,par))/Scale(i,par)) * Weight(i,par) * Scale(i,par);
		return Sum;
	}
	public void train(vector x,vector y,Func<vector,ann,double> cost = null){
		if (cost == null) {
			//x: input data, y: correct response
			cost = delegate(vector pn,ann net) {
				Sum = 0;
				for (int i = 0; i < x.size; i++) Sum += Pow(net.response(x[i],pn) - y[i],2);
				return Sum/x.size;
			};
		}
		Func<vector,double> Cost = delegate(vector pn){return cost(pn,this);};

		(par,itterations) = opt.qnewton(Cost,par,1e-5,null,this.itterations);
	}

	public vector getP(){return this.par;}
	public void setP(vector np){this.par = np;}
	public void setWeight(int i,double A) {this.par[3 * i] = A;}
	public void setScale(int i, double A) {this.par[3 * i + 1] = A;}
	public void setShift(int i,double A) {this.par[3 * i + 2] = A;}
}
