namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using System;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            DrawManager drawManager = new DrawManager();
            Snake snake = new Snake();
            Coordinate boardCoords = new Coordinate(Console.LargestWindowHeight / 2, Console.LargestWindowWidth / 2);
            Engine engine = new Engine(drawManager, snake, boardCoords);
            engine.Run();
        }
    }
}
