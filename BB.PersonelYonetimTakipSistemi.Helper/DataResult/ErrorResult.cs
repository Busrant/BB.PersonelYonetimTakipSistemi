namespace BB.PersonelYonetimTakipSistemi.Helper.DataResult
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(true, message)
        {

        }
        public ErrorResult() : base(true)
        {

        }
    }
}
