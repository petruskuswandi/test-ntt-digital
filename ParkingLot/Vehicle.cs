public class Vehicle
{
    public string RegistrationNumber { get; }
    public string Color { get; }
    public string Type { get; }

    public Vehicle(string registrationNumber, string color, string type)
    {
        this.RegistrationNumber = registrationNumber;
        this.Color = color;
        this.Type = type;
    }
}