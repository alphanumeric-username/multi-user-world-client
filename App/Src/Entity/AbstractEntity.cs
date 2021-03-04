using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.App.Entity
{
    public abstract class AbstractEntity
    {
        public Vector2 Position { get; set; }
        public AbstractEntity()
        {
            Position = new Vector2();
        }
        public virtual void Update(GameTime gameTime) {

        }
        public virtual void Draw(SpriteBatch spriteBatch) {
            
        }

    }
}