public class ParkingLot
{
    private int capacity;
    private Dictionary<int, Vehicle> parkingSlots;
    private Dictionary<string, int> registrationToSlot;
    private Dictionary<string, List<string>> colorToRegistration;
    private Dictionary<string, List<string>> typeToRegistration;

    public ParkingLot(int capacity)
    {
        this.capacity = capacity;
        this.parkingSlots = new Dictionary<int, Vehicle>();
        this.registrationToSlot = new Dictionary<string, int>();
        this.colorToRegistration = new Dictionary<string, List<string>>();
        this.typeToRegistration = new Dictionary<string, List<string>>();
    }

    public void CreateParkingLot(int capacity)
    {
        this.capacity = capacity;
        Console.WriteLine($"Created a parking lot with {capacity} slots");
    }

    public void Park(string registrationNumber, string color, string type)
    {
        if (this.parkingSlots.Count < this.capacity)
        {
            int slotNumber = this.GetNextAvailableSlot();
            Vehicle vehicle = new Vehicle(registrationNumber, color, type);
            this.parkingSlots[slotNumber] = vehicle;
            this.registrationToSlot[registrationNumber] = slotNumber;

            if (!this.colorToRegistration.ContainsKey(color))
            {
                this.colorToRegistration[color] = new List<string>();
            }
            this.colorToRegistration[color].Add(registrationNumber);

            if (!this.typeToRegistration.ContainsKey(type))
            {
                this.typeToRegistration[type] = new List<string>();
            }
            this.typeToRegistration[type].Add(registrationNumber);

            Console.WriteLine($"Allocated slot number: {slotNumber}");
        }
        else
        {
            Console.WriteLine("Sorry, parking lot is full");
        }
    }

    public void Leave(int slotNumber)
    {
        if (this.parkingSlots.ContainsKey(slotNumber))
        {
            Vehicle vehicle = this.parkingSlots[slotNumber];
            this.parkingSlots.Remove(slotNumber);
            this.registrationToSlot.Remove(vehicle.RegistrationNumber);
            this.colorToRegistration[vehicle.Color].Remove(vehicle.RegistrationNumber);
            this.typeToRegistration[vehicle.Type].Remove(vehicle.RegistrationNumber);

            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine($"Slot number {slotNumber} not found");
        }
    }

    public void Status()
    {
        Console.WriteLine("Slot No.\tRegistration No.\t\tType\tColour");
        foreach (var kvp in this.parkingSlots)
        {
            Console.WriteLine($"{kvp.Key}\t\t{kvp.Value.RegistrationNumber}\t\t\t{kvp.Value.Type}\t{kvp.Value.Color}");
        }
    }

    public void TypeOfVehicles(string type)
    {
        if (this.typeToRegistration.ContainsKey(type))
        {
            int count = this.typeToRegistration[type].Count;
            Console.WriteLine(count);
        }
        else
        {
            Console.WriteLine("0");
        }
    }

    public void RegistrationNumbersForVehiclesWithOddPlate()
    {
        List<string> oddPlateRegistrations = new List<string>();
        foreach (var registration in this.registrationToSlot.Keys)
        {
            string[] parts = registration.Split('-');
            if (parts.Length >= 2)
            {
                string plateNumber = parts[1];
                if (IsOddPlate(plateNumber))
                {
                    oddPlateRegistrations.Add(registration);
                }
            }
        }
        Console.WriteLine(string.Join(", ", oddPlateRegistrations));
    }

    public void RegistrationNumbersForVehiclesWithEvenPlate()
    {
        List<string> evenPlateRegistrations = new List<string>();
        foreach (var registration in this.registrationToSlot.Keys)
        {
            string[] parts = registration.Split('-');
            if (parts.Length >= 2)
            {
                string plateNumber = parts[1];
                if (IsEvenPlate(plateNumber))
                {
                    evenPlateRegistrations.Add(registration);
                }
            }
        }
        Console.WriteLine(string.Join(", ", evenPlateRegistrations));
    }

    private bool IsOddPlate(string plateNumber)
    {
        if (int.TryParse(plateNumber, out int number))
        {
            return number % 2 != 0;
        }
        return false;
    }

    private bool IsEvenPlate(string plateNumber)
    {
        if (int.TryParse(plateNumber, out int number))
        {
            return number % 2 == 0;
        }
        return false;
    }

    public void RegistrationNumbersForVehiclesWithColor(string color)
    {
        if (this.colorToRegistration.ContainsKey(color))
        {
            Console.WriteLine(string.Join(", ", this.colorToRegistration[color]));
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }

    public void SlotNumbersForVehiclesWithColor(string color)
    {
        if (this.colorToRegistration.ContainsKey(color))
        {
            List<int> slotNumbers = new List<int>();
            foreach (var registration in this.colorToRegistration[color])
            {
                int slotNumber = this.registrationToSlot[registration];
                slotNumbers.Add(slotNumber);
            }
            Console.WriteLine(string.Join(", ", slotNumbers));
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }

    public void SlotNumberForRegistrationNumber(string registrationNumber)
    {
        if (this.registrationToSlot.ContainsKey(registrationNumber))
        {
            int slotNumber = this.registrationToSlot[registrationNumber];
            Console.WriteLine(slotNumber);
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }

    private int GetNextAvailableSlot()
    {
        for (int i = 1; i <= this.capacity; i++)
        {
            if (!this.parkingSlots.ContainsKey(i))
            {
                return i;
            }
        }
        return -1;
    }
}
