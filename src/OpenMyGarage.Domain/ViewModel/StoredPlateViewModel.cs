using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMyGarage.Domain.ViewModel
{
    public class StoredPlateViewModel
    {
        public string Plate { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string CarManufacturer { get; set; }
        public bool AutoOpen { get; set; }
    }
}
