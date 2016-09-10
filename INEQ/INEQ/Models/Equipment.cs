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
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public int StatusId { get; set; }
        public int WarehouseId { get; set; }
        public DateTime EntryDate { get; set; }
        public string Serie { get; set; }
        public string SofttekId { get; set; }
        public bool Active { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }
        public virtual Model  Model { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Status Status { get; set; }
        public virtual Warehouse Warehouse { get; set; }

    }
}