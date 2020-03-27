using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace DaniaTowerDefence
{
    public class Location
    {
        public int X;
        public int Y;
        // Nodes
        public int F;
        public int G;
        public int H;

        public Location Parent;

        public static Location start;
        public static Location target;
        public static List<Location> closedList;
        public static List<Location> openList;

    }
}

