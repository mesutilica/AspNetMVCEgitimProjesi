namespace AspNetMVCEgitimProjesi.NetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uyes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(nullable: false, maxLength: 50),
                        Email = c.String(),
                        Telefon = c.String(),
                        TcKimlikNo = c.String(maxLength: 11),
                        DogumTarihi = c.DateTime(nullable: false),
                        KullaniciAdi = c.String(),
                        Sifre = c.String(nullable: false, maxLength: 15),
                        SifreTekrar = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uyes");
        }
    }
}
