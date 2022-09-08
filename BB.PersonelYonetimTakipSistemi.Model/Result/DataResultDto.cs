namespace BB.PersonelYonetimTakipSistemi.Model.Result
{
    public class DataResultDto<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
