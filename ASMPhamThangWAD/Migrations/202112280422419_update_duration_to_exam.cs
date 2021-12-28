namespace ASMPhamThangWAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_duration_to_exam : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "ExamDuration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "ExamDuration", c => c.String());
        }
    }
}
