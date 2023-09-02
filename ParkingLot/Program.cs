using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ParkingLot parkingLot = null;

        while (true)
        {
            string input = Console.ReadLine();
            string[] command = input.Split(' ');

            if (command[0].Equals("create_parking_lot", StringComparison.OrdinalIgnoreCase))
            {
                int capacity = int.Parse(command[1]);
                parkingLot = new ParkingLot(capacity);
                parkingLot.CreateParkingLot(capacity);
            }
            else if (parkingLot == null)
            {
                Console.WriteLine("Parking lot is not created. Please create a parking lot first.");
            }
            else if (command[0].Equals("park", StringComparison.OrdinalIgnoreCase))
            {
                string registrationNumber = command[1];
                string color = command[2];
                string type = command[3];
                parkingLot.Park(registrationNumber, color, type);
            }
            else if (command[0].Equals("leave", StringComparison.OrdinalIgnoreCase))
            {
                int slotNumber = int.Parse(command[1]);
                parkingLot.Leave(slotNumber);
            }
            else if (command[0].Equals("status", StringComparison.OrdinalIgnoreCase))
            {
                parkingLot.Status();
            }
            else if (command[0].Equals("type_of_vehicles", StringComparison.OrdinalIgnoreCase))
            {
                string type = command[1];
                parkingLot.TypeOfVehicles(type);
            }
            else if (command[0].Equals("registration_numbers_for_vehicles_with_odd_plate", StringComparison.OrdinalIgnoreCase))
            {
                parkingLot.RegistrationNumbersForVehiclesWithOddPlate();
            }
            else if (command[0].Equals("registration_numbers_for_vehicles_with_even_plate", StringComparison.OrdinalIgnoreCase))
            {
                parkingLot.RegistrationNumbersForVehiclesWithEvenPlate();
            }
            else if (command[0].Equals("registration_numbers_for_vehicles_with_colour", StringComparison.OrdinalIgnoreCase))
            {
                string color = command[1];
                parkingLot.RegistrationNumbersForVehiclesWithColor(color);
            }
            else if (command[0].Equals("slot_numbers_for_vehicles_with_colour", StringComparison.OrdinalIgnoreCase))
            {
                string color = command[1];
                parkingLot.SlotNumbersForVehiclesWithColor(color);
            }
            else if (command[0].Equals("slot_number_for_registration_number", StringComparison.OrdinalIgnoreCase))
            {
                string registrationNumber = command[1];
                parkingLot.SlotNumberForRegistrationNumber(registrationNumber);
            }
            else if (command[0].Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }
}
