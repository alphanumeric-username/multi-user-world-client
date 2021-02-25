using System;

namespace client
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
