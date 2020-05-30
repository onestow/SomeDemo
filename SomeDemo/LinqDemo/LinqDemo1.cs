using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SomeDemo.LinqDemo
{
    public class LinqDemo1
    {
        public void Run()
        {
            var students = new Student[]
            {
                new Student() { Id = "1", Name = "Tom"},
                new Student() { Id = "2", Name = "Alice"},
                new Student() { Id = "3", Name = "Jerry"}
            };
            var courses = new Course[]
            {
                new Course() { StudentId = "1,2", Title = "语文"},
                new Course() { StudentId = "1", Title = "数学"}
            };
            var eml = new List<Student>();
            var aaaa = eml.DefaultIfEmpty().ToList();

            var ccs = from student in students
                      join course in courses on student.Id equals course.StudentId into gj
                      from subCourse in gj.DefaultIfEmpty()
                      select new
                      {
                          student.Id,
                          student.Name,
                          //Title = subCourse?.Title ?? "没有课程",
                          //CourseCount = gj.Count(),
                      };


            var ccs2 = from student in students
                       from course in courses let sId = course.StudentId.Split(',')
                       where sId.Contains(student.Id)
                       select new
                       {
                           student.Id,
                           student.Name,
                           course.Title
                       };

            Console.WriteLine();
        }
    }

    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public string StudentId { get; set; }
        public string Title { get; set; }
    }
}
