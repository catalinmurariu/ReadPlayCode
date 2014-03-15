namespace ReadPlayCode.Mappers
{
    public interface IModelToDataMapper<M, D>
    {
        D ModelToData(M model);
    }
}
