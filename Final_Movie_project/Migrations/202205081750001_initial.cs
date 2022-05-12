namespace Final_Movie_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false, maxLength: 50),
                        Lname = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(),
                        DirectortId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Directors", t => t.DirectortId, cascadeDelete: true)
                .Index(t => t.DirectortId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "DirectortId", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "DirectortId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Directors");
        }
    }
}
