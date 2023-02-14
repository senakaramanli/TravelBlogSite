namespace TravelTripProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _firstmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Kullanici = c.String(),
                        Sifre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AdresBlogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Aciklama = c.String(),
                        AdresAcik = c.String(),
                        Mail = c.String(),
                        Telefon = c.String(),
                        Konu = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        Aciklama = c.String(),
                        BlogImage = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Yorumlars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        Mail = c.String(),
                        Yorum = c.String(),
                        Blogid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.Blogid, cascadeDelete: true)
                .Index(t => t.Blogid);
            
            CreateTable(
                "dbo.Hakkimizdas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhotoURL = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Iletisims",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        Mail = c.String(),
                        Konu = c.String(),
                        Mesaj = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorumlars", "Blogid", "dbo.Blogs");
            DropIndex("dbo.Yorumlars", new[] { "Blogid" });
            DropTable("dbo.Iletisims");
            DropTable("dbo.Hakkimizdas");
            DropTable("dbo.Yorumlars");
            DropTable("dbo.Blogs");
            DropTable("dbo.AdresBlogs");
            DropTable("dbo.Admins");
        }
    }
}
