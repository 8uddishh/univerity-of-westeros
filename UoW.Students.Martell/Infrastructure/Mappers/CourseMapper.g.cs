using System.Collections.Generic;
using UoW.Students.Martell.Application;
using UoW.Students.Martell.Application.Courses;
using UoW.Students.Martell.Domain.Entities;

namespace UoW.Students.Martell.Infrastructure.Mappers
{
    public partial class CourseMapper : ICourseMapper
    {
        public CourseAggregateDto MapToAggr(Course p1)
        {
            return p1 == null ? null : new CourseAggregateDto()
            {
                StudentCourses = funcMain1(p1.StudentCourses),
                Id = p1.Id,
                Code = p1.Code,
                Title = p1.Title,
                CourseCategoryTypeId = p1.CourseCategoryTypeId
            };
        }
        public CourseDto MapToBase(Course p3)
        {
            return p3 == null ? null : new CourseDto()
            {
                Id = p3.Id,
                Code = p3.Code,
                Title = p3.Title,
                CourseCategoryTypeId = p3.CourseCategoryTypeId
            };
        }
        public Course MapToPoco(CourseDto p4)
        {
            return p4 == null ? null : new Course()
            {
                Id = p4.Id,
                Code = p4.Code,
                Title = p4.Title,
                CourseCategoryTypeId = p4.CourseCategoryTypeId
            };
        }
        public Course MapToExistingPoco(CourseDto p5, Course p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Course result = p6 ?? new Course();
            
            result.Id = p5.Id;
            result.Code = p5.Code;
            result.Title = p5.Title;
            result.CourseCategoryTypeId = p5.CourseCategoryTypeId;
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