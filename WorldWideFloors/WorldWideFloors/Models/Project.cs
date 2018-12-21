using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideFloors.Models
{
    public class Project
    {
        private ICollection<Collection> _collections;

        public Project()
        {
            _collections = new List<Collection>();
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLocation { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime ProjectTime { get; set; }

        public virtual ICollection<Collection> Collections
        {
            get { return _collections; }
            set { _collections = value; }
        }
    }
}
