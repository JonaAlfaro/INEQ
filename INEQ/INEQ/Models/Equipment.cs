using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INEQ.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public int EquipmentTypeId { get; set; }
        public int ModeId { get; set; }
        public int BrandId { get; set; }
        public int StatusId { get; set; }
        public int WarehouseId { get; set; }
        public DateTime EntryDate { get; set; }
        public string Serie { get; set; }
        public string SofttekId { get; set; }
        public bool Active { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }
    }
}