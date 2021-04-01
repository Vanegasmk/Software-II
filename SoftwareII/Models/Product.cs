using System;
using System.Collections.Generic;

namespace SoftwareII.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Presentation { get; set; }

    }
}