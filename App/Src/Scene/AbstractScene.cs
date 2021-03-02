using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.App.Scene
{
    public delegate AbstractScene SceneFactory(object args);
    public abstract class AbstractScene
    {
        public SceneManager sceneManager { get; set; }

        public virtual void BeforeAttach() {

        }

        public virtual void AfterAttach() {

        }

        public virtual void Update(GameTime gameTime) {

        }

        public virtual void Draw(SpriteBatch spriteBatch) {

        }
    }
}