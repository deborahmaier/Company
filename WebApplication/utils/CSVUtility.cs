using System.Data;
using WebApplication.data;
using WebApplication.Models;

namespace WebApplication.utils
{
    public static class CSVUtility
    {
        static Personnel personnel = new Personnel();
        static Salary salary = new Salary();

        public static DataTable createDataTable()
        {
            DataTable table = new DataTable();
            //columns 
            table.Columns.Add("NAME", typeof(string));
            table.Columns.Add("SURNAME", typeof(string));
            table.Columns.Add("GROSS INCOME", typeof(double));
            table.Columns.Add("MONTH", typeof(int));
            table.Columns.Add("YEAR", typeof(int));
            table.Columns.Add("NET INCOME", typeof(double));

            table.ToCSV("Salary.csv"); // PREGUNTAR 
            //data  
            for (int i = 0; i < salary.SalaryItems.Count; i++)
                table.Rows.Add(personnel.Name, personnel.Surname, salary.GrossIncome, salary.Month, salary.Year, salary.NetIncome());

            return table;
        }
        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

  
    }
}
