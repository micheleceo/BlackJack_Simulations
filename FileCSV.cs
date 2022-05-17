using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    /// <summary>
    /// Classe utiliy che permette di scrivere un file .csv a partire da una classe generica
    /// </summary>
    class FileCSV
    {
        /// <summary>
        /// Gestione del del file .csv
        /// </summary>
        private StreamWriter filecsv { get; }
        private PropertyInfo[] fields;
        private string Separator;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="path"></param>
        public FileCSV(string path)
        {
            filecsv = new StreamWriter(path);
        }

        /// <summary>
        /// Scrittura dell' header
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="separator"></param>
        /// <param name="oggetto"></param>
        /// <returns></returns>
        public string WriteHeader<T>(string separator,T oggetto)
        {
            Separator = separator;
            Type t = typeof(T);
            fields = t.GetProperties();

            string header = String.Join(separator, fields.Select(f => f.Name).ToArray());

            filecsv.WriteLine(header);

            return header;
        }
        /// <summary>
        /// Write CSV line
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string WriteLine(object o)
        {
            StringBuilder line = new StringBuilder();

            foreach (var f in fields)
            {
               /* if (linie.Length > 0)
                    linie.Append(Separator);*/

                var x = f.GetValue(o);

                if (x != null)
                    line.Append(x.ToString()+Separator);
            }

            filecsv.WriteLine(line);
            return line.ToString();
        }
    

    /// <summary>
    /// FLush e chiusura del file
    /// </summary>
    public void Close()
        {
            filecsv.Flush();
            filecsv.Close();
        }
    }
}
