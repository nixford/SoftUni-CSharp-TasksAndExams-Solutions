﻿using RealEstates.Data;
using RealEstates.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace RealEstates.Importer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"C:\Users\Dimitar Uzunov\source\repos\RealEstates\RealEstates.Importer\imot.bg-raw-data-2020-07-23.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<JsonProperty>>(json);

            var db = new RealEstateDbContext();

            IPropertiesService propertiesService = new PropertiesService(db);

            foreach (var property in properties.Where(x => x.Price > 1000))
            {
                try
                {
                    propertiesService.Create(
                    property.District,
                    property.Size,
                    property.Year,
                    property.Price,
                    property.Type,
                    property.BuildingType,
                    property.Floor,
                    property.TotalFloors);
                }
                catch (Exception)
                {                    
                }                
            }
        }
    }
}
