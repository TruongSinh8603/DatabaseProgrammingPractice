namespace SaleManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(Name) VALUES (N'Điện thoại')");
            Sql("INSERT INTO Categories(Name) VALUES (N'Máy tính bảng')");
            Sql("INSERT INTO Categories(Name) VALUES (N'Laptop')");
        }
        
        public override void Down()
        {
        }
    }
}
