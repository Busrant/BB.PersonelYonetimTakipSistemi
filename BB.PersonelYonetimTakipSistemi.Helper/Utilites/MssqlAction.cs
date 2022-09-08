using BB.PersonelYonetimTakipSistemi.Model.AppSettings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BB.PersonelYonetimTakipSistemi.Helper.Utilites.MssqlAction;

namespace BB.PersonelYonetimTakipSistemi.Helper.Utilites
{
    public interface IMssqActions
    {
        public DataSet Exec(SqlCommand _com, QueryType Type = QueryType.SqlText);
        public DataSet Exec(string Query, QueryType Type = QueryType.SqlText);
        public T Exec<T>(string Query);
    }
    public class MssqlAction : IMssqActions
    {
        private readonly AppSettings _appSettings;

        public MssqlAction(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        protected SqlConnection Connection()
        {
            var connection = new SqlConnection(_appSettings.Connection);
            return connection;
        }

        public enum QueryType
        {
            SqlText = 1,
            StoreProdecture = 2
        }

        public DataSet Exec(SqlCommand _com, QueryType Type = QueryType.SqlText)
        {
            if (Type == QueryType.StoreProdecture)
            {
                _com.CommandType = CommandType.StoredProcedure;
            }
            _com.Connection = Connection();
            _com.CommandTimeout = 1000;

            SqlDataAdapter da = new SqlDataAdapter(_com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Exec(string Query, QueryType Type = QueryType.SqlText)
        {
            try
            {
                SqlCommand _com = new SqlCommand(Query);
                if (Type == QueryType.StoreProdecture)
                {
                    _com.CommandType = CommandType.StoredProcedure;
                }
                _com.Connection = Connection();
                SqlDataAdapter da = new SqlDataAdapter(_com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {

                throw null;
            }
        }

        public T Exec<T>(string Query)
        {
            SqlCommand _com = new(Query)
            {
                Connection = Connection()
            };
            SqlDataAdapter da = new(_com);
            DataSet ds = new();
            da.Fill(ds);

            string s = (JsonConvert.SerializeObject(ds.Tables[0]));
            var res = JsonConvert.DeserializeObject<T>(s);

            return res;
        }
    }

}
