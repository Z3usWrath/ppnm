DIR = $(HOME)/repos/ppnm/Homework/lineq


matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS.cs fit.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:main.exe $(addprefix -reference:,$(filter %.dll,$^)) $<












clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par

