using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SadConsoleRL
{
    class GameLoop
    {
        public const int Width = 80;
        public const int Height = 25;
        private static Player player;
        private static Map Map = new Map(Width, Height);

        static void Main(string[] args)
        {
            SadConsole.Game.Create(Width, Height);
            
            SadConsole.Game.OnInitialize = Init;
            
            SadConsole.Game.OnUpdate = Update;
            
            SadConsole.Game.Instance.Run();

            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime time)
        {
            CheckKeyboard();
        }

        private static void Init()
        {
            Console startingConsole = new ScrollingConsole(Width, Height, Global.FontDefault, new Rectangle(0, 0, Map.Width, Map.Height), Map.Tiles);
            
            // Set our new console as the thing to render and process
            SadConsole.Global.CurrentScreen = startingConsole;
            

            CreatePlayer();
            startingConsole.Children.Add(player);
        }

        //Create a player using the Player class
        //and set its starting position
        private static void CreatePlayer()
        {
            player = new Player(Color.Yellow, Color.Transparent);
            player.Position = new Point(5, 5);
        }

        //Scans the SadConsole's Global KeyboardState and triggers behaviour
        //based on the button pressed
        private static void CheckKeyboard()
        {
            //F5 to fullscreen
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }

            //Arrows for movement
            //Move up 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                player.MoveBy(new Point(0, -1));
            }
            //Move down 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                player.MoveBy(new Point(0, 1));
            }
            //Move left 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                player.MoveBy(new Point(-1, 0));
            }
            //Move right 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                player.MoveBy(new Point(1, 0));
            }
        }
    }
}