DIR = $(HOME)/repos/ppnm/Homework/lineq

all : Out.txt plot.svg

Out.txt: main.exe
	mono $< > $@

matlib.dll: matrix.cs vector.cs QRGS.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:main.exe $(addprefix -reference:,$(filter %.dll,$^)) $<

start.par : #Setting initial parameters 
	>$@
	echo "A = 1 \nC = 0.1" >> $@

plot.svg : N3.gpi out.times.data start.par 
	gnuplot $<

out.times.data : main.exe
	>$@
	for N in $$(seq 100 20 200); do \
		time --format "$$N %e" --output $@ --append \
		mono $< -size:$$N 1>out 2>err ;\
	done

clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par

