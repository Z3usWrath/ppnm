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
	echo "set terminal svg \n\
		set output '$(patsubst %.gpi,%.svg,$@)' \n\
		set key top right \n\
		set title 'Bi linear splines of F' \n\
		set xlabel 'x' \n\
		set ylabel 'y' \n\
		set zlabel 'z' \n\
		set xzeroaxis \n\
		set yzeroaxis \n\
		set zzeroaxis \n\
		set samples 1600 \n\
		set dgrid3d 10,10 \n\
		set hidden3d \n\
		splot 'plot.data' using (\$$1):(\$$2):(\$$3) index 0 with lines title 'Linearly Interpulated points' \
		,1/(x**2+y**2+1.0) with lines title 'The chosen function' \
		, 'plot.data' using (\$$1):(\$$2):(\$$3) index 0 with lines title 'Graph' \
		" > $@


matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(GEN)/genlist.cs splines.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<

clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par *.gpi


