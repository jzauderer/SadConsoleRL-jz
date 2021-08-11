﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SadConsoleRL
{
    // based on tunnelling room generation algorithm
    // from RogueSharp tutorial
    // https://roguesharp.wordpress.com/2016/03/26/roguesharp-v3-tutorial-simple-room-generation/
    public class MapGenerator
    {
        public MapGenerator()
        {
        }

        Map _map; //Temporarily store the map currently worked on

        public Map GenerateMap(int mapWidth, int mapHeight, int maxRooms, int minRoomSize, int maxRoomSize)
        {
            _map = new Map(mapWidth, mapHeight);

            Random randNum = new Random();

            List<Rectangle> Rooms = new List<Rectangle>();

            //create up to (maxRooms) rooms on the map
            //and make sure they do not overlap with each other
            for (int i = 0; i < maxRooms; i++)
            {
                //set the rooms (width, height) as a random size between (minRoomSize, maxRoomSize)
                int newRoomWidth = randNum.Next(minRoomSize, maxRoomSize);
                int newRoomHeight = randNum.Next(minRoomSize, maxRoomSize);

                //sets the room's X/Y position at a random point between the edges of the map
                int newRoomX = randNum.Next(0, mapWidth - newRoomWidth - 1);
                int newRoomY = randNum.Next(0, mapHeight - newRoomHeight - 1);

                //create a rectangle representing the room's perimeter
                Rectangle newRoom = new Rectangle(newRoomX, newRoomY, newRoomWidth, newRoomHeight);

                //check if it intersects with any existing rooms
                bool newRoomIntersects = Rooms.Any(room => newRoom.Intersects(room));

                if (!newRoomIntersects)
                {
                    Rooms.Add(newRoom);
                }
            }

            //begin by flooding the map with walls
            FloodWalls();

            //carve out the rooms from the walls
            foreach (Rectangle room in Rooms)
            {
                CreateRoom(room);
            }

            //return final map
            return _map;
        }

        //Builds a room of walls and floors using the given Rectangle
        private void CreateRoom(Rectangle room)
        {
            //Place floors in interior area
            for(int x = room.Left+1; x < room.Right-1; x++)
            {
                for(int y = room.Top+1; y <room.Bottom-1; y++)
                {
                    CreateFloor(new Point(x, y));
                }
            }

            //Place walls at perimeter
            List<Point> perimeter = GetBorderCellLocations(room);
            foreach(Point location in perimeter)
            {
                CreateWall(location);
            }
        }

        //Creates a Floor tile at specified point
        private void CreateFloor(Point location)
        {
            _map.Tiles[location.ToIndex(_map.Width)] = new TileFloor();
        }

        //Creates a Wall tile at specified point
        private void CreateWall(Point location)
        {
            _map.Tiles[location.ToIndex(_map.Width)] = new TileWall();
        }

        //Fills the map with walls
        private void FloodWalls()
        {
            for(int i = 0; i < _map.Tiles.Length; i++)
            {
                _map.Tiles[i] = new TileWall();
            }
        }

        //Returns a list of points expressing the perimeter of the given Rectangle
        private List<Point> GetBorderCellLocations(Rectangle room)
        {
            //establish room boundaries
            int xMin = room.Left;
            int xMax = room.Right;
            int yMin = room.Top;
            int yMax = room.Bottom;

            //build a list of room border tiles using
            //a series of straight lines
            List<Point> borderCells = GetTileLocationsAlongLine(xMin, yMin, xMax, yMin).ToList();
            borderCells.AddRange(GetTileLocationsAlongLine(xMin, yMin, xMin, yMax));
            borderCells.AddRange(GetTileLocationsAlongLine(xMin, yMax, xMax, yMax));
            borderCells.AddRange(GetTileLocationsAlongLine(xMax, yMin, xMax, yMax));

            return borderCells;
        }

        //returns a collection of Points
        //which represent locations along a line
        public IEnumerable<Point> GetTileLocationsAlongLine(int xOrigin, int yOrigin, int xDestination, int yDestination)
        {
            //prevent line from overflowing
            //boundaries of the map
            xOrigin = ClampX(xOrigin);
            yOrigin = ClampY(yOrigin);
            xDestination = ClampX(xDestination);
            yDestination = ClampY(yDestination);

            int dx = Math.Abs(xDestination - xOrigin);
            int dy = Math.Abs(yDestination - yOrigin);

            int sx = xOrigin < xDestination ? 1 : -1;
            int sy = yOrigin < yDestination ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                yield return new Point(xOrigin, yOrigin);
                if (xOrigin == xDestination && yOrigin == yDestination)
                    break;

                int e2 = 2 * err;
                if(e2 > -dy)
                {
                    err = err - dy;
                    xOrigin = xOrigin + sx;
                }
                if(e2 < dx)
                {
                    err = err + dx;
                    yOrigin = yOrigin + sy;
                }
            }
        }

        //sets X coordinate between right and left edges
        //of map to prevent out-of-bounds errors
        private int ClampX(int x)
        {
            if (x < 0)
                x = 0;
            else if (x > _map.Width - 1)
                x = _map.Width - 1;
            return x;
        }

        //sets Y coordinate between top and bottom
        //edges of map to prevent out-of-bounds errors
        private int ClampY(int y)
        {
            if (y < 0)
                y = 0;
            else if (y > _map.Height - 1)
                y = _map.Height - 1;
            return y;
        }
    }
}
