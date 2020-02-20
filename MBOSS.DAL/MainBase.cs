using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ComponentModel;

namespace Mboss.DataAccess
{
    public abstract class MainBase : IDisposable
    {
        private SqlConnection _connection;

        private int _timeoutVar = -1;

        protected int CommandTimeOut
        {
            get
            {
                return _timeoutVar;
            }
            set
            {
                _timeoutVar = value;
            }
        }

        protected abstract string ConnectionString
        {
            get;
        }

        protected MainBase()
        {
        }

        private void Open()
        {
            if (_connection == null)
            {
                _connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        private void Close()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                _connection = null;
            }
        }

        #region IDisposable Members

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Code to dispose the managed resources of the class
                Close();
            }
            // Code to dispose the un-managed resources of the class

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Execute

        protected IDataReader ExecuteReader(string procName)
        {
            return ExecuteReader(procName, null);
        }

        /// <summary>
        /// Don't use unless you know what you're doing
        /// </summary>
        protected virtual IDataReader ExecuteReader(string procName, params object[] parameters)
        {
            var command = GetCommandAndConnection(procName, parameters);
            if (CommandTimeOut > 0)
            {
                command.CommandTimeout = CommandTimeOut;
            }
            return command.ExecuteReader();
        }

        protected virtual IDataReader ExecuteReader(SqlConnection connection
            , SqlTransaction trans
            , string procName
            , params object[] parameters
        )
        {
            return GetCommandAndConnection(connection, trans, procName, parameters).ExecuteReader();
        }

        protected void ExecuteNonQuery(string procName)
        {
            ExecuteNonQuery(procName, null);
        }

        protected void ExecuteNonQuery(string procName, params object[] parameters)
        {
           var command = GetCommandAndConnection(procName, parameters);
            if(CommandTimeOut > 0) {
                command.CommandTimeout = CommandTimeOut;
            }
            command.ExecuteNonQuery();
        }

        protected static void ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, string procName, params object[] parameters)
        {
            GetCommandAndConnection(connection, transaction, procName, CommandType.StoredProcedure, parameters).ExecuteNonQuery();
        }

        protected object ExecuteScalar(string procName)
        {
            return ExecuteScalar(procName, null);
        }

        protected object ExecuteScalar(string procName, params object[] parameters)
        {
            var command = GetCommandAndConnection(procName, parameters);
            if (CommandTimeOut > 0)
            {
                command.CommandTimeout = CommandTimeOut;
            }
            return command.ExecuteScalar();
        }


        private SqlCommand GetCommandAndConnection(string procName, params object[] paramList)
        {
            return GetCommandAndConnection(procName, CommandType.StoredProcedure, paramList);
        }

        private SqlCommand GetCommandAndConnection(string procName
            , CommandType commandType
            , params object[] paramList
        )
        {
            Open();

            return GetCommandAndConnection(_connection, null, procName, commandType, paramList);
        }

        private static SqlCommand GetCommandAndConnection(SqlConnection conn
            , SqlTransaction trans
            , string procName
            , params object[] paramList)
        {
            return GetCommandAndConnection(conn, trans, procName, CommandType.StoredProcedure, paramList);
        }

        private static SqlCommand GetCommandAndConnection(SqlConnection connection
            , SqlTransaction transaction
            , string procName
            , CommandType commandType
            , params object[] parameters)
        {
            SqlCommand command = new SqlCommand(procName, connection, transaction);

            command.CommandType = commandType;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command;

        }

        protected static SqlParameter CreateReturnParameter()
        {

            var returnCode = new SqlParameter();
            returnCode.Direction = System.Data.ParameterDirection.ReturnValue;
            returnCode.DbType = System.Data.DbType.Int32;

            return returnCode;

        }


        #endregion

        #region NullIfBlank

        /// <summary>
        /// Returns DBNull.Value if blank or else the value of the item. 
        /// Used for converting a blank value for stored procedures
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static object NullIfBlank(int value)
        {
            if (value != 0)
            {
                return value;
            }
            return DBNull.Value;
        }

        protected static object NullIfBlank(long value)
        {
            if (value != 0)
            {
                return value;
            }
            return DBNull.Value;
        }

        protected static object NullIfBlank(double value)
        {
            if (value != 0.0)
            {
                return value;
            }
            return DBNull.Value;
        }

        protected static object NullIfBlank(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            return DBNull.Value;
        }

        protected static object NullIfBlank(decimal value)
        {
            if (value != 0)
            {
                return value;
            }
            return DBNull.Value;
        }


        protected static object NullIfBlank(DateTime value)
        {
            if (value != null && value != DateTime.MinValue)
            {
                return value;
            }
            return DBNull.Value;
        }

        protected static object NullIfBlank(Guid value)
        {
            if (value != null && value != Guid.Empty)
            {
                return value;
            }
            return DBNull.Value;
        }

        protected static object NullIfBlank(byte[] value)
        {
            if (value != null)
            {
                return value;
            }
            return DBNull.Value;
        }


        protected static object NullIfBlank(object value, object blankValue)
        {
            if (value != null && value != blankValue)
            {
                return value;
            }
            return DBNull.Value;
        }

        protected static object NullIfBlank(IComparable value, IComparable blankValue)
        {
            if (value != null && value.CompareTo(blankValue) != 0)
            {
                return value;
            }
            return DBNull.Value;
        }

        #endregion


    }
}
