using ClosedXML.Excel;

using ExcelDataReader;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study.WinformExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new())
            {
                openFileDialog.CheckFileExists = true;
                openFileDialog.DefaultExt = "xlsx";

                //파일 선택 창 띄우기
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string fileFullPath = openFileDialog.FileName; // fullPath
                    txtFileName.Text = fileFullPath;

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
                            if (headerCell.Value?.ToString() == "")
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
                            if (workSheet.Row(row).Cell(1).Value?.ToString() == "")
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

                        dataGridView1.DataSource = dt;
                        
                        foreach(DataGridViewColumn column in dataGridView1.Columns)
                        {
                            //(DataTable)column.DataGridView.DataSource //casting 강제 형이 맞지 않거나 문제가 생기면 Exception
                            //column.DataGridView.DataSource as DataTable //안되면 null

                            column.HeaderText = (column.DataGridView.DataSource as DataTable)?.Columns[column.Name].Caption;
                        }
                    }
                }
            }
        }

        private void btnImport2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new())
            {
                openFileDialog.CheckFileExists = true;
                openFileDialog.DefaultExt = "xlsx";

                //파일 선택 창 띄우기
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string fileFullPath = openFileDialog.FileName; // fullPath
                    txtFileName.Text = fileFullPath;

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

                        dataGridView1.DataSource = dataSet.Tables[0];
                    }
                }
            }
        }
    }
}
