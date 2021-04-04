using System.Collections.Generic;
using UoW.Students.Martell.Application;
using UoW.Students.Martell.Application.Students;
using UoW.Students.Martell.Domain.Entities;

namespace UoW.Students.Martell.Infrastructure.Mappers
{
    public partial class StudentMapper : IStudentMapper
    {
        public StudentAggregateDto MapToAggr(Student p1)
        {
            return p1 == null ? null : new StudentAggregateDto()
            {
                StudentStatusType = p1.StudentStatusType == null ? null : new StudentStatusTypeDto()
                {
                    Id = p1.StudentStatusType.Id,
                    Name = p1.StudentStatusType.Name,
                    Description = p1.StudentStatusType.Description
                },
                StudentCourses = funcMain1(p1.StudentCourses),
                Id = p1.Id,
                RollNumber = p1.RollNumber,
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                MiddleName = p1.MiddleName,
                Prefix = p1.Prefix,
                Suffix = p1.Suffix,
                DateOfBirth = p1.DateOfBirth,
                Gender = p1.Gender,
                DateOfJoin = p1.DateOfJoin,
                DepartmentId = p1.DepartmentId,
                BatchId = p1.BatchId,
                StudentStatusTypeId = p1.StudentStatusTypeId,
                CurrentSemesterId = p1.CurrentSemesterId
            };
        }
        public StudentDto MapToBase(Student p3)
        {
            return p3 == null ? null : new StudentDto()
            {
                Id = p3.Id,
                RollNumber = p3.RollNumber,
                FirstName = p3.FirstName,
                LastName = p3.LastName,
                MiddleName = p3.MiddleName,
                Prefix = p3.Prefix,
                Suffix = p3.Suffix,
                DateOfBirth = p3.DateOfBirth,
                Gender = p3.Gender,
                DateOfJoin = p3.DateOfJoin,
                DepartmentId = p3.DepartmentId,
                BatchId = p3.BatchId,
                StudentStatusTypeId = p3.StudentStatusTypeId,
                CurrentSemesterId = p3.CurrentSemesterId
            };
        }
        public Student MapToPoco(StudentDto p4)
        {
            return p4 == null ? null : new Student()
            {
                Id = p4.Id,
                RollNumber = p4.RollNumber,
                FirstName = p4.FirstName,
                LastName = p4.LastName,
                MiddleName = p4.MiddleName,
                Prefix = p4.Prefix,
                Suffix = p4.Suffix,
                DateOfBirth = p4.DateOfBirth,
                Gender = p4.Gender,
                DateOfJoin = p4.DateOfJoin,
                DepartmentId = p4.DepartmentId,
                BatchId = p4.BatchId,
                StudentStatusTypeId = p4.StudentStatusTypeId,
                CurrentSemesterId = p4.CurrentSemesterId
            };
        }
        public Student MapToExistingPoco(StudentDto p5, Student p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Student result = p6 ?? new Student();
            
            result.Id = p5.Id;
            result.RollNumber = p5.RollNumber;
            result.FirstName = p5.FirstName;
            result.LastName = p5.LastName;
            result.MiddleName = p5.MiddleName;
            result.Prefix = p5.Prefix;
            result.Suffix = p5.Suffix;
            result.DateOfBirth = p5.DateOfBirth;
            result.Gender = p5.Gender;
            result.DateOfJoin = p5.DateOfJoin;
            result.DepartmentId = p5.DepartmentId;
            result.BatchId = p5.BatchId;
            result.StudentStatusTypeId = p5.StudentStatusTypeId;
            result.CurrentSemesterId = p5.CurrentSemesterId;
            return result;
            
        }
        
        private IList<StudentCourseDto> funcMain1(IList<StudentCourse> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            IList<StudentCourseDto> result = new List<StudentCourseDto>(p2.Count);
            
            ICollection<StudentCourseDto> list = result;
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                StudentCourse item = p2[i];
                list.Add(item == null ? null : new StudentCourseDto()
                {
                    Id = item.Id,
                    Percentage = item.Percentage,
                    StudentId = item.StudentId,
                    CourseId = item.CourseId
                });
                i++;
            }
            return result;
            
        }
    }
}