DIR = $(HOME)/repos/ppnm/matlib
GEN = $(HOME)/repos/ppnm/exercises/generic

all:Err.svg qrnd.svg 

Out.txt: main.exe
	mono $< > $@

matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs Monte_Carlo.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<

plot.data: main.exe
	rm -f plot.data
	for N in $$(seq 10000 100000 1000000); do \
		mono main.exe -N:$$N -plot:true  >> $@ ;\
	done

qrnd.data: main.exe
	for N in $$(seq 10000 100000 1000000); do \
                mono main.exe -N:$$N -bpart:true  >> $@ ;\
        done

Err.svg: err.gpi plot.data
	gnuplot < $<

qrnd.svg: qrnd.gpi qrnd.data
	gnuplot < $<

clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par


