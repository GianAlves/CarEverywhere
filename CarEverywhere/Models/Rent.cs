using System.ComponentModel.DataAnnotations;

namespace CarEverywhere.Models {
    public class Rent {
        public int Id { get; set; }
        // Car:
        // Adding the id field of the car to be rented.
        [Display(Name = "Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
        /* - - - - - */

        // Client:
        // Adding the id field of the customer who will rent.
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        /* - - - - - */

        [Display(Name = "Lease Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}")]
        public DateTime LeaseDate { get; set; }
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}")]
        public DateTime ReturnDate { get; set; }
        public double Total { get; set; }
        /* Fine for late delivery of the vehicle */
        public double Fine { get; set; }

        public Rent() { }

        public Rent(int id, Car car, Client client, DateTime leaseDate, DateTime returnDate, double total, double fine) {
            Id = id;
            Car = car;
            Client = client;
            LeaseDate = leaseDate;
            ReturnDate = returnDate;
            Total = total;
            Fine = fine;
        }
    }
}
