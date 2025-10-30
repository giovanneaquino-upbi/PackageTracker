using System;
using System.Collections.Generic;

namespace PackageTracker.Models
{
    public class Package
    {
        public string Id { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public string CurrentLocation { get; set; }
        public string RecipientName { get; set; }
        public List<PackageEvent> Events { get; set; } = new List<PackageEvent>();
    }

    public class PackageEvent
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}