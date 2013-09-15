using _1.Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1.Cars
{
    public class ModelsData
    {
        public static List<Producer> GetProducers()
        {
            var producers = new List<Producer>()
            {
                new Producer()
                {
                    Name = "Audi",
                    Models = new List<string>()
                    {
                        "100", "A4", "A8", "S2", "S5"
                    }
                },
                new Producer()
                {
                    Name = "Fiat",
                    Models = new List<string>()
                    {
                        "Stilo", "Punto", "Brava", "Uno", "Panda"
                    }
                },
                new Producer()
                {
                    Name = "BMW",
                    Models = new List<string>()
                    {
                        "M3", "700", "721", "1800", "125"
                    }
                },
                new Producer()
                {
                    Name = "Citroen",
                    Models = new List<string>()
                    {
                        "Berlingo", "Visa", "Xantia", "Xsara Picasso", "C5"
                    }
                },
                new Producer()
                {
                    Name = "Hyundai",
                    Models = new List<string>()
                    {
                        "Excel", "Accent", "Matrix", "Sonata", "Stelar"
                    }
                }
            };
            return producers;
        }

        public static List<string> GetEngineTypes()
        {
            var engineTypes = new List<string>() 
            {
                "Gasoline",
                "Diesel",
                "Electrical",
                "Hybrid"
            };

            return engineTypes;
        }

        public static List<Extra> GetExtras()
        {
            var extras = new List<Extra>() 
            {
                new Extra()
                {
                    Id = 1,
                    Name = "Anti-blocking system (ABS)"
                },
                new Extra()
                {
                    Id = 2,
                    Name = "Airbag"
                },
                new Extra()
                {
                    Id = 3,
                    Name = "Parking assistant"
                },
                new Extra()
                {
                    Id = 4,
                    Name = "Traction control system (ASR)"
                },
                new Extra()
                {
                    Id = 5,
                    Name = "Break assistant (BAS)"
                },
                new Extra()
                {
                    Id = 6,
                    Name = "DVD / TV"
                },
                new Extra()
                {
                    Id = 7,
                    Name = "Climate control system"
                },
                new Extra()
                {
                    Id = 8,
                    Name = "Navigation"
                },
                new Extra()
                {
                    Id = 9,
                    Name = "Xenon lights"
                },
                new Extra()
                {
                    Id = 10,
                    Name = "Alloy wheels"
                },
            };

            return extras;
        }
    }
}