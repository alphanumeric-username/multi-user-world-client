using System.Collections.Generic;

namespace Client.App.Asset
{
    public struct SFDFData
    {
        public string SpriteName { get; set; }
        public List<SFDFRectangle> GlyphBounds { get; set; }
        public List<SFDFRectangle> Cropping { get; set; }
        public List<char> Characters { get; set; }
        public int LineSpacing { get; set; }
        public float Spacing { get; set; }
        public List<SFDFVector3> Kerning { get; set; }
        public char DefaultCharacter { get; set; }
    }
    public struct SFDFRectangle {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public struct SFDFVector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}