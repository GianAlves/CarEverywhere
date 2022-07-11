namespace CarEverywhere.Models.ViewModel {
    public class RentFormViewModel {
        // Rental item data.
        public Rent Rent { get; set; }
        // List of cars available in the system.
        public ICollection<Car> Cars { get; set; }
        // List of clients available in the system.
        public ICollection<Client> Clients { get; set; }
    }
}
