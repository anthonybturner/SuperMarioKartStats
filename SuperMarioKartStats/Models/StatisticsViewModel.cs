using Microsoft.EntityFrameworkCore;
using System;

namespace SuperMarioKartStats.Models
{
    public class StatisticsViewModel
    {
        public List<Driver> Drivers;
        public List<Body> Bodies;
        public List<Tire> Tires;
        public List<Glider> Gliders;
        public List<string> Stats;
        private StatisticContext context;
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

        public StatisticsViewModel(StatisticContext context)
        {
            this.context = context;
            Drivers = (from b in this.context.Drivers select b).ToList();
            Bodies = (from x in this.context.Bodies select x).ToList();
            Tires = (from y in this.context.Tires select y).ToList();
            Gliders = (from z in this.context.Gliders select z).ToList();

            Stats = new List<string>();
            string[] names = Enum.GetNames(typeof(StatColumnn));
            StatColumnn[] values = (StatColumnn[])Enum.GetValues(typeof(StatColumnn));

            for (int i = 0; i < names.Length; i++)
            {
                Stats.Add(names[i]);
            }
        }
    }
}
