
using System;
using Client.App.Asset;
using Client.App.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Client.App.UI
{
    public class Button: AbstractEntity
    {
        public string Text { get; set; }
        public Action OnClick { get; set; }
        public SpriteFont Font { get; private set; }
        public Vector2 Size { get => Font.MeasureString(Text); }
        // int padding = 8;
        private bool _isMouseDown = false;
        private bool _isMouseOver = false;
        public Button()
        {
            Font = AssetRepository.Fonts["dot-gothic-16"];
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            MouseState mouse = Mouse.GetState();
            ProcessClickEvent(mouse);
            Vector2 mPos = mouse.Position.ToVector2();
            Vector2 tSize = Size;

            _isMouseDown = mouse.LeftButton.HasFlag(ButtonState.Pressed);
            _isMouseOver = - (mPos.X - Position.X) * (mPos.X - (Position + tSize).X) >= 0 &&
                           - (mPos.Y - Position.Y) * (mPos.Y - (Position + tSize).Y) >= 0;
        }

        private void ProcessClickEvent(MouseState mouse) {
            bool mouseJustReleased = !mouse.LeftButton.HasFlag(ButtonState.Pressed);
            if (_isMouseDown && _isMouseOver && mouseJustReleased) {
                OnClick();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Color color = _isMouseDown && _isMouseOver ? new Color(0.76078431372f, 0.55686274509f, 0.38039215686f) :
                          _isMouseOver                 ? new Color(0.87058823529f, 0.74509803921f, 0.47843137254f) :
                                                         Color.White;
                          
            spriteBatch.DrawString(Font, Text, Position, color);
        }

    }
}