namespace Politecnico.Patrones.ProyectoFinal.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTabla : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Usuarios", newName: "Usuario");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Usuario", newName: "Usuarios");
        }
    }
}
