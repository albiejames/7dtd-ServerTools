﻿using System.Data;

namespace ServerTools
{
    public class UpdateSQL
    {
        public static void Exec(int _version)
        {
            CheckVersion();
        }

        private static void CheckVersion()
        {
            DataTable _result = SQL.TQuery("SELECT sql_version FROM Config");
            int _version;
            int.TryParse(_result.Rows[0].ItemArray.GetValue(0).ToString(), out _version);
            _result.Dispose();
            if (_version != SQL.Sql_version)
            {
                Exec(_version);
            }
            else
            {
                LoadProcess.Load(3);
            }
        }
    }
}
