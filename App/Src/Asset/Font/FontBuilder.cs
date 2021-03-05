using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.App.Asset
{
    public static class FontBuilder
    {
        public static SpriteFont Build(Texture2D texture, SFDFData data) {
            SpriteFontParameters parameters = SFDFDataToSpriteFontParameters(data);
            parameters.Texture = texture;
            return new SpriteFont(
                parameters.Texture,
                parameters.GlyphBounds,
                parameters.Cropping,
                parameters.Characters,
                parameters.LineSpacing,
                parameters.Spacing,
                parameters.Kerning,
                parameters.DefaultCharacter
            );
        }

        private static SpriteFontParameters SFDFDataToSpriteFontParameters(SFDFData data) {
            return new SpriteFontParameters {
                GlyphBounds = data.GlyphBounds.ConvertAll((r) => new Rectangle(r.X, r.Y, r.Width, r.Height)),
                Cropping = data.Cropping.ConvertAll((r) => new Rectangle(r.X, r.Y, r.Width, r.Height)),
                Characters = new List<char>(data.Characters.ToCharArray()),
                LineSpacing = data.LineSpacing,
                Spacing = data.Spacing,
                Kerning = data.Kerning.ConvertAll((v) => new Vector3(v.X, v.Y, v.Z)),
                DefaultCharacter = data.DefaultCharacter.ToCharArray()[0],
            };
        }
    }

    public struct SpriteFontParameters
    {
        public Texture2D Texture { get; set; }
        public List<Rectangle> GlyphBounds { get; set; }
        public List<Rectangle> Cropping { get; set; }
        public List<char> Characters { get; set; }
        public int LineSpacing { get; set; }
        public float Spacing { get; set; }
        public List<Vector3> Kerning { get; set; }
        public char DefaultCharacter { get; set; }
    }
}