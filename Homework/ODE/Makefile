DIR = $(HOME)/repos/ppnm/matlib
GEN = $(HOME)/repos/ppnm/exercises/generic

all: plot_a.svg plot_b.svg

plot_a.svg: plot_a.gpi plot.data
	gnuplot < $<

plot_b.svg: plot_b.gpi plot.data
	gnuplot < $<

for_ODE.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(GEN)/genlist.cs
	mcs -target:library -out:$@ $^

matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:$@ $^

ODE.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(GEN)/genlist.cs ODE.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs ODE.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<

plot.data: main.exe
	mono $< >$@


clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par


