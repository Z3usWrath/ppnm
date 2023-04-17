DIR = $(HOME)/repos/ppnm/Homework/lineq

all: plot.svg Out.txt 

plot.svg: N3.gpi out.times.data start.par
	gnuplot $<

Out.txt: main.exe
	mono $< > $@

matlib.dll: matrix.cs vector.cs QRGS.cs
	mcs -target:library -out:$@ $^

out.times.data : time.exe matlib.dll start.par
	for N in $$(seq 400 50 1000); do \
    		time --format "$$N %e" --output out.times.data --append \
    		mono time.exe -m:$$N -n:$$N > /dev/null 2>&1 ;\
	done

main.exe: main.cs matlib.dll
	mcs -target:exe -out:main	.exe $(addprefix -reference:,$(filter %.dll,$^)) $<

time.exe: time.cs matlib.dll
	mcs -target:exe -out:time.exe $(addprefix -reference:,$(filter %.dll,$^)) $<
	
clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par

