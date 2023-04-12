using System;
using static System.Console;
using static System.Math;

public static class QRGS{
   public static (matrix,matrix) decomp(matrix A){
      matrix Q = A.copy();
      matrix R = new matrix(A.size2,A.size2);
      /* orthogonalize Q and fill-in R */
      for(int i=0; i < A.size2;i++){
	      R[i,i] = Q[i].norm();
	      Q[i] = Q[i]/R[i,i];
	      for(int j = i+1; j < A.size2; j++){
		      R[i,j] = Q[i].dot(Q[j]);
		      Q[j] = Q[j] - Q[i] * R[i,j];
	      }
      }
      return (Q,R);
      }

   public static vector solve(matrix Q, matrix R, vector b){
	   vector y = Q.T*b;
	   for(int i = y.size - 1; i >= 0; i--){
		   double sum = 0;
		   for(int j = i + 1; j < y.size; j++){
			sum += R[i,j]*y[j];
		   }
		   y[i] = (y[i] - sum)/R[i,i];
	   }
	   return y;
   }

   public static double det(matrix R){
	   double determinant = 1;
	   for(int i = 0; i < R.size1; i++){
		   determinant *= R[i,i];
	   }
    	   return determinant;
}

   public static matrix inverse(matrix Q,matrix R){
	   matrix A_inverse = new matrix(Q.size2,Q.size1);
	   // initialize a vector
	   vector v = new vector(Q.size1);
	   for(int i = 0; i < R.size1; i++){
		   v[i] = 0;
	   }
	   // solve for the e_i vector
	   for(int i=0; i < Q.size1; i++){
		   v[i] = 1;
		   A_inverse[i] = solve(Q,R,v);
		   v[i] = 0;
	   }
	   return A_inverse;

   }
}
