DIR = $(HOME)/repos/ppnm/matlib

waveFunc.svg : waveplot.gpi wave.data
	gnuplot < $<

wave.data: Hyd_Sim.exe
	mono $< -dr:0.1 -rmax:15 >$@

Out.txt: main.exe
	mono $< > $@

matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs jacobi.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:main.exe $(addprefix -reference:,$(filter %.dll,$^)) $<

Hyd_Sim.exe: Hyd_Sim.cs matlib.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<

clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par

