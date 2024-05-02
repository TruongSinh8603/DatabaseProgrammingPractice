namespace SaleManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableKhachHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 50),
                        TaiKhoan = c.String(maxLength: 50),
                        MatKhau = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 100),
                        DiachiKH = c.String(maxLength: 200),
                        DienthoaiKH = c.String(maxLength: 50),
                        Ngaysinh = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KhachHangs");
        }
    }
}
