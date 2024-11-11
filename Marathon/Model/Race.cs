namespace Marathon.Model;

public class RaceCollection
{
    public race[] races { get; set; }
}
public class race
{
    public int id { get; set; }
    public string race_name{ get; set; }
}