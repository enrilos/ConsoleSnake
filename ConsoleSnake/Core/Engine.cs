namespace SimpleSnake.Core
{
    using SimpleSnake.Enums;
    using SimpleSnake.Factories;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Engine
    {
        private const int SuspensionTime = 100;
        private const char SnakeSymbol = '\u25CF';
        private const char BorderSymbol = '\u25A0';
        private int score;
        private DrawManager drawManager;
        private Snake snake;
        private Food food;
        private Coordinate boardCoordinate;

        public Engine(DrawManager drawManager, Snake snake, Coordinate boardCoordinate)
        {
            this.drawManager = drawManager;
            this.snake = snake;
            this.boardCoordinate = boardCoordinate;
            this.InitializeFood();
            this.InitializeBorders();
        }

        public void Run()
        {
            while (true)
            {
                PlayerInfo();

                if (Console.KeyAvailable)
                {
                    this.SetValidDirection(Console.ReadKey());
                }
                this.drawManager.Draw(this.food.Symbol, new List<Coordinate>() { this.food.Coordinate });

                this.drawManager.Draw(SnakeSymbol, this.snake.Body);

                this.snake.Move();

                this.drawManager.ClearGarbageTail();

                if (HasFoodCollision())
                {
                    this.snake.Eat(this.food);
                    score += this.food.Points;
                    this.InitializeFood();
                }

                if (HasBorderCollision())
                {
                    AskUserForRestart();
                }

                Thread.Sleep(SuspensionTime);
            }
        }

        private void PlayerInfo()
        {
            Console.SetCursorPosition(110, 5);
            Console.Write($"Game score: {this.score}          ");
            Console.Write($"* - 1 point     ");
            Console.Write($"$ - 2 points    ");
            Console.Write($"# - 3 points");
        }

        private void AskUserForRestart()
        {
            Console.SetCursorPosition(110, 15);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Would you like to play again? ");
            Console.Write("Y/N: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void InitializeVerticalBorderLine(int x, List<Coordinate> coordinates)
        {
            for (int y = 0; y < this.boardCoordinate.Y / 2; y++)
            {
                coordinates.Add(new Coordinate(x, y));
            }
        }

        private void InitializeHorizontalBorderLine(int y, List<Coordinate> coordinates)
        {
            for (int x = 0; x < this.boardCoordinate.X * 3; x++)
            {
                coordinates.Add(new Coordinate(x, y));
            }
        }

        private void InitializeBorders()
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            this.InitializeHorizontalBorderLine(0, coordinates);
            this.InitializeHorizontalBorderLine(this.boardCoordinate.Y / 2, coordinates);

            this.InitializeVerticalBorderLine(0, coordinates);
            this.InitializeVerticalBorderLine(this.boardCoordinate.X * 3, coordinates);

            this.drawManager.Draw(BorderSymbol, coordinates);
        }

        private void InitializeFood()
        {
            this.food = FoodFactory.GenerateRandomFood(this.boardCoordinate.X * 3, this.boardCoordinate.Y / 2);
        }

        private bool HasFoodCollision()
        {
            int snakeHeadX = this.snake.Head.X;
            int snakeHeadY = this.snake.Head.Y;

            int foodX = this.food.Coordinate.X;
            int foodY = this.food.Coordinate.Y;

            bool xCollision = snakeHeadX == foodX;
            bool yCollision = snakeHeadY == foodY;

            return xCollision && yCollision;
        }

        private bool HasBorderCollision()
        {
            int snakeX = this.snake.Head.X;
            int snakeY = this.snake.Head.Y;

            int boardX = this.boardCoordinate.X * 3;
            int boardY = this.boardCoordinate.Y / 2;

            return snakeX == 0 ||
                    snakeY == 0 ||
                    snakeX == boardX ||
                    snakeY == boardY;
        }

        private void SetValidDirection(ConsoleKeyInfo consoleKeyInfo)
        {
            Direction currentSnakeDirection = this.snake.Direction;

            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    if (currentSnakeDirection != Direction.Left)
                    {
                        currentSnakeDirection = Direction.Right;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentSnakeDirection != Direction.Right)
                    {
                        currentSnakeDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (currentSnakeDirection != Direction.Down)
                    {
                        currentSnakeDirection = Direction.Up;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentSnakeDirection != Direction.Up)
                    {
                        currentSnakeDirection = Direction.Down;
                    }
                    break;
            }

            this.snake.Direction = currentSnakeDirection;
        }
    }
}
