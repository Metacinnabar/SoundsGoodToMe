namespace SoundsGoodToMe.DataStructures
{
    public readonly struct Acronym
    {
        public string Abbreviated { get; }
        public string Expanded { get; }
        public int AbbreviatedFontSize  { get; }
        public int ExpandedFontSize  { get; }
        
        public Acronym(string abbreviated, string expanded, int abbreviatedFontSize, int expandedFontSize)
        {
            Abbreviated = abbreviated;
            Expanded = expanded;
            AbbreviatedFontSize = abbreviatedFontSize;
            ExpandedFontSize = expandedFontSize;
        }
    }
}