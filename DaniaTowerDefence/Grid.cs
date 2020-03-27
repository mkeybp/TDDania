using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DaniaTowerDefence
{
    public class Grid : GameObject
    {
        //public static List<Location> openList;

        //private int lowest;
        //private List<Location> adjacentSquares;
        //private static List<Location> proposedLocations;

        public Vector2 currentPosition;


        ////#region Full Grid
        //public static int[,] grid = new int[11, 9]
        //       {    
        //     // D i DANIA
        //      // Øverst venstre
        //      {1, 1, 1, 1, 1, 1, 1, 1, 1}, // Nederst venstre
        //      {0, 0, 0, 0, 0, 0, 0, 0, 1},
        //      {0, 1, 1, 1, 1, 1, 1, 0, 1},
        //      {0, 0, 1, 1, 1, 1, 1, 0, 1},
        //      {1, 0, 0, 1, 1, 1, 1, 0, 1},
        //      {1, 1, 0, 0, 1, 1, 1, 0, 1},
        //      {1, 1, 1, 0, 0, 1, 1, 0, 1},
        //      {1, 1, 1, 1, 0, 0, 1, 0, 1},
        //      {1, 1, 1, 1, 1, 0, 0, 0, 1},
        //      {1, 1, 1, 1, 1, 1, 0, 0, 1},
        //      {1, 1, 1, 1, 1, 1, 1, 0, 1}, // Nederst højre
        //                                   // Øverst højre
        //       };
        #region Full Grid

        public static int[,] grid = new int[,]
        {    
             // D i DANIA
              // Øverst venstre
              {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // Nederst venstre
              {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1},
              {0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
              {0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1},
              {1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1},
              {1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1}, // Nederst højre
              // Øverst højre

              // A i DANIA
              // Øverst venstre
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1}, // Nederst venstre
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1},
              {1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1},
              {1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1},
              {1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1}, // Nederst højre
              // Øverst højre

              // N i DANIA
              // Øverst venstre
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1}, // Nederst venstre
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1},
              {1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1},
              {1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1},
              {1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1},
              {1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
              {1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1},
              {1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1},
              {1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1}, // Nederst højre
              // Øverst højre

               // I i DANIA
              // Øverst venstre
              {1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1}, // Nederst venstre
              {1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1},
              {1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1},
              {1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1},
              {1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1},
              {1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1},
              {1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1},
              {1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
              {0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1},
              {1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1}, // Nederst højre
              // Øverst højre

                       // A i DANIA
              // Øverst venstre
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1}, // Nederst venstre
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1},
              {1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1},
              {1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1},
              {1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1},
              {1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1},
              {1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1}, // Nederst højre
              // Øverst højre

    };
        #endregion Full Grid



        private int lowest;
        private List<Location> adjacentSquares;
        private static List<Location> proposedLocations;

     


        public void Pathfinding()
        {
         
            // algorithm

            Location current = null;
            // X and Y is cooordinates (ints from the Location class)
            Location.start = new Location { X = 1, Y = 3 };
            Location.target = new Location { X = 7, Y =  7 };
            Location.openList = new List<Location>();
            Location.closedList = new List<Location>();
            int g = 0;

            // start by adding the original position to the open list
            Location.openList.Add(Location.start);

            while (Location.openList.Count > 0)
            {
                // get the square with the lowest F score
                lowest = Location.openList.Min(l => l.F);
                current = Location.openList.First(l => l.F == lowest);

                // add the current square to the closed list
                Location.closedList.Add(current);

                // show current square on the map
                currentPosition = new Vector2(current.X, current.Y);
                // Student
                Debug.WriteLine(current.X);
                Debug.WriteLine(current.Y);
                //Console.SetCursorPosition(current.X, current.Y);
                //System.Threading.Thread.Sleep(1000);

                // remove it from the open list
                Location.openList.Remove(current);

                // if we added the destination to the closed list, we've found a path
                if (Location.closedList.FirstOrDefault(l => l.X == Location.target.X && l.Y == Location.target.Y) != null)
                    break;

                adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, grid);
                g++;


                foreach (var adjacentSquare in adjacentSquares)
                {
                    // if this adjacent square is already in the closed list, ignore it
                    if (Location.closedList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) != null)
                        continue;

                    // if it's not in the open list...
                    if (Location.openList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) == null)
                    {
                        // compute its score, set the parent
                        adjacentSquare.G = g;
                        adjacentSquare.H = ComputeHScore(adjacentSquare.X, adjacentSquare.Y, Location.target.X, Location.target.Y);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.Parent = current;

                        // and add it to the open list
                        Location.openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g + adjacentSquare.H < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }

            // assume path was found; let's show it
            while (current != null)
            {
                //Console.SetCursorPosition(current.X, current.Y);
                //Console.Write('_');
               

                current = current.Parent;
                //System.Threading.Thread.Sleep(1000);
            }

            // end

        }

        static List<Location> GetWalkableAdjacentSquares(int x, int y, int[,] map)
        {
            proposedLocations = new List<Location>()
            {
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
            };
            // Makes the student only walking where there is a '1'
            // Where => gridTexture != 0
            return proposedLocations.Where(l => map[l.Y, l.X] == 0 || map[l.Y, l.X] == 2).ToList();
        }

        static int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }

        public override void LoadContent(ContentManager content)
        {


        }

        public override void Update(GameTime gameTime)
        {
            //DrawMap();

        }


    }
}
