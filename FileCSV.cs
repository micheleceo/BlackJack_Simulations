using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
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

         //   StringBuilder csvdata = new StringBuilder();
       //     csvdata.AppendLine(header);

            /* foreach (var o in objectlist)
                 csvdata.AppendLine(ToCsvFields(separator, fields, o));*/

            filecsv.WriteLine(header);

            return header;
        }

        public string WriteData(object o)
        {
            StringBuilder linie = new StringBuilder();

            foreach (var f in fields)
            {
               /* if (linie.Length > 0)
                    linie.Append(Separator);*/

                var x = f.GetValue(o);

                if (x != null)
                    linie.Append(x.ToString()+Separator);
            }

            filecsv.WriteLine(linie);
            return linie.ToString();
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
