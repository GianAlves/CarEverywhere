using System.ComponentModel.DataAnnotations;

namespace CarEverywhere.Models {
    public class Client {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Enter a shorter name."), MinLength(2, ErrorMessage = "Name must be longer than 2 characters.")]
        public string Name { get; set; }
        [Display(Name = "Driver License")]
        public string DriverLicense { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}")]
        public DateTime BirthDate { get; set; }

        public Client() { }

        public Client(int id, string name, string driverLicense, string phoneNumber, string email, string address, string zipCode, DateTime birthDate) {
            Id = id;
            Name = name;
            DriverLicense = driverLicense;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            ZipCode = zipCode;
            BirthDate = birthDate;
        }
    }
}
