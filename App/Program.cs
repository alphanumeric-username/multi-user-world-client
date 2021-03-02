using System;

namespace Client.App
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MUWClient())
                game.Run();
        }
    }
}
