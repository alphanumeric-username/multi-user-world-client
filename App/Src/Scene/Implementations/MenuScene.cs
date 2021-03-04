using Client.App.Info;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.App.Scene
{
    public class MenuScene: AbstractScene
    {
        public static SceneFactory Factory = (object args) => new MenuScene();
        public Texture2D Title { get; private set; }
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Title, (Screen.Size - Title.Bounds.Size.ToVector2())/2, Color.White);
        }
    }
}