namespace BrowserBuddy
{
    class TabNode
    {
        public string URL {get;set;}
        public TabNode Prev{get;set;}
        public TabNode Next{get;set;}
    }
}