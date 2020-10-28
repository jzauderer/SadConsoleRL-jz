using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SadConsole;

namespace SadConsoleRL
{
    //TileBase is an abstract base class
    //representing the most basic form of all Tiles used
    public abstract class TileBase : Cell
    {
        //Movement and Line of Sight Flags
        protected bool IsBlockingMove;
        protected bool IsBlockingLOS;

        //Tile's name
        protected string Name;

        //Default Constructor
        public TileBase(Color foreground, Color background, int glyph, bool blockingMove = false, bool blockingLOS = false, String name = "") : base(foreground, background, glyph)
        {
            IsBlockingMove = blockingMove;
            IsBlockingLOS = blockingLOS;
            Name = name;
        }


    }
}
