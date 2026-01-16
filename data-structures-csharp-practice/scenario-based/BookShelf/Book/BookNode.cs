namespace BookShelf
{
    class BookNode
    {
        public string Title {get;set;}
        public string AutherName {get;set;}
        public string Genre {get;set;}
        public string Status {get;set;}     // [Available , Borrowed]
        public BookNode Next {get;set;}

        public BookNode()
        {
            Status = "Available";
        }

        public override string ToString()
        {
            return $"{Title} || {AutherName} || {Genre} || {Status}";
        }

    }
}