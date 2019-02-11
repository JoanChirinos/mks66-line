using System;
using System.IO;

using CanvasApp;

namespace LineMakerApp {
  class LineMaker {

    static void Main() {
      Canvas c = new Canvas(500, 500);
      int x, y;

      for (x = 0; x < 500; x += 4) {
        c.DrawLine(0, 0, x, 499, new int[3] {x / 4, 0, 0});
      }
      for (y = 499; y >= 0; y -= 4) {
        c.DrawLine(0, 0, 499, y, new int[3] {(1000 - y) / 4, 0, 0});
      }

      /********** TEST CASES **********/
      /*

      // black lines for now
      int[] color = {0, 0, 0};

      // octant 1
      c.DrawLine(250, 250, 450, 350, color);

      // octant 2
      c.DrawLine(250, 250, 350, 450, color);

      // octant 3
      c.DrawLine(250, 250, 150, 450, color);

      // octant 4
      c.DrawLine(250, 250, 50, 350, color);

      // octant 5
      c.DrawLine(250, 250, 50, 150, color);

      // octant 6
      c.DrawLine(250, 250, 150, 50, color);

      // octant 7
      c.DrawLine(250, 250, 350, 50, color);

      // octant 8
      c.DrawLine(250, 250, 450, 150, color);

      // slope 1, x0 < x1
      c.DrawLine(250, 250, 450, 450, color);

      // slope 1, x1 < x0
      c.DrawLine(250, 250, 450, 50, color);

      // slope -1, x0 < x1
      c.DrawLine(250, 250, 50, 450, color);

      // slope -1, x1 < x0
      c.DrawLine(250, 250, 50, 50, color);

      // slope 0, x0 < x1
      c.DrawLine(250, 250, 450, 250, color);

      // slope 0, x1 < x0
      c.DrawLine(50, 250, 250, 250, color);

      // slope undefined, y0 < y1
      c.DrawLine(250, 250, 250, 450, color);

      // slope undefined, y1 < y0
      c.DrawLine(250, 250, 250, 50, color);

      // c.Plot(250, 251, new int[3] {255, 0, 0});
      */

      c.WriteFile("line.ppm");

    } // end Main method
  } // end LineMaker class
} // end LineMakerApp namespace
