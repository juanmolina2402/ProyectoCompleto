namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AsignacionGrupo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionGrupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdGrupo = c.Int(nullable: false),
                        IdEstudiante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estudiantes", t => t.IdEstudiante, cascadeDelete: false)
                .ForeignKey("dbo.Grupos", t => t.IdGrupo, cascadeDelete: false)
                .Index(t => t.IdGrupo)
                .Index(t => t.IdEstudiante);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionGrupo", "IdGrupo", "dbo.Grupos");
            DropForeignKey("dbo.AsignacionGrupo", "IdEstudiante", "dbo.Estudiantes");
            DropIndex("dbo.AsignacionGrupo", new[] { "IdEstudiante" });
            DropIndex("dbo.AsignacionGrupo", new[] { "IdGrupo" });
            DropTable("dbo.AsignacionGrupo");
        }
    }
}
