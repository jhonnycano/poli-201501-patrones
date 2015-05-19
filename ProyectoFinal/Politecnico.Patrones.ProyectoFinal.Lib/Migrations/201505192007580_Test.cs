namespace Politecnico.Patrones.ProyectoFinal.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interprete",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cancion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VotableId = c.Int(nullable: false),
                        Nombre = c.String(),
                        InterpreteId = c.Int(nullable: false),
                        AlbumId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VotableId = c.Int(nullable: false),
                        Nombre = c.String(),
                        InterpreteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VotableUsuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VotableId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Correo = c.String(),
                        Clave = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.VotableUsuario");
            DropTable("dbo.Votable");
            DropTable("dbo.Album");
            DropTable("dbo.Cancion");
            DropTable("dbo.Interprete");
        }
    }
}
