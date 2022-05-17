using FluentMigrator;

namespace Amparo.Aplicacao.Migrations
{
    [Migration(202205152150)]
    public class _20220515_AddUsuariosTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Usuarios");
        }

        public override void Up()
        {
            Create.Table("Usuarios")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(500).NotNullable()
                .WithColumn("Username").AsString(50).NotNullable()
                .WithColumn("Senha").AsString(50);
        }
    }
}
