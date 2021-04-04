using UoW.Students.Martell.Application;
using UoW.Students.Martell.Application.StudentCourses;
using UoW.Students.Martell.Domain.Entities;

namespace UoW.Students.Martell.Infrastructure.Mappers
{
    public partial class StudentCourseMapper : IStudentCourseMapper
    {
        public StudentCourseAggregateDto MapToAggr(StudentCourse p1)
        {
            return p1 == null ? null : new StudentCourseAggregateDto()
            {
                Student = p1.Student == null ? null : new StudentDto()
                {
                    Id = p1.Student.Id,
                    RollNumber = p1.Student.RollNumber,
                    FirstName = p1.Student.FirstName,
                    LastName = p1.Student.LastName,
                    MiddleName = p1.Student.MiddleName,
                    Prefix = p1.Student.Prefix,
                    Suffix = p1.Student.Suffix,
                    DateOfBirth = p1.Student.DateOfBirth,
                    Gender = p1.Student.Gender,
                    DateOfJoin = p1.Student.DateOfJoin,
                    DepartmentId = p1.Student.DepartmentId,
                    BatchId = p1.Student.BatchId,
                    StudentStatusTypeId = p1.Student.StudentStatusTypeId,
                    CurrentSemesterId = p1.Student.CurrentSemesterId
                },
                Course = p1.Course == null ? null : new CourseDto()
                {
                    Id = p1.Course.Id,
                    Code = p1.Course.Code,
                    Title = p1.Course.Title,
                    CourseCategoryTypeId = p1.Course.CourseCategoryTypeId
                },
                Id = p1.Id,
                Percentage = p1.Percentage,
                StudentId = p1.StudentId,
                CourseId = p1.CourseId
            };
        }
        public StudentCourseDto MapToBase(StudentCourse p2)
        {
            return p2 == null ? null : new StudentCourseDto()
            {
                Id = p2.Id,
                Percentage = p2.Percentage,
                StudentId = p2.StudentId,
                CourseId = p2.CourseId
            };
        }
        public StudentCourse MapToPoco(StudentCourseDto p3)
        {
            return p3 == null ? null : new StudentCourse()
            {
                Id = p3.Id,
                Percentage = p3.Percentage,
                StudentId = p3.StudentId,
                CourseId = p3.CourseId
            };
        }
        public StudentCourse MapToExistingPoco(StudentCourseDto p4, StudentCourse p5)
        {
            if (p4 == null)
            {
                return null;
            }
            StudentCourse result = p5 ?? new StudentCourse();
            
            result.Id = p4.Id;
            result.Percentage = p4.Percentage;
            result.StudentId = p4.StudentId;
            result.CourseId = p4.CourseId;
            return result;
            
        }
    }
}