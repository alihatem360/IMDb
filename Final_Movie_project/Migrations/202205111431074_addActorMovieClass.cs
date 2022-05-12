namespace Final_Movie_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addActorMovieClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActorMovies",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.ActorId })
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.ActorMovies", "ActorId", "dbo.Actors");
            DropIndex("dbo.ActorMovies", new[] { "ActorId" });
            DropIndex("dbo.ActorMovies", new[] { "MovieId" });
            DropTable("dbo.Actors");
            DropTable("dbo.ActorMovies");
        }
    }
}
