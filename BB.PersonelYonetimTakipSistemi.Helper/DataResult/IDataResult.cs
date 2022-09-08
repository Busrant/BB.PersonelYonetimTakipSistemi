namespace BB.PersonelYonetimTakipSistemi.Helper.DataResult
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
