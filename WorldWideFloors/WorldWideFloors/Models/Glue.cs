using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideFloors.Models
{
    public class Glue
    {
        private ICollection<Materials> _materials;
        public Glue()
        {
            _materials = new List<Materials>();
        }

        public int Id { get; set; }
        public string MaterialType { get; set; }
        public int MaterialAmount { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Materials> Materials
        {
            get { return _materials; }
            set { _materials = value; }
        }
    }
}