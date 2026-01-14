using System;
using System.Data;

namespace SchoolManagement.DAL.Core
{
    public static class SqlMapper
    {
        // basic mapper placeholder
        public static T Map<T>(IDataRecord record) where T : new()
        {
            var obj = new T();
            // mapping logic to be implemented
            return obj;
        }
    }
}
