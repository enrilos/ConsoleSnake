namespace SimpleSnake.GameObjects
{
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects.Foods;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private const int DefaultLength = 4;
        private const int DefaultX = 5;
        private const int DefaultY = 5;
        private List<Coordinate> snakeBody;

        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.Direction = Direction.Right;
            this.InitializeBody();
        }

        public IReadOnlyCollection<Coordinate> Body => this.snakeBody.AsReadOnly();

        public Coordinate Head => this.snakeBody.Last();

        public Direction Direction { get; set; }
        
        public void Move()
        {
            Coordinate newHead = this.GetNewHeadCoordinates();

            this.snakeBody.Add(newHead);
            this.snakeBody.RemoveAt(0);
        }

        private Coordinate GetNewHeadCoordinates()
        {
            Coordinate newHeadCoordinate = new Coordinate(this.Head.X, this.Head.Y);

            switch (this.Direction)
            {
                case Direction.Right:
                    newHeadCoordinate.X++;
                    break;
                case Direction.Left:
                    newHeadCoordinate.X--;
                    break;
                case Direction.Down:
                    newHeadCoordinate.Y++;
                    break;
                case Direction.Up:
                    newHeadCoordinate.Y--;
                    break;
            }

            return newHeadCoordinate;
        }

        public void Eat(Food food)
        {
            for (int i = 0; i < food.Points; i++)
            {
                Coordinate newHeadCoordinates = this.GetNewHeadCoordinates();
                this.snakeBody.Add(newHeadCoordinates);
            }
        }

        private void InitializeBody()
        {
            int x = DefaultX;
            int y = DefaultY;

            for (int i = 0; i <= DefaultLength; i++)
            {
                this.snakeBody.Add(new Coordinate(x, y));
                x++;
            }
        }
    }
}
