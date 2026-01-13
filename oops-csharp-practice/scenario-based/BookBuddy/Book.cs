class Book
{
    public string BookTitle{get;set;}
    public string BookAuther{get;set;}

    public override string ToString()
    {
        return $"Title: {BookTitle} || Auther : {BookAuther}";
    }
}