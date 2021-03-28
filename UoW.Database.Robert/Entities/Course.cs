namespace UoW.Database.Robert.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int CategoryTypeId { get; set; }

        public CourseCategoryType CourseCategoryType { get; set; }
    }
}
