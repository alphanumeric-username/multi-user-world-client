using Microsoft.Xna.Framework;

namespace Client.App.Info
{
    public static class Screen
    {
        public static Vector2 Size { get; private set; }
        public static void ProvideInformation(Vector2 size) {
            Size = size;
        }
    }
}