Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs
	mcs main.cs -reference: -target:exe -out:main.exe

clean:
	rm -f Out.txt main.exe
