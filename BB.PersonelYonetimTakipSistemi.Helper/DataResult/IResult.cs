using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Helper.DataResult
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
