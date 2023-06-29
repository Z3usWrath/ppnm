DIR = $(HOME)/repos/ppnm/matlib
GEN = $(HOME)/repos/ppnm/exercises/generic

all: Out.txt plot.svg

plot.data : main.exe
	mono $< > $@

Out.txt: main.exe
	mono $< > $@

plot.svg : plot.gpi plot.data
	gnuplot < $<

plot.gpi :
	echo 	"set terminal svg \n\
		set output '$(patsubst %.gpi,%.svg,$@)' \n\
		set key top right \n\
		set title 'Bi linear splines of F' \n\
		set xlabel 'x' \n\
		set ylabel 'y' \n\
		set zlabel 'f' \n\
		set xzeroaxis \n\
		set yzeroaxis \n\
		set zzeroaxis \n\
		set samples 1600 \n\
		set dgrid3d 30,30 \n\
		set ticslevel 0 \n\
		set hidden3d \n\
		splot 'plot.data' using (\$$1):(\$$2):(\$$3) index 0 with point pointtype 4 title 'Linearly Interpulated points',\
		'plot.data' using (\$$1):(\$$2):(\$$3) index 0 with point pointtype 4 title 'Linearly Interpulated points',\
		1/(x**2+y**2+1) title 'the func' \n\
		" > $@


matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(GEN)/genlist.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<

clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par *.gpi


