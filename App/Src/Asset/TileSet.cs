using Microsoft.Xna.Framework.Graphics;

namespace Client.App.Asset
{
    public static class TileSet
    {
        public static Texture2D[] DefaultTileSet { get; private set; } = new Texture2D[] {
            AssetRepository.Sprites["water"],
            AssetRepository.Sprites["deep-water"],
            AssetRepository.Sprites["grass"],
        };
    }
}