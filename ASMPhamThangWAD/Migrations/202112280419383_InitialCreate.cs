namespace ASMPhamThangWAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamSubject = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                        ExamDuration = c.String(),
                        ClassRoom = c.String(),
                        Faculty = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Exams");
        }
    }
}
