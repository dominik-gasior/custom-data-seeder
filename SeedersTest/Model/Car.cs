namespace SeedersTest.Model;

public class Car
{
    public string CompanyName { get; set; }
    public string Series { get; set; }
    public string Model { get; set; }

    public Car(string companyName, string series, string model)
    {
        CompanyName = companyName;
        Series = series;
        Model = model;
    }
}