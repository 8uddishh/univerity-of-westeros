namespace UoW.Students.Martell.Domains.Entities
{
    using System.Collections.Generic;
    using UoW.Students.Sand;

    public class StudentStatusType : StudentStatusTypeEntity
    {
        public IList<Student> Students { get; set; }
    }
}
