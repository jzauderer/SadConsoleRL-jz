using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SadConsoleRL
{
    //TileFloor is based on TileBase
    //Floor tiles to be used in maps
    class TileFloor :TileBase
    {
        //Default constructor
        //Floors allow movement and line of sight by default
        //and have a dark gray foreground and a transparent background
        //represented by the . symbol
        public TileFloor(bool blocksMovement = false, bool blocksLOS = false) : base(Color.DarkGray, Color.Transparent, '.', blocksMovement, blocksLOS)
        {
            Name = "Floor";
        }
    }
}
