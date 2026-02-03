namespace OOPSlearning
{
    class OLADriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNumber { get; set; }

        public List<Ride> Rides { get; set; } = new List<Ride>();

        public override string ToString()
        {
            return $"DriverId: {Id} | Name: {Name} | VehicleNo: {VehicleNumber}";
        }

        public decimal TotalFare()
        {
            decimal total = 0;
            foreach (var ride in Rides)
            {
                total += ride.Fare;
            }
            return total;
        }

        public void DisplayAllRides()
        {
            Console.WriteLine(this);
            Console.WriteLine("Rides:");

            foreach (var ride in Rides)
            {
                Console.WriteLine(ride);
            }

            Console.WriteLine($"Total Fare: {TotalFare()}");
            Console.WriteLine("----------------------------------");
        }
    }

    class Ride
    {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }

        public override string ToString()
        {
            return $"RideId: {RideId} | From: {From} | To: {To} | Fare: {Fare}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            OLADriver driver1 = new OLADriver
            {
                Id = 1,
                Name = "Sachin",
                VehicleNumber = "MH12AB1234"
            };

            driver1.Rides.Add(new Ride
            {
                RideId = 101,
                From = "A",
                To = "B",
                Fare = 100m
            });

            driver1.Rides.Add(new Ride
            {
                RideId = 102,
                From = "B",
                To = "C",
                Fare = 150m
            });

            OLADriver driver2 = new OLADriver
            {
                Id = 2,
                Name = "Rahul",
                VehicleNumber = "DL01XY5678"
            };

            driver2.Rides.Add(new Ride
            {
                RideId = 201,
                From = "X",
                To = "Y",
                Fare = 200m
            });

            List<OLADriver> drivers = new List<OLADriver> { driver1, driver2 };

            foreach (var driver in drivers)
            {
                driver.DisplayAllRides();
            }
        }
    }
}
