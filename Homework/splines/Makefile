DIR = $(HOME)/repos/ppnm/matlib

plot.svg: plot.gpi plot.data
	gnuplot < $<

plot.data : main.exe
	mono $< > $@

Out.txt : main.exe
	mono $< > $@

matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs splines.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<



clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par

