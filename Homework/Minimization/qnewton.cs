using System;
using static System.Console;
using static System.Math;
public static class qnewton{

	public static vector newton(Func<vector, double> phi, vector x0, double eps = 1e-6) {
    
		matrix B = matrix.Identity(n);

		while (true){
    
    			vector grad = gradient(x);

    			if (grad.L2Norm() < tolerance){
        			break;
			}
    			vector dx = -B.Inverse() * grad;

    			double lambda = 1.0;

    			while (true){
        			vector x_next = x + lambda * dx;
        			double phi_next = ObjectiveFunction(x_next);

        			if (phi_next < phi(x) + alpha * lambda * grad.Dot(dx)){
            				// Accept step and upda
					x = x_next;
					vector s = lambda * dx;
            				vector y = Gradient(x_next) - grad;
            				double rho = 1.0 / y.Dot(s);
            				matrix I = Matrix.Identity(n);
            				B = (I - rho * s.OuterProduct(y)) * B * (I - rho * y.OuterProduct(s)) + rho * s.OuterProduct(s);
            				break;
        			}
        			lambda /= 2.0;
        			if (lambda < Pow(2,-26)){
            				x = x_next;
            				B = Matrix.Identity(n);
            				break;
				}
    			}
		}

	}










}
