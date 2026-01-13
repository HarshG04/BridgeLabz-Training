class Movie
{
    public string MovieTitle{get;set;}
    public TimeOnly ShowTime{get;set;}

    public override string ToString()
    {
        return String.Format("{0} : {1}", MovieTitle, ShowTime);
    }

}