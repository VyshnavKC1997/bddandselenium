using OpenQA.Selenium.DevTools.V118.Page;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testSelenium.ExcelData;

namespace testSelenium.Utilities
{
    /*convert the excel sheet rows into properties of the class and return The object*/
    static class ExcelSheetObjectCreation
    {
        public static Func<DataRow, UserClass> Func = (row) =>
        {
            return new UserClass
            {/*
                Id = row["Id"].ToString(),
                Name = row["Name"].ToString(),
                Gender = row["Gender"].ToString(),
                Email = row["Email"].ToString(),
                Status = row["Status"].ToString(),*/
            };
        };
    }
}
