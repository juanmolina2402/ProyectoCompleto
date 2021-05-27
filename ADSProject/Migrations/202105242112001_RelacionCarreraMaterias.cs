namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionCarreraMaterias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materias", "IdCarrera", c => c.Int(nullable: false));
            CreateIndex("dbo.Materias", "IdCarrera");
            AddForeignKey("dbo.Materias", "IdCarrera", "dbo.Carreras", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materias", "IdCarrera", "dbo.Carreras");
            DropIndex("dbo.Materias", new[] { "IdCarrera" });
            DropColumn("dbo.Materias", "IdCarrera");
        }
    }
}
