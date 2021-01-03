using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SadConsoleRL
{
    //Creates a new player
    //Default glyph is @
    public class Player : Actor
    {
        public Player(Color foreground, Color background) : base(foreground, background, '@')
        {

        }
    }
}
