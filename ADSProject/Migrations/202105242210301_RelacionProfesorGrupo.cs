namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionProfesorGrupo : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Grupos", "idProfesor");
            AddForeignKey("dbo.Grupos", "idProfesor", "dbo.Profesores", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grupos", "idProfesor", "dbo.Profesores");
            DropIndex("dbo.Grupos", new[] { "idProfesor" });
        }
    }
}
