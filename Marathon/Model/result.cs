namespace Marathon.Model;

public class ResultsCollection
{
    public result[] results { get; set; }
}
public class result
{
    public int id { get; set; }
    public int race_id { get; set; }
    public int placement { get; set; }
    public string name { get; set; }
    public string time { get; set; }
    public string state { get; set; }

    public string detail
    {
        get
        {
            return placement + " Place  Time: " + time;
        }
    }
}