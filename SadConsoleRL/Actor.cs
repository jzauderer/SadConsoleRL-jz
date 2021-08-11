using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SadConsoleRL
{
    public abstract class Actor : SadConsole.Entities.Entity
    {
        private int _health; //current health
        private int _maxHealth; //maximum possible health

        public int Health { get { return _health; } set { _health = value; }} //public getter for current health
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; }} //public getter for max health

        protected Actor(Color foreground, Color background, int glyph, int width = 1, int height = 1) : base(width, height)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

        //Moves the Actor BY positionChange tiles in any X/Y direction
        //returns true if actor was able to move, false if failed to move
        public bool MoveBy(Point positionChange)
        {
            //Check if this position is valid
            if(GameLoop.GameMap.IsTileWalkable(Position + positionChange))
            {
                Position += positionChange;
                return true;
            }
            return false;
        }

        //Moves the Actor TO newPosition location
        //returns true if actor was able to move, false if failed to move
        public bool MoveTo(Point newPosition)
        {
            Position = newPosition;
            return true;
        }
    }
}
