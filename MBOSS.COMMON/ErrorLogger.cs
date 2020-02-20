

using System;
using System.Globalization;
using System.IO;
using System.Resources;

namespace Mboss.Common
{
    public class ErrorLogger
    {
       
        /// <summary>
        /// Writes error to a text file
        /// </summary>
        /// <param name="_errorMessage"></param>
        /// <param name="_errorPage"></param>
        public static void WriteError(string _errorMessage, string _errorPage, string path)
        {
            try
            {
                path = path + "/" + DateTime.Now.Year + "/" + DateTime.Now.Month;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "/" + DateTime.Now.Day + ".txt";
                using (StreamWriter stWriter = File.AppendText(path))
                {
                    stWriter.WriteLine("\r\nLog Entry : ");
                    stWriter.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string err = "Error in: " + _errorPage +
                                  ". \r\nError Message:" + _errorMessage;
                    stWriter.WriteLine(err);
                    stWriter.WriteLine("__________________________");
                    stWriter.Flush();
                    stWriter.Close();
                }
            }
            catch
            { }
        }

        public static void WriteException(Exception exp, string _errorPage, string path)
        {
            try
            {
                string _errorMessage = exp.StackTrace;
                path = path + "/" + DateTime.Now.Year + "/" + DateTime.Now.Month;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "/" + DateTime.Now.Day + ".txt";
                using (StreamWriter stWriter = File.AppendText(path))
                {
                    stWriter.WriteLine("\r\nLog Entry : ");
                    stWriter.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string err = "Error in: " + _errorPage +
                                  ". \r\nError Message:" + _errorMessage;
                    stWriter.WriteLine(err);
                    stWriter.WriteLine("__________________________");
                    stWriter.Flush();
                    stWriter.Close();
                }
            }
            catch
            { }
        }

   
    }
}
