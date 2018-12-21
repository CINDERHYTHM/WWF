using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideFloors.Models
{
    public class Collection
    {
        private ICollection<Project> _projects;

        public Collection()
        {
            _projects = new List<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public virtual ICollection<Project> Projects
        {
            get { return _projects; }
            set { _projects = value; }
        }
    }
}