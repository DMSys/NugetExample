using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ngSQLite
{
    /// <summary>
    /// 
    /// </summary>
    public class SQLiteDatabase: IDisposable
    {
        private String _DataSource = "TestBase.db";

        private SQLiteConnection _Connection = null;

        private SQLiteTransaction _Transaction = null;

        /// <summary>
        ///     Single Param Constructor for specifying the DB file.
        /// </summary>
        /// <param name="dataSource">The File containing the DB</param>
        public SQLiteDatabase(String dataSource = "TestBase.db")
        {
            _DataSource = dataSource;
            _Connection = new SQLiteConnection(String.Format("Data Source={0}", dataSource));
        }

        /// <summary>
        ///     Single Param Constructor for specifying advanced connection options.
        /// </summary>
        /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
        public SQLiteDatabase(Dictionary<String, String> connectionOpts)
        {
            StringBuilder connectionString = new StringBuilder();
            foreach (KeyValuePair<String, String> row in connectionOpts)
            {
                if (row.Key.ToLower() == "data source")
                {
                    _DataSource = row.Value;
                }
                connectionString.AppendFormat("{0}={1};", row.Key, row.Value);
            }
            _Connection = new SQLiteConnection(connectionString.ToString());
        }

        /// <summary>
        ///     Releases all resources used by the System.ComponentModel.Component.
        /// </summary>
        public void Dispose()
        {
            if (_Connection != null)
            {
                _Connection.Close();
                _Connection.Dispose();
                _Connection = null;
            }
        }

        #region Database

        /// <summary>
        ///     Opens the connection using the parameters found in the System.Data.SQLite.SQLiteConnection.ConnectionString.
        /// </summary>
        /// <param name="create">Allows the programmer to create new database file.</param>
        public void Open(bool create = true)
        {
            if (!File.Exists(_DataSource))
            {
                if (create)
                {
                    SQLiteConnection.CreateFile(_DataSource);
                }
                else
                {
                    throw new Exception("File '" + _DataSource + " does not exist.'");
                }
            }
            _Connection.Open();
        }

        /// <summary>
        ///     When the database connection is closed, all commands linked to this connection are automatically reset.
        /// </summary>
        public void Close()
        {
            _Connection.Close();
        }

        /// <summary>
        ///     Allows the programmer to run a query against the Database.
        /// </summary>
        /// <param name="selectCommand">The SQL to run</param>
        /// <returns>A DataTable containing the result set.</returns>
        public DataTable FillToDataTable(String selectCommand)
        {
            DataTable dTable = new DataTable();
            using (SQLiteCommand command = new SQLiteCommand(_Connection))
            {
                command.CommandText = selectCommand;
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    dTable.Load(reader);
                    reader.Close();
                }
            }
            return dTable;
        }

        /// <summary>
        ///     Allows the programmer to run a query against the Database.
        /// </summary>
        /// <param name="selectCommand">The SQL to run</param>
        /// <param name="fieldName"></param>
        /// <returns>A string list containing the result set.</returns>
        public List<String> FillToStringList(String selectCommand, String fieldName)
        {
            List<String> listString = new List<String>();
            using (SQLiteCommand command = new SQLiteCommand(_Connection))
            {
                command.CommandText = selectCommand;
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listString.Add(reader[fieldName].ToString());
                    }
                    reader.Close();
                }
            }
            return listString;
        }

        /// <summary>
        ///     Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="commandText">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        public int ExecuteNonQuery(string commandText)
        {
            int affectedRows = 0;
            using (SQLiteCommand command = new SQLiteCommand(_Connection))
            {
                command.CommandText = commandText;
                affectedRows = command.ExecuteNonQuery();
            }
            return affectedRows;
        }

        /// <summary>
        ///     Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="commandText">The query to run.</param>
        /// <returns>A object.</returns>
        public object ExecuteScalar(string commandText)
        {
            object value = null;
            using (SQLiteCommand command = new SQLiteCommand(_Connection))
            {
                command.CommandText = commandText;
                value = command.ExecuteScalar();
            }
            return value;
        }

        /// <summary>
        ///     Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="commandText">The query to run.</param>
        /// <param name="defaultValue"></param>
        /// <returns>A string.</returns>
        public string ExecuteScalarToString(string commandText, string defaultValue = "")
        {
            object value = this.ExecuteScalar(commandText);
            return ((value == null) ? defaultValue : value.ToString());
        }

        /// <summary>
        ///     Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="commandText">The query to run.</param>
        /// <param name="defaultValue"></param>
        /// <returns>A Int32.</returns>
        public Int32 ExecuteScalarToInt32(string commandText, Int32 defaultValue = 0)
        {
            object value = this.ExecuteScalar(commandText);
            if (value == null)
            {
                Int32 intValue = defaultValue;
                return (Int32.TryParse(value.ToString(), out intValue) ? intValue : defaultValue);
            }
            else
            { return defaultValue; }
        }

        /// <summary>
        ///     Allows the user to easily reduce size of database.
        /// </summary>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public Int32 Vacuum(string tableName = "")
        {
            if (tableName == "")
            {
                return ExecuteNonQuery("VACUUM;");
            }
            else
            {
                return ExecuteNonQuery(String.Format("VACUUM {0};", tableName));
            }
        }

        /// <summary>
        /// List the names of database tables
        /// </summary>
        /// <returns></returns>
        public List<String> ListTablesName()
        {
            return this.FillToStringList("select NAME from SQLITE_MASTER where type='table' order by NAME;", "NAME");
        }

        /// <summary>
        /// List of tables in database
        /// </summary>
        /// <returns></returns>
        public DataTable ListTables()
        {
            return this.FillToDataTable("select * from SQLITE_MASTER where type='table' order by NAME;");
        }
        
        /// <summary>
        ///     Allows the programmer to easily delete all data from the DB.
        /// </summary>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public void Clear()
        {
            List<String> tables = this.ListTablesName();
            foreach (String tableName in tables)
            {
                this.Delete(tableName);
            }
        }

        #endregion Database

        #region SQL

        /// <summary>
        ///     Allows the programmer to easily update rows in the DB.
        /// </summary>
        /// <param name="tableName">The table to update.</param>
        /// <param name="data">A dictionary containing Column names and their new values.</param>
        /// <param name="where">The where clause for the update statement.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public int Update(String tableName, Dictionary<String, String> data, String where)
        {
            if ((data == null) || (data.Count == 0))
            { return 0; }

            bool isFirstRow = true;
            StringBuilder updateCommand = new StringBuilder();
            updateCommand.AppendFormat("update {0} set ", tableName);

            foreach (KeyValuePair<String, String> val in data)
            {
                if (isFirstRow)
                {
                    updateCommand.AppendFormat("{0} = {1}", val.Key.ToString(), val.Value.ToString());
                    isFirstRow = false;
                }
                else
                {
                    updateCommand.AppendFormat(", {0} = {1}", val.Key.ToString(), val.Value.ToString());
                }
            }
            updateCommand.AppendFormat(" where {0};", where);

            return this.ExecuteNonQuery(updateCommand.ToString());
        }

        /// <summary>
        ///     Allows the programmer to easily delete rows from the DB.
        /// </summary>
        /// <param name="tableName">The table from which to delete.</param>
        /// <param name="where">The where clause for the delete.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public int Delete(String tableName, String where = "")
        {
            StringBuilder deleteCommand = new StringBuilder();
            deleteCommand.AppendFormat("delete from {0}", tableName);
            if (!String.IsNullOrEmpty(where))
            {
                deleteCommand.AppendFormat(" where {0}", where);
            }
            deleteCommand.Append(";");

            return this.ExecuteNonQuery(deleteCommand.ToString());            
        }
        
        /// <summary>
        ///     Allows the programmer to easily insert into the DB
        /// </summary>
        /// <param name="tableName">The table into which we insert the data.</param>
        /// <param name="data">A dictionary containing the column names and data for the insert.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public int Insert(String tableName, Dictionary<String, String> data)
        {
            StringBuilder columns = new StringBuilder();
            StringBuilder values = new StringBuilder();
            bool isFirstRow = true;
            foreach (KeyValuePair<String, String> val in data)
            {
                if (isFirstRow)
                {
                    columns.AppendFormat("{0}", val.Key.ToString());
                    values.AppendFormat("'{0}'", ValidateParameter(val.Value));
                    isFirstRow = false;
                }
                else
                {
                    columns.AppendFormat(", {0}", val.Key.ToString());
                    values.AppendFormat(", '{0}'", ValidateParameter(val.Value));
                }
            }
            string commandText = String.Format("insert into {0}({1}) values({2});"
                , tableName, columns.ToString(), values.ToString());
            columns.Clear();
            values.Clear();

            return this.ExecuteNonQuery(commandText);
        }

        /// <summary>
        ///     Allows the programmer to easily insert into the DB
        /// </summary>
        /// <param name="tableName">The table into which we insert the data.</param>
        /// <param name="data">A dictionary containing the column names and data for the insert.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public int Insert(String tableName, List<String> data)
        {
            StringBuilder values = new StringBuilder();
            bool isFirstRow = true;
            foreach (String value in data)
            {
                if (isFirstRow)
                {
                    values.AppendFormat("'{0}'", ValidateParameter(value));
                    isFirstRow = false;
                }
                else
                {
                    values.AppendFormat(", '{0}'", ValidateParameter(value));
                }
            }
            string commandText =
                String.Format("insert into {0} values({1});", tableName, values.ToString());
            values.Clear();

            return this.ExecuteNonQuery(commandText);
        }

        /// <summary>
        ///     Validate the value of the parameter
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ValidateParameter(string value)
        {
            return value.Replace("'", "''");
        }

        /// <summary>
        /// Drop table by name
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns></returns>
        public int DropTable(String tableName)
        {
            return this.ExecuteNonQuery(String.Format("drop table if exists {0}", tableName));
        }

        /// <summary>
        /// Drop database
        /// </summary>
        /// <returns></returns>
        public void DropDatabase()
        {
            if (File.Exists(_DataSource))
            {
                File.Delete(_DataSource);
            }
        }

        #endregion SQL
    }
}
