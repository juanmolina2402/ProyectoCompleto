namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionCarreraEstudiante : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estudiantes", "IdCarrera", c => c.Int(nullable: false));
            CreateIndex("dbo.Estudiantes", "IdCarrera");
            AddForeignKey("dbo.Estudiantes", "IdCarrera", "dbo.Carreras", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estudiantes", "IdCarrera", "dbo.Carreras");
            DropIndex("dbo.Estudiantes", new[] { "IdCarrera" });
            DropColumn("dbo.Estudiantes", "IdCarrera");
        }
    }
}
