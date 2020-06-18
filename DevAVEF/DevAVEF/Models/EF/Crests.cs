using System;
using System.Collections.Generic;

namespace DevAVEF.Models.EF
{
    public partial class Crests
    {
        public Crests()
        {
            CustomerStoreLocations = new HashSet<CustomerStoreLocations>();
        }

        public int CrestId { get; set; }
        public string CityName { get; set; }
        public byte[] CrestImage { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual ICollection<CustomerStoreLocations> CustomerStoreLocations { get; set; }
    }
}
