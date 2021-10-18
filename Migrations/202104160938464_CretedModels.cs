namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CretedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Gender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .Index(t => t.Id)
                .Index(t => t.Gender_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Class_Id = c.Int(),
                        Gender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .Index(t => t.Id)
                .Index(t => t.Class_Id)
                .Index(t => t.Gender_Id);
            
            CreateTable(
                "dbo.TeacherTopicClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Teacher_Id = c.Int(),
                        Topic_Id = c.Int(),
                        Class_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .Index(t => t.Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Topic_Id)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Gender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .Index(t => t.Id)
                .Index(t => t.Gender_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherTopicClasses", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.TeacherTopicClasses", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.TeacherTopicClasses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Students", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Admins", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Topics", new[] { "Id" });
            DropIndex("dbo.Teachers", new[] { "Gender_Id" });
            DropIndex("dbo.Teachers", new[] { "Id" });
            DropIndex("dbo.TeacherTopicClasses", new[] { "Class_Id" });
            DropIndex("dbo.TeacherTopicClasses", new[] { "Topic_Id" });
            DropIndex("dbo.TeacherTopicClasses", new[] { "Teacher_Id" });
            DropIndex("dbo.TeacherTopicClasses", new[] { "Id" });
            DropIndex("dbo.Students", new[] { "Gender_Id" });
            DropIndex("dbo.Students", new[] { "Class_Id" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.Classes", new[] { "Id" });
            DropIndex("dbo.Genders", new[] { "Id" });
            DropIndex("dbo.Admins", new[] { "Gender_Id" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropTable("dbo.Topics");
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherTopicClasses");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
            DropTable("dbo.Genders");
            DropTable("dbo.Admins");
        }
    }
}
