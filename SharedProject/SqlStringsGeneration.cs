﻿using System;
using System.Collections.Generic;
using System.Text;

namespace gamon.ForeignWords
{
    internal partial class SqlStrings
    {
        #region functions that prepare the value of a variable to be used in a SQL statement 
        internal string SqlString(string String)
        {
            if (String == null) return "null";
            string temp;
            if (!(String == null))
            {
                temp = String;

                //temp = temp.Replace("\"", "\"\"");
                temp = temp.Replace("'", "''");
                //temp = "'" + temp + "'";
            }
            else
                temp = "";
            temp = "'" + temp + "'";
            return temp;
        }
        internal string SqlString(string String, int MaxLenght)
        {
            if (String == null) return "null";
            string temp;
            if (!(String == null))
            {
                temp = String;

                //temp = temp.Replace("\"", "\"\"");
                temp = temp.Replace("'", "''");
                //temp = "'" + temp + "'";
            }
            else
                temp = "";
            if (MaxLenght > 0 && temp.Length > MaxLenght)
                temp = temp.Substring(0, MaxLenght);
            temp = "'" + temp + "'";
            return temp;
        }
        internal string SqlStringLike(string String)
        {
            if (String == null) return "null";
            string temp;
            if (!(String == null))
            {
                temp = String;

                //temp = temp.Replace("\"", "\"\"");
                temp = temp.Replace("'", "''");
                //temp = "'" + temp + "'";
            }
            else
                temp = "";
            temp = "LIKE '%" + temp + "%'";
            return temp;
        }
        public string SqlBool(object Value)
        {
            if (Value == null)
                return "null";
            if ((bool)Value == false)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
        internal string SqlDouble(string Number)
        {
            try
            {
                if (Number != null)
                    return double.Parse(Number).ToString().Replace(",", ".");
                else
                    return "null";
            }
            catch
            {
                return "null";
            }
        }
        internal string SqlDouble(object Number)
        {
            if (Number == null)
                return "null"; 
            // restituisce null se dà errore, perchè viene usato con double? 
            try
            {
                return Number.ToString().Replace(",", ".");
            }
            catch
            {
                return "null"; 
            }
        }
        internal string SqlFloat(float Number)
        {
            try
            {
                return Number.ToString().Replace(",", ".");
            }
            catch
            {
                return "null"; 
            }
        }
        internal string SqlFloat(string Number)
        {
            try
            {
                return float.Parse(Number).ToString().Replace(",", ".");
            }
            catch
            {
                return "null"; 
            }
        }
        internal string SqlInt(string Number)
        {
            try
            {
                if (Number != null)
                    return int.Parse(Number).ToString();
                else
                    return "null";
            }
            catch
            {
                return "null";
            }
        }
        internal string SqlInt(int? Number)
        {
            if (Number == null) return "null";
            try
            {
                return Number.ToString();
            }
            catch
            {
                return "null";
            }
        }
        internal string CleanStringForQuery (string Query)
        {
            // pulisce la stringa dalle andate a capo e dai tab 
            Query = Query.Replace("\t", " ");
            Query = Query.Replace("\r\n", " ");
            Query = Query.Replace("  ", " ");
            Query = Query.Replace("  ", " ");

            while (Query.Contains("  "))
                Query = Query.Replace("  ", " ");
            return Query; 
        }
        public string SqlDate(string Date)
        {
            if (Date is null)
                return "null";
            if (Date == "")
                return "null";

            DateTime? d = System.DateTime.Parse(Date);
            return ("datetime('" + ((DateTime)d).ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "')");
        }

        public string SqlDate(DateTime? Date)
        {
            if (Date != null)
                return ("datetime('" + ((DateTime)Date).ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "')");
            else
                return "null";
        }
    }
    #endregion
}
