namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionCarreraGrupo : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Grupos", "IdCarrera");
            AddForeignKey("dbo.Grupos", "IdCarrera", "dbo.Carreras", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grupos", "IdCarrera", "dbo.Carreras");
            DropIndex("dbo.Grupos", new[] { "IdCarrera" });
        }
    }
}
