namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 3),
                        nombre = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 12),
                        email = c.String(nullable: false, maxLength: 254),
                        nombres = c.String(nullable: false, maxLength: 50),
                        apellidos = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCarrera = c.Int(nullable: false),
                        idMateria = c.Int(nullable: false),
                        idProfesor = c.Int(nullable: false),
                        ciclo = c.Int(nullable: false),
                        anio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Profesores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombres = c.String(nullable: false, maxLength: 50),
                        apellidos = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 254),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profesores");
            DropTable("dbo.Materias");
            DropTable("dbo.Grupos");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Carreras");
        }
    }
}
