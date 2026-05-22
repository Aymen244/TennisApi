namespace TennisApi.Models
{
    public class PlayerStats
    {
        public int Rank { get; set; }
        public int Points { get; set; }
        public int Weight { get; set; } // grams
        public int Height { get; set; } // cm
        public int Age { get; set; }
        public List<int> Last { get; set; }
    }
}
