// See https://aka.ms/new-console-template for more information
using EfAcademy_P05;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var options = new DbContextOptionsBuilder<AcademyDbContext>()
    .UseLazyLoadingProxies()
    .UseSqlServer(config.GetConnectionString("MainConnectionString"))
    .Options;

using (var db = new AcademyDbContext(options))
{
    db.Subjects.AddRange(new Subject { Name = "Math" }, new Subject { Name = "Biology" });
    db.SaveChanges();
}

//using (var db = new AcademyDbContext(options)) // Earling loading
//{
//    var teachers = db.Teachers
//        .Include(t => t.Subject)
//        .Include(t => t.Students)
//        .ToList();
//    foreach (var teacher in teachers)
//    {
//        Console.WriteLine($"Name {teacher.Name}, Age: {teacher.Age}, Subject: {teacher.Subject.Name}\nStudents: ");
//        foreach (var student in teacher.Students)
//        {
//            Console.WriteLine($"\t\tName: {student.Name},Age: {student.Age}");
//        }
//    }

//}

//using (var db = new AcademyDbContext(options)) // Explicit loading
//{
//    var teachers = db.Teachers.ToList();
//    foreach(var teacher in teachers)
//    {
//        Console.WriteLine($"Name {teacher.Name}, Age: {teacher.Age}\nStudents: ");
//        db.Entry(teacher).Collection(t => t.Students).Load();
//        foreach (var student in teacher.Students)
//        {
//            Console.WriteLine($"\t\tName: {student.Name},Age: {student.Age}");
//        }
//    }

//}

//using (var db = new AcademyDbContext(options)) // Lazy loading
//{
//    var teachers = db.Teachers.ToList();
//    foreach (var teacher in teachers)
//    {
//        Console.WriteLine($"Name {teacher.Name}, Age: {teacher.Age}\nStudents: ");
//        foreach (var student in teacher.Students)
//        {
//            Console.WriteLine($"\t\tName: {student.Name},Age: {student.Age}");
//        }
//    }

//}

//using (var db = new AcademyDbContext(options)) // Parameters Loading
//{
//    var paramter = new SqlParameter();
//    paramter.ParameterName = "@age";
//    paramter.SqlDbType = System.Data.SqlDbType.Int;
//    paramter.Value = 30;

//    var teachers = db.Teachers.FromSqlRaw("select * from Teachers where @age > 30", paramter).ToList();
//    foreach (var teacher in teachers)
//    {
//        Console.WriteLine($"Name {teacher.Name}, Age: {teacher.Age}, Subject: {teacher?.Subject?.Name}\nStudents: ");
//        foreach (var student in teacher.Students)
//        {
//            Console.WriteLine($"\t\tName: {student.Name},Age: {student.Age}");
//        }
//    }

//}

//using (var db = new AcademyDbContext(options)) // Proc Loading
//{

//    var teachers = db.Teachers.FromSqlRaw("sp_get_all_teachers").ToList();
//    foreach (var teacher in teachers)
//    {
//        Console.WriteLine($"Name {teacher.Name}, Age: {teacher.Age}, Subject: {teacher?.Subject?.Name}\nStudents: ");
//        foreach (var student in teacher.Students)
//        {
//            Console.WriteLine($"\t\tName: {student.Name},Age: {student.Age}");
//        }
//    }

//}

using (var db = new AcademyDbContext(options)) // Func Loading
{
    var parameter = new SqlParameter("@age", 32);

    var teachers = db.Teachers.FromSqlRaw("udf_get_teachers_by_age(@age)", parameter).ToList();
    foreach (var teacher in teachers)
    {
        Console.WriteLine($"Name {teacher.Name}, Age: {teacher.Age}, Subject: {teacher?.Subject?.Name}\nStudents: ");
        foreach (var student in teacher.Students)
        {
            Console.WriteLine($"\t\tName: {student.Name},Age: {student.Age}");
        }
    }

}