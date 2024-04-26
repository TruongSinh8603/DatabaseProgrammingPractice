namespace SaleManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableKhachHang : DbMigration
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
                        DiaChiKH = c.String(maxLength: 200),
                        DienThoaiKH = c.String(maxLength: 50),
                        NgaySinh = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KhachHangs");
        }
    }
}
