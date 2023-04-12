DIR = $(HOME)/repos/ppnm/Homework/lineq


LS.svg : least_squares.gpi fit.data fit_raw.data
	gnuplot $<

fit.data : main.exe
	mono $< -x:1,2,3,4,6,9,10,13,15 -y:117,100,88,72,53,29.5,25.2,15.2,11.1 -dy:5,5,5,4,4,3,3,2,2 -start:0 -end:16 > $@

fit_raw.data : Makefile
	>$@
	echo "1 117 5" >>$@
	echo "2 117 5" >>$@
	echo "3 88 5" >>$@
	echo "4 72 4" >>$@
	echo "6 53 4" >>$@
	echo "9 29.5 3" >>$@
	echo "10 25.2 3" >>$@
	echo "13 15.2 2" >>$@
	echo "15 11.1 2" >>$@


matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS.cs fit.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<

clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par

