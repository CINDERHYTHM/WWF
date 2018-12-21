using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideFloors.Models
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLocation { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime ProjectTime { get; set; }
    }
}