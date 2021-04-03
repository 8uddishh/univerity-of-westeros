namespace UoW.Students.Martell.Application.Common.Brokers
{
    using Mapster;

    public interface IMapperRegister
    {
        void Register(TypeAdapterConfig config);
    }
}
