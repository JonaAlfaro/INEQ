namespace INEQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Component",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        ComponentTypeId = c.Int(nullable: false),
                        Equipment_Id = c.Int(nullable: false),
                        EquipmentType_Id = c.Int(nullable: false),
                        Equipment_Id1 = c.Int(),
                        EquipmentType_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipment", t => t.Equipment_Id1)
                .ForeignKey("dbo.EquipmentType", t => t.EquipmentType_Id1)
                .Index(t => t.Equipment_Id1)
                .Index(t => t.EquipmentType_Id1);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentTypeId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Serie = c.String(),
                        SofttekId = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentType", t => t.EquipmentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Model", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.EquipmentTypeId)
                .Index(t => t.ModelId)
                .Index(t => t.BrandId)
                .Index(t => t.StatusId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.EquipmentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        UsefulLife = c.Single(nullable: false),
                        GuaranteeDuration = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: false)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IS = c.String(),
                        Responsable = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComponentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Component", "EquipmentType_Id1", "dbo.EquipmentType");
            DropForeignKey("dbo.Component", "Equipment_Id1", "dbo.Equipment");
            DropForeignKey("dbo.Equipment", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.Equipment", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Equipment", "ModelId", "dbo.Model");
            DropForeignKey("dbo.Model", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Equipment", "EquipmentTypeId", "dbo.EquipmentType");
            DropForeignKey("dbo.Equipment", "BrandId", "dbo.Brand");
            DropIndex("dbo.Model", new[] { "BrandId" });
            DropIndex("dbo.Equipment", new[] { "WarehouseId" });
            DropIndex("dbo.Equipment", new[] { "StatusId" });
            DropIndex("dbo.Equipment", new[] { "BrandId" });
            DropIndex("dbo.Equipment", new[] { "ModelId" });
            DropIndex("dbo.Equipment", new[] { "EquipmentTypeId" });
            DropIndex("dbo.Component", new[] { "EquipmentType_Id1" });
            DropIndex("dbo.Component", new[] { "Equipment_Id1" });
            DropTable("dbo.User");
            DropTable("dbo.ComponentType");
            DropTable("dbo.Warehouse");
            DropTable("dbo.Status");
            DropTable("dbo.Model");
            DropTable("dbo.EquipmentType");
            DropTable("dbo.Equipment");
            DropTable("dbo.Component");
            DropTable("dbo.Brand");
        }
    }
}
