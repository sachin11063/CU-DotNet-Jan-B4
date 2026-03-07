using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Week5Assessment
{
    public class RestrictedDestinationException : Exception
    {
        public string DeniedLocation {get;}
        public RestrictedDestinationException(string message, string deniedLocation) : base(message)
        {
            DeniedLocation = deniedLocation;
        }

    }
    public class InsecurePackagingException : Exception
    {
        public bool Fragile { get; }
        public bool Reinforced { get; }
        public InsecurePackagingException(string message, bool isFragile, bool isReinforced) : base(message)
        {
            Fragile = isFragile;
            Reinforced = isReinforced;
        }
    }

    public abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }

        public Shipment(String trackingId, double weight, string destination)
        {
            TrackingId = trackingId;
            Weight = weight;
            Destination = destination;
        }

        public abstract void ProcessShipment();
    
    }
    public class ExpressShipment : Shipment
    {   
        private bool Fragile;
        private bool Reinforced;

        public ExpressShipment(string trackingId, double weight, string destination, bool isFragile = false, bool isReinforced = false) 
        : base(trackingId, weight, destination)
        {
            Fragile = isFragile;
            Reinforced = isReinforced;
        }
        public override void ProcessShipment()
        {
            if(Weight <= 0)
            {
                throw new ArgumentOutOfRangeException($"Shipment has invalid weight: {Weight}");
            }

            if (isRestrictedZone(Destination))
            {
                throw new RestrictedDestinationException($"Resticted Zone.",$"{Destination}");
            }
            if(Fragile && !Reinforced)
            {
                throw new InsecurePackagingException("Insecure Packaging.", Fragile, Reinforced);
            }

            if(Weight > 1000)
            {
                System.Console.WriteLine("Requires 'Heavy Lift' Permit.");
            }

            Console.WriteLine($"Processing Express Shipment: {TrackingId}, Weight: {Weight} kg, Destination: {Destination}");
        }

        public bool isRestrictedZone(string destination)
        {
            if (destination == "North Pole" || destination == "Unknown Island") return true;
            return false;
        }

    }

    public class HeavyFreight : Shipment{
        
        private bool HeavyWeightPermit;
        public HeavyFreight(string trackingId, double weight, string destination, bool isHeavyWeight)
        : base(trackingId, weight, destination)
        {
            HeavyWeightPermit= isHeavyWeight;
        }

        public override void ProcessShipment()
        {
            if(Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight is Invalid");
            }
            if (isRestrictedZone(Destination))
            {
                throw new RestrictedDestinationException("Restricted Area Detected", $"{Destination}");
            }
            if(Weight > 1000 && !HeavyWeightPermit)
            {
                System.Console.WriteLine("Need HeavyWeight Permit to Ship the item.");
            }
        }

        public bool isRestrictedZone(string destination)
        {
            if (destination == "North Pole" || destination == "Unknown Island") return true;
            return false;
        }


    }
    interface ILoggable
    {
        void SaveLog(string message);
    }
    class LogManager : ILoggable
    {
        private string logFilePath = "shipmentAudit.log";

        public void SaveLog(string message)
        {
            try
            {   
                if(!File.Exists(logFilePath))
                {
                    File.Create(logFilePath).Close();
                }
                using StreamWriter sw = new StreamWriter(logFilePath, append: true);
                
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager logger = new LogManager();

            List<Shipment> list = new List<Shipment>
            {
                new ExpressShipment("123DSFD", 840, "India", true, true),
                new ExpressShipment("694DSFD", 1200, "Unknown Island"), 
                new ExpressShipment("789XYZ", -50, "Japan"),
                new ExpressShipment("779XYZ", 1000, "Japan"),
                new HeavyFreight("999ABC", 1500, "North Pole", true),
                new HeavyFreight("1239ABC", 1500, "America", false)
                
            };

            
            foreach(Shipment shipments in list)
            {
                try{
                    shipments.ProcessShipment();
                    logger.SaveLog($"SUCCESS: Shipment {shipments.TrackingId} processed successfully.");
                   }
            
            catch(RestrictedDestinationException rde)
            {
                System.Console.WriteLine("Security Alert.");
                logger.SaveLog("Resticted Area Detected.");
            }catch (InsecurePackagingException ipe)
            {
                System.Console.WriteLine("Packaging Error.");
                logger.SaveLog($"Insecure packaging. Fragile: {ipe.Fragile}, Reinforced: {ipe.Reinforced}");
            }

            catch(ArgumentOutOfRangeException arg){
                System.Console.WriteLine("Data Entry Error.");
                logger.SaveLog("Shipment Weight is Less than or equl to 0");
            }
            catch (Exception ms)
            {
                System.Console.WriteLine(ms.Message);
                logger.SaveLog("Unexpected Error.");
            }
            finally
            {
                System.Console.WriteLine($"Processing attempt finished for ID: {shipments.TrackingId}");
            }

            }
        }
    }
}