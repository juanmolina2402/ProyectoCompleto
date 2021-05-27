namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionMateriaGrupo : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Grupos", "idMateria");
            AddForeignKey("dbo.Grupos", "idMateria", "dbo.Materias", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grupos", "idMateria", "dbo.Materias");
            DropIndex("dbo.Grupos", new[] { "idMateria" });
        }
    }
}
