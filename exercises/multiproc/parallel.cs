using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
class main{
	
	public static int Main(string[] args){
	int nterms = (int)1e8, nthreads = 1;
	foreach(var arg in args){
		var words = arg.Split(':');
		if(words[0] == "-terms" )nterms =(int)float.Parse(words[1]);
		if(words[0] == "-threads" )nthreads = (int)float.Parse(words[1]); 	
	}	
	WriteLine($"nterms = {nterms} , nthreads = {nthreads}");
	double sum = 0;
	for(int i = 1; i < nterms +1;i++) {sum += 1.0/i; }
	Parallel.For( 1, nterms + 1, delegate(int i){sum+=1.0/i;} );
	WriteLine($"nterms = {nterms} , sum = {sum}");

	return 0;
}


}
