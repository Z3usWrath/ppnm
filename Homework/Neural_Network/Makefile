DIR = $(HOME)/repos/ppnm/matlib
GEN = $(HOME)/repos/ppnm/exercises/generic

all: Out.txt

Out.txt: main.exe
	mono $< > $@

for_ODE.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(GEN)/genlist.cs
	mcs -target:library -out:$@ $^

matlib.dll: $(DIR)/matrix.cs $(DIR)/vector.cs 
	mcs -target:library -out:$@ $^

ODE.dll: $(DIR)/matrix.cs $(DIR)/vector.cs $(GEN)/genlist.cs $(DIR)/QRGS.cs $(DIR)/ODE.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs ODE.dll
	mcs -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^)) $<

clean:
	$(RM) *.exe *.dll *log [Oo]ut* *.data *.svg *.par

