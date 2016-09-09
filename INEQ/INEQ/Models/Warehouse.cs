using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INEQ.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Description { get; set; } 
        public string IS { get; set; }
        public string Responsable { get; set; }
        public bool Active { get; set; }
    }
}