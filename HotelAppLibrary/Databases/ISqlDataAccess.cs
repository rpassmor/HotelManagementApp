﻿using System.Collections.Generic;

namespace HotelAppLibrary.Databases
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string sql,
            U parameters,
            string connectionStringName,
            bool isStoredProcedure = false);

        void SaveData<T>(string sql,
            T parameters,
            string connectionStringName,
            bool isStoredProcedure = false);
    }
}