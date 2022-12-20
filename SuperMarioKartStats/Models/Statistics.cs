using System.ComponentModel.DataAnnotations;

namespace SuperMarioKartStats.Models
{


   abstract public class Statistics
    {
        public enum StatColumnn
        {
            Weight = 3,
            Acceleration = 4,
            OnRoadTraction = 5,
            OffRoadTraction = 6,
            MiniTurbo = 7,
            GroundSpeed = 8,
            WaterSpeed = 9,
            AntiGravitySpeed = 10,
            AirSpeed = 11,
            GroundHandling = 12,
            WaterHandlinger = 13,
            AntiGravityHandling = 14,
            AirHandling = 15
        }

        [Key]
        public Guid Key { get; set; }
        public string? Name { get; set; }
        public int Weight { get; set; }
        public int Acceleration { get; set; }
        public int OnRoadTraction { get; set; }
        public int OffRoadTraction { get; set; }
        public int MiniTurbo { get; set; }
        public int GroundSpeed { get; set; }
        public int WaterSpeed { get; set; }
        public int AntiGravitySpeed { get; set; }
        public int AirSpeed { get; set; }
        public int GroundHandling { get; set; }
        public int WaterHandling { get; set; }
        public int AntiGravityHandling { get; set; }
        public int AirHandling { get; set; }
    }
}
