using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideFloors.Models
{
    public class Materials
    {
        private ICollection<Glue> _glue;

        public Materials()
        {
            _glue = new List<Glue>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int AmountLeft { get; set; }

        public virtual ICollection<Glue> Glue
        {
            get { return _glue; }
            set { _glue = value; }
        }
    }
}