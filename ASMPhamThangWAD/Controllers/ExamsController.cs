using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASMPhamThangWAD.Data;
using ASMPhamThangWAD.Models;
using ASMPhamThangWAD.Models.ViewModel;

namespace ASMPhamThangWAD.Controllers
{
    public class ExamsController : Controller
    {
        private ASMPhamThangWADContext db = new ASMPhamThangWADContext();

        // GET: Exams
        public ActionResult Index()
        {
            return View(db.Exams.ToList());
        }
      

        // GET: Exams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamModel examModel)
        {
            if (ModelState.IsValid)
            {   
                //Lay gia tri so phut
                var totalMinutes = examModel.ExamDuration;
                var time = TimeSpan.FromMinutes(totalMinutes);
                //lay gia tri ngay gio thi
                DateTime start = new DateTime(
                    examModel.ExamDate.Year,
                    examModel.ExamDate.Month,
                    examModel.ExamDate.Day,
                    examModel.StartTime.Hour,
                    examModel.StartTime.Minute,
                    examModel.StartTime.Second);
                //lay thoi gian hien tai
                var dateTimeNow = System.DateTime.Now;
                //gio thi + so phut thi
                var startTime = start + time;
                //da thi xong , thi truoc thoi gian hien tai
                if (startTime.Ticks < dateTimeNow.Ticks)
                {
                    var exam = new Exam()
                    {
                        ExamSubject = examModel.ExamSubject,
                        StartTime = examModel.StartTime,
                        ExamDate = examModel.ExamDate,
                        ExamDuration = examModel.ExamDuration,
                        ClassRoom = examModel.ClassRoom,
                        Faculty = examModel.Faculty,
                        Status = "Done"
                    };
                    db.Exams.Add(exam);
                }
                //Dang thi
                else if (start.Ticks < dateTimeNow.Ticks && dateTimeNow.Ticks < startTime.Ticks)
                {
                    var exam = new Exam()
                    {
                        ExamSubject = examModel.ExamSubject,
                        StartTime = examModel.StartTime,
                        ExamDate = examModel.ExamDate,
                        ExamDuration = examModel.ExamDuration,
                        ClassRoom = examModel.ClassRoom,
                        Faculty = examModel.Faculty,
                        Status = "On going"
                    };
                    db.Exams.Add(exam);
                }
                //Sap thi
                else
                {
                    var exam = new Exam()
                    {
                        ExamSubject = examModel.ExamSubject,
                        StartTime = examModel.StartTime,
                        ExamDate = examModel.ExamDate,
                        ExamDuration = examModel.ExamDuration,
                        ClassRoom = examModel.ClassRoom,
                        Faculty = examModel.Faculty,
                        Status = "Up coming"
                    };
                    db.Exams.Add(exam);
                }              
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examModel);
        }      
    }
}
