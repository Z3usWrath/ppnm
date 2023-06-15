using System;
using static System.Console;
using static System.Math;

public static class main{
        public static int Main(){

		//hidden neurons and data points
                int n = 5, m = 100;
                vector Input = new vector(m), Output = new vector(m);

                for(int i = 0; i < m; i++){
                        Input[i] = 2.0 / m * i - 1;
                        Output[i] = Cos(5 * Input[i] - 1) * Exp(-Pow(Input[i],2));
                }

                Func<double,double> gaussWavelet = delegate(double x){
                        return x * Exp(-x * x);
                };
                Func<double,double> gaussWaveletPrime = delegate(double x){
                        return (1 - 2 * x * x) * Exp(-x * x);
                };
                Func<double,double> gaussWaveletDPrime = delegate(double x){
                return 2 * x *(2 * x * x - 3) * Exp(-x * x);
                };
                Func<double,double> gaussWaveletAntiPrime = delegate(double x){
                                        return -Exp(-x * x)/2;
                };
                Func<double,double> demoFunc = delegate(double x){
                        return Cos(5 * x - 1) * Exp(-x * x);
                };
                var netWork = new ann(n,gaussWavelet,gaussWaveletPrime,gaussWaveletAntiPrime,gaussWaveletDPrime);

                var rng = new Random();
                var parameters = new vector(n * 3);
                for (int i = 0; i < n; i++) {
                parameters[3 * i] = rng.NextDouble()%1; //Weight
                parameters[3 * i + 1] = rng.NextDouble()%1000; //Scale
                parameters[3 * i + 2] = rng.NextDouble()%1000; //Shift
                }
                netWork.setP(parameters);
                netWork.train(Input,Output);
                for (int i = 0; i < 2 * m; i++){
                double x = 1.0/m * i - 1;
                WriteLine($"{x} {netWork.response(x)} {demoFunc(x)} {netWork.response(x,parameters)} {(-5*Sin(5*x-1)-2*x*Cos(5*x-1))*Exp(-x*x)} {netWork.responsePrime(x)} {netWork.responseInt(x)-netWork.responseInt(0)} {Integrate.integrate(demoFunc,0,x)} {netWork.responseDPrime(x)} {Exp(-x*x)*((4*x*x-27)*Cos(5*x-1)+20*x*Sin(5*x-1))}");
                }
                return 0;
        }
}
