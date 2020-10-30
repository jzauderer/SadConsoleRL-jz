using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SadConsoleRL
{
    class RoomGen
    {
        public static TileBase[] _tiles; //an array of TileBase that contains all the tiles for a map
        public int _roomWidth;
        public int _roomHeight;
        public int _floorWidth;
        public int _floorHeight;

        public RoomGen(int width, int height, int floorWidth, int floorHeight)
        {
            _roomWidth = width;
            _roomHeight = height;
            _floorWidth = floorWidth;
            _floorHeight = floorHeight;
        }

        public void init()
        {
            CreateWalls();
            CreateFloors();
        }

        //Carve out a rectangular floor using the TileFloors class
        private void CreateFloors()
        {
            for(int x = 0; x < _roomWidth; x++)
            {
                for(int y = 0; y < _roomHeight; y++)
                {
                    //Calculates the appropriate index in the array
                    //based on the y of tile, width of map, and x of tile
                    _tiles[y * _roomWidth + x] = new TileFloor();
                }
            }
        }

        //Fill the map with walls using the TileWall class
        private void CreateWalls()
        {
            //Create an empty array of tiles that is equal to the map size
            _tiles = new TileBase[_floorWidth * _floorHeight];

            //Fill the entire tile array with walls
            for(int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new TileWall();
            }
        }
    }
}
