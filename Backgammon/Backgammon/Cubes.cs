using System;

namespace Backgammon
{
    public class Cubes
    {
        public int cube1 { get; private set; }
        public int cube2 { get; private set; }

        public  void getNewCubes()
        {
            Random rand = new Random();
            cube1 = rand.Next(6) + 1;
            cube2 = rand.Next(6) + 1;
        }

    }
}