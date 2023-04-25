DIR = $(HOME)/repos/ppnm/matlib
GEN = $(HOME)/repos/ppnm/exercises/generic

all: plot_err_func.svg Out.txt	

Out.txt: main.exe
	mono $< > $@

matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs Integral.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<

plot.data: main.exe
	mono $< -plot:false > $@

plot_err_func.svg: erf.gpi plot.data
	gnuplot < $<


clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par


