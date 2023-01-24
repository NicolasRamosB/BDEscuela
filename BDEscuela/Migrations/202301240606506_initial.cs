namespace BDEscuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        IDCarrera = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDCarrera);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        IDPlan = c.Int(nullable: false, identity: true),
                        IDCarrera = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IDPlan)
                .ForeignKey("dbo.Carrera", t => t.IDCarrera, cascadeDelete: true)
                .Index(t => t.IDCarrera);
            
            CreateTable(
                "dbo.Plantilla",
                c => new
                    {
                        IDPlanilla = c.Int(nullable: false, identity: true),
                        IDCarrera = c.Int(nullable: false),
                        IDMateria = c.Int(nullable: false),
                        IDProfesor = c.Int(nullable: false),
                        IDCurso = c.Int(nullable: false),
                        Fecha = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDPlanilla)
                .ForeignKey("dbo.Carrera", t => t.IDCarrera, cascadeDelete: true)
                .ForeignKey("dbo.Curso", t => t.IDCurso, cascadeDelete: true)
                .ForeignKey("dbo.Profesor", t => t.IDProfesor, cascadeDelete: true)
                .ForeignKey("dbo.Materias", t => t.IDMateria, cascadeDelete: true)
                .Index(t => t.IDCarrera)
                .Index(t => t.IDMateria)
                .Index(t => t.IDProfesor)
                .Index(t => t.IDCurso);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        IDCurso = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDCurso);
            
            CreateTable(
                "dbo.Detalle",
                c => new
                    {
                        IDDetalle = c.Int(nullable: false, identity: true),
                        IDPlanilla = c.Int(nullable: false),
                        IDEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDDetalle)
                .ForeignKey("dbo.Plantilla", t => t.IDPlanilla, cascadeDelete: true)
                .Index(t => t.IDPlanilla);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        IDEstado = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDEstado)
                .ForeignKey("dbo.Detalle", t => t.IDEstado)
                .Index(t => t.IDEstado);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        IDEvaluccion = c.Int(nullable: false, identity: true),
                        IDTipo = c.Int(nullable: false),
                        IDEstudiante = c.Int(nullable: false),
                        IDDetalle = c.Int(nullable: false),
                        Nota = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IDEvaluccion)
                .ForeignKey("dbo.Detalle", t => t.IDDetalle, cascadeDelete: true)
                .ForeignKey("dbo.Estudiante", t => t.IDEstudiante, cascadeDelete: true)
                .ForeignKey("dbo.Tipo", t => t.IDTipo, cascadeDelete: true)
                .Index(t => t.IDTipo)
                .Index(t => t.IDEstudiante)
                .Index(t => t.IDDetalle);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        IDEstudiante = c.Int(nullable: false, identity: true),
                        IDLocalidad = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 20, unicode: false),
                        Calle = c.String(nullable: false, maxLength: 50, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.IDEstudiante)
                .ForeignKey("dbo.Localidad", t => t.IDLocalidad, cascadeDelete: true)
                .Index(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        IDLocalidad = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Localidad_IDLocalidad = c.Int(),
                    })
                .PrimaryKey(t => t.IDLocalidad)
                .ForeignKey("dbo.Localidad", t => t.Localidad_IDLocalidad)
                .Index(t => t.Localidad_IDLocalidad);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        IDProfesor = c.Int(nullable: false, identity: true),
                        IDLocalidad = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDProfesor)
                .ForeignKey("dbo.Localidad", t => t.IDLocalidad, cascadeDelete: false)
                .Index(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        IDTipo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.IDTipo);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        IDMateria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDMateria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plantilla", "IDMateria", "dbo.Materias");
            DropForeignKey("dbo.Detalle", "IDPlanilla", "dbo.Plantilla");
            DropForeignKey("dbo.Evaluacion", "IDTipo", "dbo.Tipo");
            DropForeignKey("dbo.Estudiante", "IDLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Plantilla", "IDProfesor", "dbo.Profesor");
            DropForeignKey("dbo.Profesor", "IDLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Localidad", "Localidad_IDLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Evaluacion", "IDEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.Evaluacion", "IDDetalle", "dbo.Detalle");
            DropForeignKey("dbo.Estado", "IDEstado", "dbo.Detalle");
            DropForeignKey("dbo.Plantilla", "IDCurso", "dbo.Curso");
            DropForeignKey("dbo.Plantilla", "IDCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Plan", "IDCarrera", "dbo.Carrera");
            DropIndex("dbo.Profesor", new[] { "IDLocalidad" });
            DropIndex("dbo.Localidad", new[] { "Localidad_IDLocalidad" });
            DropIndex("dbo.Estudiante", new[] { "IDLocalidad" });
            DropIndex("dbo.Evaluacion", new[] { "IDDetalle" });
            DropIndex("dbo.Evaluacion", new[] { "IDEstudiante" });
            DropIndex("dbo.Evaluacion", new[] { "IDTipo" });
            DropIndex("dbo.Estado", new[] { "IDEstado" });
            DropIndex("dbo.Detalle", new[] { "IDPlanilla" });
            DropIndex("dbo.Plantilla", new[] { "IDCurso" });
            DropIndex("dbo.Plantilla", new[] { "IDProfesor" });
            DropIndex("dbo.Plantilla", new[] { "IDMateria" });
            DropIndex("dbo.Plantilla", new[] { "IDCarrera" });
            DropIndex("dbo.Plan", new[] { "IDCarrera" });
            DropTable("dbo.Materias");
            DropTable("dbo.Tipo");
            DropTable("dbo.Profesor");
            DropTable("dbo.Localidad");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.Estado");
            DropTable("dbo.Detalle");
            DropTable("dbo.Curso");
            DropTable("dbo.Plantilla");
            DropTable("dbo.Plan");
            DropTable("dbo.Carrera");
        }
    }
}
