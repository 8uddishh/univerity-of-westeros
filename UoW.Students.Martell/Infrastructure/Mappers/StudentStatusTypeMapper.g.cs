using System.Collections.Generic;
using UoW.Students.Martell.Application;
using UoW.Students.Martell.Application.StudentStatusTypes;
using UoW.Students.Martell.Domain.Entities;

namespace UoW.Students.Martell.Infrastructure.Mappers
{
    public partial class StudentStatusTypeMapper : IStudentStatusTypeMapper
    {
        public StudentStatusTypeAggregateDto MapToAggr(StudentStatusType p1)
        {
            return p1 == null ? null : new StudentStatusTypeAggregateDto()
            {
                Students = funcMain1(p1.Students),
                Id = p1.Id,
                Name = p1.Name,
                Description = p1.Description
            };
        }
        public StudentStatusTypeDto MapToBase(StudentStatusType p3)
        {
            return p3 == null ? null : new StudentStatusTypeDto()
            {
                Id = p3.Id,
                Name = p3.Name,
                Description = p3.Description
            };
        }
        public StudentStatusType MapToPoco(StudentStatusTypeDto p4)
        {
            return p4 == null ? null : new StudentStatusType()
            {
                Id = p4.Id,
                Name = p4.Name,
                Description = p4.Description
            };
        }
        public StudentStatusType MapToExistingPoco(StudentStatusTypeDto p5, StudentStatusType p6)
        {
            if (p5 == null)
            {
                return null;
            }
            StudentStatusType result = p6 ?? new StudentStatusType();
            
            result.Id = p5.Id;
            result.Name = p5.Name;
            result.Description = p5.Description;
            return result;
            
        }
        
        private IList<StudentDto> funcMain1(IList<Student> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            IList<StudentDto> result = new List<StudentDto>(p2.Count);
            
            ICollection<StudentDto> list = result;
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                Student item = p2[i];
                list.Add(item == null ? null : new StudentDto()
                {
                    Id = item.Id,
                    RollNumber = item.RollNumber,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MiddleName = item.MiddleName,
                    Prefix = item.Prefix,
                    Suffix = item.Suffix,
                    DateOfBirth = item.DateOfBirth,
                    Gender = item.Gender,
                    DateOfJoin = item.DateOfJoin,
                    DepartmentId = item.DepartmentId,
                    BatchId = item.BatchId,
                    StudentStatusTypeId = item.StudentStatusTypeId,
                    CurrentSemesterId = item.CurrentSemesterId
                });
                i++;
            }
            return result;
            
        }
    }
}