namespace CarEverywhere.Models.ViewModel {
    public class RentFormViewModel {
        public Rent Rent { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
