using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mercer_Craigslist.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string OwnerEmail { get; set; }
        public Category Category { get; set; }
    }
    public enum Category
    {
        Clothing = 1,
        Car,
        Electronics,
        Apartment,
        Appliances,
        Books,
        Tools,
        Video_Games,
        General
    }
}