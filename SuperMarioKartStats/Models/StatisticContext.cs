using CinemaPostersWebApi.Utilities;
using IronXL;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace SuperMarioKartStats.Models
{
    public class StatisticContext : DbContext
    {
        private readonly WorkBook workbook;
        private WorkSheet? worksheet;

        public StatisticContext(DbContextOptions<StatisticContext> options): base(options){
            Database.EnsureCreated();
            workbook = WorkBook.Load(@"Data\\MarioKart.xlsx");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            //Create the database if it doesn't already exist
            var appSettingsJson = AppSettingsJson.GetAppSettings();
            var connectionString = appSettingsJson["MssqlConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public async Task ProcessAsync()
        {
            //Create the database connection
            await CreateDriversAsync();
            await CreateBodiesAsync();
            await CreateTiresAsync();
            await CreateGlidersAsync();

            //Commit changes to the database
            await this.SaveChangesAsync();
        }

        private async Task CreateDriversAsync()
        {
            worksheet = workbook.GetWorkSheet("Drivers Statistics");
            if(worksheet == null){ return;}

            //Iterate through all the cells
            for (var i = 3; i <= 43; i++)
            {
                //Get the range from A-B
                var range = worksheet[$"A{i}:N{i}"].ToList();
                //Create a driver entity to be saved to the database
                var driver = new Driver
                {
                    Name = (string)range[0].Value,
                    Weight = (int)(double)range[1].Value,
                    Acceleration = (int)(double)range[2].Value,
                    OnRoadTraction = (int)(double)range[3].Value,
                    OffRoadTraction = (int)(double)range[4].Value,
                    MiniTurbo = (int)(double)range[5].Value,
                    GroundSpeed = (int)(double)range[6].Value,
                    WaterSpeed = (int)(double)range[7].Value,
                    AntiGravitySpeed = (int)(double)range[8].Value,
                    AirSpeed = (int)(double)range[9].Value,
                    GroundHandling = (int)(double)range[10].Value,
                    WaterHandling = (int)(double)range[11].Value,
                    AntiGravityHandling = (int)(double)range[12].Value,
                    AirHandling = (int)(double)range[13].Value
                };
                //Add the entity 
                await this.Drivers.AddAsync(driver);
            }
        }

        private async Task CreateBodiesAsync()
        {
            worksheet = workbook.GetWorkSheet("Bodies Statistics");
            if (worksheet == null) { return; }

            //Iterate through all the cells
            for (var i = 3; i <= 41; i++)
            {
                //Get the range from A-B
                var range = worksheet[$"A{i}:N{i}"].ToList();
                //Create a driver entity to be saved to the database
                var Body = new Body
                {
                    Name = (string)range[0].Value,
                    Weight = (int)(double)range[1].Value,
                    Acceleration = (int)(double)range[2].Value,
                    OnRoadTraction = (int)(double)range[3].Value,
                    OffRoadTraction = (int)(double)range[4].Value,
                    MiniTurbo = (int)(double)range[5].Value,
                    GroundSpeed = (int)(double)range[6].Value,
                    WaterSpeed = (int)(double)range[7].Value,
                    AntiGravitySpeed = (int)(double)range[8].Value,
                    AirSpeed = (int)(double)range[9].Value,
                    GroundHandling = (int)(double)range[10].Value,
                    WaterHandling = (int)(double)range[11].Value,
                    AntiGravityHandling = (int)(double)range[12].Value,
                    AirHandling = (int)(double)range[13].Value
                };
                //Add the entity 
                await this.Bodies.AddAsync(Body);
            }
        }

        private async Task CreateTiresAsync()
        {
            worksheet = workbook.GetWorkSheet("Tires");
            if (worksheet == null) { return; }

            //Iterate through all the cells
            for (var i = 3; i <= 22; i++)
            {
                //Get the range from A-B
                var range = worksheet[$"A{i}:N{i}"].ToList();
                //Create a driver entity to be saved to the database
                var Tire = new Tire
                {
                    Name = (string)range[0].Value,
                    Weight = (int)(double)range[1].Value,
                    Acceleration = (int)(double)range[2].Value,
                    OnRoadTraction = (int)(double)range[3].Value,
                    OffRoadTraction = (int)(double)range[4].Value,
                    MiniTurbo = (int)(double)range[5].Value,
                    GroundSpeed = (int)(double)range[6].Value,
                    WaterSpeed = (int)(double)range[7].Value,
                    AntiGravitySpeed = (int)(double)range[8].Value,
                    AirSpeed = (int)(double)range[9].Value,
                    GroundHandling = (int)(double)range[10].Value,
                    WaterHandling = (int)(double)range[11].Value,
                    AntiGravityHandling = (int)(double)range[12].Value,
                    AirHandling = (int)(double)range[13].Value
                };
                //Add the entity 
                await this.Tires.AddAsync(Tire);
            }
        }
        private async Task CreateGlidersAsync()
        {
            worksheet = workbook.GetWorkSheet("Gliders");
            if (worksheet == null) { return; }

            //Iterate through all the cells
            for (var i = 3; i <= 15; i++)
            {
                //Get the range from A-B
                var range = worksheet[$"A{i}:N{i}"].ToList();
                //Create a driver entity to be saved to the database
                var Glider = new Glider
                {
                    Name = (string)range[0].Value,
                    Weight = (int)(double)range[1].Value,
                    Acceleration = (int)(double)range[2].Value,
                    OnRoadTraction = (int)(double)range[3].Value,
                    OffRoadTraction = (int)(double)range[4].Value,
                    MiniTurbo = (int)(double)range[5].Value,
                    GroundSpeed = (int)(double)range[6].Value,
                    WaterSpeed = (int)(double)range[7].Value,
                    AntiGravitySpeed = (int)(double)range[8].Value,
                    AirSpeed = (int)(double)range[9].Value,
                    GroundHandling = (int)(double)range[10].Value,
                    WaterHandling = (int)(double)range[11].Value,
                    AntiGravityHandling = (int)(double)range[12].Value,
                    AirHandling = (int)(double)range[13].Value
                };
                //Add the entity 
                await this.Gliders.AddAsync(Glider);
            }
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<Glider> Gliders { get; set; }
    }
}
