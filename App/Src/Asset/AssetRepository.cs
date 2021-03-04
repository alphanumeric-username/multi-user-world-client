using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Client.App.Asset
{
    public static class AssetRepository
    {
        public static Dictionary<string, Texture2D> Sprites { get; private set; }
        public static Dictionary<string, SoundEffect> Sounds { get; private set; }
        public static string RootDirectory { get; private set; }

        public static void LoadAssets(string assetRootDirectory, GraphicsDevice graphicsDevice)
        {
            LoadSprites(assetRootDirectory, graphicsDevice);
            LoadSounds(assetRootDirectory);

            RootDirectory = assetRootDirectory;
        }

        private static void LoadSprites(string assetRootDirectory, GraphicsDevice graphicsDevice) {
            Sprites = new Dictionary<string, Texture2D>();
            
            string spritesDirectory = Path.Combine(assetRootDirectory, "Sprites");
            var spriteFiles = FilterFilesByExtension(Directory.EnumerateFiles(spritesDirectory), "png");
            
            foreach(string spriteFile in spriteFiles) {
                string spriteName = RemoveFilePathAndExtension(spriteFile);
                Sprites[spriteName] = Texture2D.FromFile(graphicsDevice, spriteFile);
            }
        }

        private static void LoadSounds(string assetRootDirectory) {
            Sounds = new Dictionary<string, SoundEffect>();

            string soundsDirectory = Path.Combine(assetRootDirectory, "Sounds");

            var soundFiles = FilterFilesByExtension(Directory.EnumerateFiles(soundsDirectory), "ogg");

            
            foreach(string soundFile in soundFiles) {
                string soundName = RemoveFilePathAndExtension(soundFile);
                Sounds[soundName] = SoundEffect.FromFile(soundFile);
            }
        }

        private static IEnumerable<string> FilterFilesByExtension(IEnumerable<string> files, string extension) {
            extension = extension.StartsWith('.') ? extension : '.' + extension;
            return files.Where(f => f.EndsWith(extension));
        }

        private static string RemoveFilePathAndExtension(string file) {
            int startIndex = file.LastIndexOf(Path.PathSeparator) + 1;
            int length = file.LastIndexOf('.') - startIndex;
            return file.Substring(startIndex, length);
        }
    }
}