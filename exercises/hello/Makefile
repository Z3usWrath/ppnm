Out.txt : hello.exe #Something
	mono hello.exe > Out.txt

hello.exe : hello.cs
	mcs hello.cs

clean:
	rm -f Out.txt hello.exe

