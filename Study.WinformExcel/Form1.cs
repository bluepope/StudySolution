using ClosedXML.Excel;

using ExcelDataReader;

using Study.WinformExcel.Library;

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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dataGridView1.ReadOnly = false;
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

                    dataGridView1.DataSource = ExcelHelper.GetExcelReaderToDataTable(fileFullPath);

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        //(DataTable)column.DataGridView.DataSource //casting 강제 형이 맞지 않거나 문제가 생기면 Exception
                        //column.DataGridView.DataSource as DataTable //안되면 null

                        column.HeaderText = (column.DataGridView.DataSource as DataTable)?.Columns[column.Name].Caption;
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

                    dataGridView1.DataSource = ExcelHelper.GetExcelReaderToDataTable(fileFullPath);
                }
            }
        }

       

        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileFullPath = txtFileName.Text;

            using (XLWorkbook workBook = new(fileFullPath))
            {
                //0 1 2 --> 이런 순서로 하는 경우 0을 지우고 1로 넘어갈때,
                //0을 지우는 순간 1이 0으로 바뀌기때문에 Collection이 변경되었습니다 Exception 발생
                //그렇기때문에 Remove등으로 지울때는 항상 역순으로 삭제
                for(int i = workBook.Worksheets.Count; i > 0; i--)
                {
                    workBook.Worksheets.Delete(i);
                }

                //Excel의 ListObject로 저장됩니다
                workBook.Worksheets.Add(dataGridView1.DataSource as DataTable);

                workBook.Save();
            }
        }
    }
}
