namespace ReadPlayCode.Mappers
{
    public interface IDataToModelMapper<D, M>
    {
        M DataToModel(D data);
    }
}
