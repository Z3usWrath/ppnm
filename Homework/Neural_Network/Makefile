DIR = $(HOME)/repos/ppnm/matlib
GEN = $(HOME)/repos/ppnm/exercises/generic

all: Out.txt plot.svg

Out.txt: main.exe
	mono $< > $@

plot.data : main.exe
	mono $< > $@

plot.svg : plot.gpi plot.data
	gnuplot < $<

plot.gpi :
	echo "set terminal svg \n\
	set output '$(patsubst %.gpi,%.svg,$@)' \n\
	set key bottom right \n\
	set title 'ANN Interpulation on Cos(5x-1)Exp(-x^2)' \n\
	set multiplot layout 2,2 \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set xzeroaxis \n\
	set yzeroaxis \n\
	set samples 1600 \n\
	plot 'plot.data' using (\$$1):(\$$3) index 0 with lines title 'Cos(5x-1)Exp(-x^2)' \
	, 'plot.data' using (\$$1):(\$$4) index 0 with lines title 'ANN before training' \
	, 'plot.data' using (\$$1):(\$$2) index 0 with lines title 'ANN after training' \n\
	set ylabel 'y'' \n\
	set title \n\
	plot 'plot.data' using (\$$1):(\$$5) index 0 with lines title 'Analytic result' \
	, 'plot.data' using (\$$1):(\$$6) index 0 with lines title 'ANN result' \n\
	set ylabel 'y″' \n\
	plot 'plot.data' using (\$$1):(\$$10) index 0 with lines title 'Analytic result' \
	, 'plot.data' using (\$$1):(\$$9) index 0 with lines title 'ANN result' \n\
	set ylabel '∫ydx (From 0 to x)' \n\
	plot 'plot.data' using (\$$1):(\$$7) index 0 with lines title 'ANN result' \
	, 'plot.data' using (\$$1):(\$$8) index 0 with lines title 'Numerical result' \
	" >$@

matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs 
	mcs -target:library -out:$@ $^

ODE.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(GEN)/genlist.cs $(DIR)/QRGS.cs $(DIR)/ODE.cs $(DIR)/Mini.cs $(DIR)/Integral.cs ann.cs 
	mcs -target:library -out:$@ $^

main.exe: main.cs ODE.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<

clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par

