Out.txt : main.exe #Something
	mono main.exe > Out.txt

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

main.exe : main.cs cmath.dll
	mcs -target:exe -out:main.exe -reference:cmath.dll main.cs

clean:
	rm -f Out.txt hello.exe

