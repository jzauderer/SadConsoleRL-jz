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
        private static SadConsole.Entities.Entity player;

        static void Main(string[] args)
        {
            // Setup the engine and creat the main window.
            SadConsole.Game.Create(Width, Height);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;

            // Start the game.
            SadConsole.Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //

            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime time)
        {
            //Arrows for movement
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                player.Position += new Point(0, -1);
            }
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                player.Position += new Point(0, 1);
            }
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                player.Position += new Point(-1, 0);
            }
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                player.Position += new Point(1, 0);
            }
        }

        private static void Init()
        {
            // Any custom loading and prep. We will use a sample console for now

            Console startingConsole = new Console(Width, Height);
            

            // Set our new console as the thing to render and process
            SadConsole.Global.CurrentScreen = startingConsole;

            CreatePlayer();
            startingConsole.Children.Add(player);
        }

        //Create a player using SadConsole's Entity class
        private static void CreatePlayer()
        {
            player = new SadConsole.Entities.Entity(1, 1);
            player.Animation.CurrentFrame[0].Glyph = '@';
            player.Animation.CurrentFrame[0].Foreground = Color.HotPink;
            player.Position = new Point(20, 10);
        }
    }
}