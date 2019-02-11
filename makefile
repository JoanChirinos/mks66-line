all:
	csc Line.cs Canvas.cs
	mono Line.exe

clean:
	-rm -f *.exe *.ppm *.png
