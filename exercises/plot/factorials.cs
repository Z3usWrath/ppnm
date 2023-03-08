sfuns.dll : gamma.cs erf.cs
	mcs -targer:library -out:$@ $^

factorials.data : Makefile
	>$@
	echo 0 1 >>@
	echo 1 1 >>@
	echo 2 2 >>@
	echo 3 6 >>@
	echo 4 24 >>@
	echo 5 120 >>@
	echo 6 'echo '6*120' |bc'
