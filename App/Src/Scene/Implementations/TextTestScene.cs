using Client.App.Asset;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.App.Scene
{
    public class TextTestScene: AbstractScene
    {
        public static SceneFactory Factory = (object args) => new TextTestScene();
        public SpriteFont Font { get; set; }
        public TextTestScene() {
            Font = AssetRepository.Fonts["dot-gothic-16"];
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(Font, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut mollis.", Vector2.Zero, Color.White);
        }
    }
}