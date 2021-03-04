using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.App.Entity
{
    public class GraphicalEntity: AbstractEntity
    {
        public Texture2D Graphics { get; set; }

        public GraphicalEntity(Texture2D graphics)
        {
            Graphics = graphics;
        }
        public GraphicalEntity(): this(null) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(Graphics, this.Position, Color.White);
        }
    }
}