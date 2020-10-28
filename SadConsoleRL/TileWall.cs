using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace SadConsoleRL
{
    //TileWall is based on TileBase
    class TileWall : TileBase
    {
        //Default constructor
        //Walls block movement and line of sight by default
        //and have a light gray foreground and a transparent background
        //represented by the # symbol
        public TileWall(bool blocksMovement = true, bool blocksLOS = true) : base(Color.LightGray, Color.Transparent, '#', blocksMovement, blocksLOS)
        {
            Name = "Wall";
        }
    }
}
