using System;
using System.IO;

namespace CanvasApp {

  /*
  Canvas for plotting and writing PPM (P3) files.

  Origin is at bottom left corner, which is dependant solely on the WriteFile method
  */

  class Canvas {

    /* public instance vars */
    public int[,,] Grid { get; }
    public int Width { get; }
    public int Height { get; }

    /* constructors */
    public Canvas() {
      // default width and height (500x500)
      this.Width = 500;
      this.Height = 500;
      this.Grid = new int[500,500,3];
      // default background color is white
      int x, y, z;
      for (y = 0; y < 500; y++) {
        for (x = 0; x < 500; x++) {
          for (z = 0; z < 3; z++) {
            this.Grid[x,y,z] = 255;
          }
        }
      }
    }
    public Canvas(int w, int h) {
      Width = w;
      Height = h;
      Grid = new int[w,h,3];
      // default background color is white
      int x, y, z;
      for (y = 0; y < h; y++) {
        for (x = 0; x < w; x++) {
          for (z = 0; z < 3; z++) {
            this.Grid[x,y,z] = 255;
          }
        }
      }
    }
    public Canvas(int w, int h, int[] color) {
      Width = w;
      Height = h;
      Grid = new int[w,h,3];
      // default background color is white
      int x, y, z;
      for (y = 0; y < h; y++) {
        for (x = 0; x < w; x++) {
          for (z = 0; z < 3; z++) {
            this.Grid[x,y,z] = color[z];
          }
        }
      }
    }

    /* public methods */
    public void WriteFile(string filename) {
      using (StreamWriter sw = new StreamWriter(filename)) {
        // file setup
        sw.WriteLine(String.Format("P3 {0} {1} 255\n", Width, Height));

        int y, x;
        for (y = Height - 1; y >= 0; y--) {
          for (x = 0; x < Width; x++) {
            sw.WriteLine(String.Format("{0} {1} {2}\n", Grid[y,x,0], Grid[y,x,1], Grid[y,x,2]));
          }
        }
      }
    } // end WriteFile method

    public void Plot(int x, int y, int[] color) {
      Grid[y,x,0] = color[0];
      Grid[y,x,1] = color[1];
      Grid[y,x,2] = color[2];
    } // end Plot method

    public void DrawLine(int x0, int y0, int x1, int y1, int[] color) {
      Console.WriteLine("starting drawLine");

      // if x0 > x1, swap (x0, y0) and (x1, y1) to move line in right octants
      if (x0 > x1) {
        int tempX, tempY;

        tempX = x0;
        x0 = x1;
        x1 = tempX;

        tempY = y0;
        y0 = y1;
        y1 = tempY;
      }

      int x = x0;
      int y = y0;

      int A = y1 - y0;
      int B = -1 * (x1 - x0);

      // octant 1
      // if the line has a positive slope and dy <= dx
      if (A >= 0 && A <= -B) {
        Console.WriteLine("Octant 1/5");
        int d = A + A + B;
        while (x <= x1) {
          Console.WriteLine(String.Format("d: {0}", d));
          this.Plot(x, y, color);
          if (d > 0) {
            y++;
            d += B + B;
          }
          x++;
          d += A + A;
        }
      }
      // octant 2
      // if the line has a positive slope and dy > dx
      else if (A > 0 && A > -B) {
        int d = A + B + B;
        Console.WriteLine("Octant 2/6");
        while (y <= y1) {
          Console.WriteLine(String.Format("d: {0}", d));
          this.Plot(x, y, color);
          if (d < 0) {
            x++;
            d += A + A;
          }
          y++;
          d += B + B;
        }
        // Console.WriteLine(String.Format("x: {0}\ny: {1}", x, y));
      }
      // octant 7
      else if (A < 0 && A <= B) {
        int d = A - (B + B);
        Console.WriteLine("Octant 3/7");
        while (y >= y1) {
          Console.WriteLine(String.Format("d: {0}", d));
          this.Plot(x, y, color);
          if (d > 0) {
            x++;
            d += A + A;
            // Console.WriteLine(String.Format("d: {0}", d));
          }
          y--;
          d -= (B + B);
          // Console.WriteLine(String.Format("d: {0}", d, y));
          // Console.WriteLine("\n\n");
        }
      }
      // octant 8
      else if (A < 0 && A > B) {
        int d = A + A - B;
        Console.WriteLine("Octant 4/8");
        while (x <= x1) {
          Console.WriteLine(String.Format("d: {0}", d));
          this.Plot(x, y, color);
          // Console.WriteLine(String.Format("d: {0}", d));
          if (d > 0) {
            y--;
            d += B + B;
            // Console.WriteLine(String.Format("d: {0}", d));
          }
          x++;
          d -= (A + A);
          // Console.WriteLine(String.Format("d: {0}", d, y));
          // Console.WriteLine("\n\n");
        }
      }
      else {
        Console.WriteLine("This ain't even a line");
      }

    } // end DrawLine method
  } // end Canvas class
} // end CanvasApp namespace
