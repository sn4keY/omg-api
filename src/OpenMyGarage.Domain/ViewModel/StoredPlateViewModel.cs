namespace OpenMyGarage.Domain.ViewModel
{
    public class StoredPlateViewModel : ViewModelBase
    {
        public string Plate { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string CarManufacturer { get; set; }
        public bool AutoOpen { get; set; }
    }
}
