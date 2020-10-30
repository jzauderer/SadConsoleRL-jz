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
        private static RoomGen roomGen = new RoomGen(10, 20, Width, Height);

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
            //Create walls and floors
            roomGen.init();

            Console startingConsole = new ScrollingConsole(Width, Height, Global.FontDefault, new Rectangle(0, 0, roomGen._roomWidth, roomGen._roomHeight), RoomGen._tiles);
            
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