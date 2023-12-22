using ExcelDataReader;
using OpenQA.Selenium.DevTools.V118.Page;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSelenium.Utilities
{
    /*A Generic class for reading data from excel sheet
    and to convert into list of class objects in exceldata*/
    internal class ExcelUtils<T>
    {
        public static List<T> ReadExcelData(string excelfilepath,string sheetName, Func<DataRow, T> func)
        {

            List<T> excelDatas = new();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelfilepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables[sheetName];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        /*func is used to point to the function that matches the signature*/
                        var excelData = func(row);

                        excelDatas.Add(excelData);
                    }
                }
            }
            return excelDatas;
        }
    }
}
