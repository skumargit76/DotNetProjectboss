using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Mboss.DataAccess
{
    public abstract class Base : MainBase
    {
        private static string _connectionString;

        protected override string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Mboss.Web.ConnectionString"].ConnectionString;
                         
                }
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(_connectionString);
                base.CommandTimeOut = builder.ConnectTimeout;
                return _connectionString;
            }
        }
    }

    
}
