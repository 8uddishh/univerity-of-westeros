namespace UoW.Students.Martell.Application.Common.Brokers
{
    public interface IWesterosStudentDbContextFactory
    {
        IWesterosStudentDbContext SpawnStudentDbContext();
    }
}
