using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Accounts.Common;
using Accounts.EL;

namespace Accounts.UI
{
    public class Operations
    {        
            static Guid UserId;
            static string username;
            static Guid IDCompany;
            static string _CompanyName;
            static Int64 _BookNo;
            static string _BookPeriod;
            static Guid IDRole;
            static bool _IsAuthenticate;
            public static Guid IdCompany
            {
                get { return IDCompany; }
                set { IDCompany = value; }
            }
            public static string CompanyName
            {
                get { return _CompanyName; }
                set { _CompanyName = value; }
            }
            public static Guid UserID
            {
                get { return UserId; }
                set { UserId = value; }
            }
            public static Guid IdRole
            {
                get { return IDRole; }
                set { IDRole = value; }
            }
            public static string UserName
            {
                get { return username; }
                set { username = value; }
            }
            public static Int64 BookNo
            {
                get { return _BookNo; }
                set { _BookNo = value; }
            }
            public static string BookPeriod
            {
                get { return _BookPeriod; }
                set { _BookPeriod = value; }
            }
            public static bool IsAuthenticate
            {
                get { return _IsAuthenticate; }
                set { _IsAuthenticate = value; }
            }
            public static string RemoveCurrencySymbol(string Data)
            {
                string SimpleString = string.Empty;
                if (Data.Length > 0)
                { 
                    SimpleString = Data.Substring(0,Data.Length-2);
                }
                return SimpleString;
            }
    }
    public static class DataOperations
    {
        public static List<SoftwareTypesEL> SoftwareCollection;
        public static List<SoftwareChecksEL> SoftwareChecksCollection;
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if(prop.PropertyType != null)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
                prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
        public static List<SoftwareTypesEL> SoftwareTypes
        {
            get
            {
                return SoftwareCollection;
            }
            set
            {
                SoftwareCollection = value;
            }
        }
        public static List<SoftwareChecksEL> SoftwareChecks
        {
            get
            {
                return SoftwareChecksCollection;
            }
            set
            {
                SoftwareChecksCollection = value;
            }
        }
    }
}
