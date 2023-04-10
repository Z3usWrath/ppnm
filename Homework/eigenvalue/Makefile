DIR = $(HOME)/repos/ppnm/matlib

waveFunc.svg : waveplot.gpi wave.data
	gnuplot < $<

Convergence.svg : rmaxConvergence.gpi rmaxConv.data drConv.data
	gnuplot < $<

rmaxConv.data : Hyd_Sim.exe
	> $@
	for N in $$(seq 0.2 0.2 20); do \
		mono $< -rmax:$$N -dr:0.1 >> $@;\
	done

drConv.data : Hyd_Sim.exe
	> $@
	for N in $$(seq 0.05 0.05 1); do \
		mono $< -rmax:5 -dr:$$N >> $@;\
	done

wave.data: Hyd_Sim.exe
	mono $< -dr:0.1 -rmax:5 -waveOut:True >$@

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

