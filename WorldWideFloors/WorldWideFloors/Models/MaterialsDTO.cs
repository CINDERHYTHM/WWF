using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideFloors.Models
{
    public class MaterialsDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int AmountLeft { get; set; }
    }
}