namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food
    {
        protected Food(char symbol, int points, Coordinate coordinate)
        {
            this.Symbol = symbol;
            this.Points = points;
            this.Coordinate = coordinate;
        }

        public char Symbol { get; }

        public int  Points { get; }

        public Coordinate Coordinate { get; }
    }
}
