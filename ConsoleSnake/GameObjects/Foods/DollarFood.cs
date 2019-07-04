namespace SimpleSnake.GameObjects.Foods
{
    public class DollarFood : Food
    {
        private const char Symbol = '$';
        private const int Points = 2;
        public DollarFood(Coordinate coordinate) 
            : base(Symbol, Points, coordinate)
        {
        }
    }
}
