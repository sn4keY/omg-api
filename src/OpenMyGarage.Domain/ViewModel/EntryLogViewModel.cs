using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMyGarage.Domain.ViewModel
{
    public class EntryLogViewModel
    {
        public string Plate { get; set; }
        public long EntryTime { get; set; }
        public string PictureURL { get; set; }
    }
}
