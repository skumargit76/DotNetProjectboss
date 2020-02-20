using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Mboss.Common
{
    public static class ExtensionMethods
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.\+_]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        public static bool IsAscii(this string s)
        {

            if (s.IsNullOrEmpty())
            {
                return true;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > 127)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static string HtmlEncode(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            var sb = new System.Text.StringBuilder(s.Length + 5);

            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];

                if (Char.IsLetterOrDigit(ch))
                {
                    sb.Append(ch);
                }
                else
                {
                    switch (ch)
                    {
                        case '<':
                            sb.Append("&lt;");
                            break;
                        case '>':
                            sb.Append("&gt;");
                            break;
                        case '"':
                            sb.Append("&quot;");
                            break;
                        case '&':
                            sb.Append("&amp;");
                            break;
                        default:
                            if ((int)ch > 127)
                            {
                                sb.Append("&#");
                                sb.Append(((int)ch).ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
                                sb.Append(';');
                            }
                            else
                            {
                                sb.Append(ch);
                            }
                            break;
                    }
                }
            }
            return sb.ToString();
        }

               

        public static bool IsDateValid(this string dateString)
        {
            if (dateString.IsNullOrEmpty())
            {
                return false;
            }

            try
            {
                DateTime dtParse = DateTime.Parse(dateString);
            }
            catch (System.Exception)
            {
                return false;
            }
           
            return true;
            
        }

        public static DateTime ToDate(this string dateString)
        {
            // function is not correct checking of data as missing
            // the date id input is 1/2/2011
            // shahid 16-07-2011
            if (!dateString.IsDateValid())
            {
                return DateTime.MinValue;
            }
            try
            {
                //string[] convertDate = dateString.Split('/');
                DateTime dateTime = DateTime.Parse(dateString);// new DateTime(Convert.ToInt32(convertDate[2].ToString()), Convert.ToInt32(convertDate[1].ToString()), Convert.ToInt32(convertDate[0].ToString()));
                return dateTime;
            }
            catch (Exception)
            {
                throw new Exception("Date is not Correct");
            }

          
        }

        public static string ToDateString(this DateTime date)
        {


            return date.ToString("dd/MM/yyyy");
            
        }

        public static string ToDateTimeString(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy h:mm:ss");
            
        }

        public static string ToString(this decimal price)
        {
            return price.ToString("0");
        }

        public static string connectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["Mboss.Web.ConnectionString"].ConnectionString;
            }
        }

        public static string ErrorLogPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ErrorLogPath"];
            }
        }

        public static string FileServerPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["FileServerPath"];
            }
        }

        public static string XMLTemplateAuthoriseRequestPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["XMLTemplateAuthoriseRequestPath"];
            }
        }
        public static string JBOSSServerPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["JBOSSServerPath"];
            }
        }

        public static string XMLTemplateDeleteRequestPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["XMLTemplateDeleteRequestPath"];
            }
        }

        public static string XMLTemplateInputRequestPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["XMLTemplateInputRequestPath"];
            }
        }
        public static string XMLTemplateReverseRequestPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["XMLTemplateReverseRequestPath"];
            }
        }
        public static string XMLTemplateEnquireRequestPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["XMLTemplateEnquireRequestPath"];
            }
        }

    }
}
