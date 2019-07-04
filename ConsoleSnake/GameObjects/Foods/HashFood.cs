namespace SimpleSnake.GameObjects.Foods
{
    public class HashFood : Food
    {
        private const char Symbol = '#';
        private const int Points = 3;
        public HashFood(Coordinate coordinate)
            : base(Symbol, Points, coordinate)
        {
        }
    }
}
