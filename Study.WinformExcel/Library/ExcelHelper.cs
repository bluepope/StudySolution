using ClosedXML.Excel;

using ExcelDataReader;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.WinformExcel.Library
{
    public class ExcelHelper
    {
        public static DataTable GetExcelReaderToDataTable(string fileFullPath)
        {
            using (var fileStream = File.Open(fileFullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var edr = ExcelReaderFactory.CreateOpenXmlReader(fileStream);

                var dataSet = edr.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = tableReader => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                return dataSet.Tables[0];
            }
        }

        public static DataTable GetClosedXmlToDataTable(string fileFullPath)
        {
            using (XLWorkbook workBook = new(fileFullPath))
            {
                var workSheet = workBook.Worksheets.FirstOrDefault();

                DataTable dt = new DataTable();

                //컬럼 세팅
                var headerRow = workSheet.Row(1);
                for (int col = 1; col < 1000; col++)
                {
                    //첫째줄을 가져와서
                    var headerCell = headerRow.Cell(col);

                    //column(열)의 수만큼 돌면서 값이 없으면 거기서 종료
                    if (headerCell.Value?.ToString().IsNull() == true)
                    {
                        break;
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn()
                        {
                            ColumnName = headerCell.Address.ColumnLetter,
                            Caption = headerCell.Value.ToString(),
                        });
                    }
                }

                //값 가져오기
                for (int row = 2; row < 100000; row++)
                {
                    //순번값이 비어있으면 중지
                    if (workSheet.Row(row).Cell(1).Value?.ToString().IsNull() == true)
                    {
                        break;
                    }

                    DataRow newRow = dt.NewRow();
                    for (int col = 1; col < dt.Columns.Count + 1; col++)
                    {
                        var cell = workSheet.Row(row).Cell(col);
                        newRow[cell.Address.ColumnLetter] = cell.Value;
                    }
                    dt.Rows.Add(newRow);
                }

                return dt;
            }
        }
    }
}
