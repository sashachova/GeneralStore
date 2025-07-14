public class UserData
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
}
 
public class TestData
{
    public List<UserData> Users { get; set; } = new List<UserData>();
}