using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SadConsoleRL
{
    //Stores, manipulates, and queries Tile data
    public class Map
    {
        TileBase[] _tiles; //an array of TileBase that contains all the tiles for a map
        private int _width;
        private int _height;

        public TileBase[] Tiles { get { return _tiles; } set { _tiles = value; } }
        public int Width { get { return _width; } set { _width = value; } }
        public int Height { get { return _height; } set { _height = value; } }

        public Map(int width, int height)
        {
            _width = width;
            _height = height;
            _tiles = new TileBase[width * height];
        }

        //IsTileWalkable checks to see if the actor has tried
        //to walk off the map or into a non-walkable tile
        //Returns true if tile is walkable
        //false if tile is not walkable or is off-map
        public bool IsTileWalkable(Point location)
        {
            //first make sure that actor isn't trying to move off-map
            if (location.X < 0 || location.Y < 0 || location.X >= Width || location.Y >= Height)
                return false;
            //then return whether the tile is walkable
            return !_tiles[location.Y * Width + location.X].IsBlockingMove;
        }
    }
}
