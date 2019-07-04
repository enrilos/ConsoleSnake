namespace SimpleSnake.GameObjects.Foods
{
    public class AsteriskFood : Food
    {
        private const char Symbol = '*';
        private const int Points = 1;
        public AsteriskFood(Coordinate coordinate)
            : base(Symbol, Points, coordinate)
        {
        }
    }
}
