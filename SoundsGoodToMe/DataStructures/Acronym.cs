namespace SoundsGoodToMe.DataStructures
{
    public readonly struct Acronym
    {
        public string Abbreviated { get; }

        public string Expanded { get; }
        
        public Acronym(string abbreviated, string expanded)
        {
            Abbreviated = abbreviated;
            Expanded = expanded;
        }
    }
}