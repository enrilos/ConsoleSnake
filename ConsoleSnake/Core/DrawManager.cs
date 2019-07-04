namespace SimpleSnake.Core
{
    using SimpleSnake.GameObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DrawManager
    {
        private char snakeSymbol = '\u25CF';
        private List<Coordinate> snakeBodyElements;

        public DrawManager()
        {
            this.snakeBodyElements = new List<Coordinate>();
        }
            
        public void Draw(char symbol, IEnumerable<Coordinate> coordinates)
        {
            foreach (Coordinate coordinate in coordinates)
            {
                if (symbol == snakeSymbol)
                {
                    snakeBodyElements.Add(coordinate);
                }

                Console.SetCursorPosition(coordinate.X, coordinate.Y);
                Console.Write(symbol);
            }
        }

        public void ClearGarbageTail()
        {
            Coordinate lastElement = this.snakeBodyElements.First();

            Console.SetCursorPosition(lastElement.X, lastElement.Y);
            Console.Write(' ');

            this.snakeBodyElements.Clear();
        }
    }
}
