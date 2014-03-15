namespace ReadPlayCode.Mappers
{
    public interface IMapper<D, M> : IDataToModelMapper<D, M>, IModelToDataMapper<M, D>
    {
    }
}
