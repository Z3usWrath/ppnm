Out.txt : main.exe input.txt
	mono $< <input.txt 1> $@ 2> log

main.exe : main.cs genlist.dll
	mcs -target:exe -out:$@ \
		$(addprefix -reference:,$(filter %.dll,$^)) \
		$(filter %.cs,$^)

genlist.dll : genlist.cs
	mcs -target:library -out:$@ $<

clean:
	$(RM) *.exe *.dll [Oo]ut* log*
