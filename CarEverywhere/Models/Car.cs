using System.ComponentModel.DataAnnotations;

namespace CarEverywhere.Models {
    public class Car {
        public int Id { get; set; }
        public string Model { get; set; }
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }
        [Display(Name = "Daily Value")]
        public double DailyValue { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public Car() { }

        public Car(int id, string model, string licensePlate, double dailyValue, string brand, string color, int year) {
            Id = id;
            Model = model;
            LicensePlate = licensePlate;
            DailyValue = dailyValue;
            Brand = brand;
            Color = color;
            Year = year;
        }
    }
}
