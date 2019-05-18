namespace solid.practices.tests
{
    public class FakeRatingUpdater : IRatingUpdater
    {
        public decimal? NewRating { get; private set; }

        public void UpdateRating(decimal rating)
        {
            NewRating = rating;
        }
    }
}