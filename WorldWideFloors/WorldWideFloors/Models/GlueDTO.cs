using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideFloors.Models
{
    public class GlueDTO
    {
        public int Id { get; set; }
        public string MaterialType { get; set; }
        public int MaterialAmount { get; set; }
        public double Price { get; set; }
    }
}