using System;
using Client.App.Info;
using Client.App.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.App.Scene
{
    public class MenuScene: AbstractScene
    {
        public static SceneFactory Factory = (object args) => new MenuScene();
        public Texture2D Title { get; private set; }
        public Button Connect { get; set; }
        public Button Quit { get; set; }

        public MenuScene()
        {
            Connect = new Button {
                Text = "connect to server",
                OnClick = () => {
                    Console.WriteLine("Connect to server not implemented.");
                }
            };
            Connect.Position = (Screen.Size - Connect.Size) / 2;
            Quit = new Button {
                Text = "quit",
                OnClick = () => {
                    MUWClient.ShouldExit = true;
                }
            };
            Quit.Position = (Screen.Size - Quit.Size) / 2 + new Vector2(0, 32);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Connect.Update(gameTime);
            Quit.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch) {
            // spriteBatch.Draw(Title, (Screen.Size - Title.Bounds.Size.ToVector2())/2, Color.White);
            Connect.Draw(spriteBatch);
            Quit.Draw(spriteBatch);
            
        }
    }
}
