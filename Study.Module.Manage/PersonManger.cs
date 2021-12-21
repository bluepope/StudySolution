using Study.Controls;
using Study.Core.Contexts;
using Study.Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study.Module.Manage
{
    public partial class PersonManger : StudyUserControl
    {
        public PersonManger()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var context = new StudyContext())
            {
                context.StudyPersons?.Add(new StudyPersonEntity()
                {
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    BirthDate = dtBitrhDate.Value
                });

                context.SaveChanges();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var context = new StudyContext())
            {
                dataGridView1.DataSource = context.StudyPersons?.Where(s => 1 == 1).ToList();
            }
        }

        public override void OnSearch()
        {
            base.OnSearch();

            //기능 실행
            System.Windows.Forms.MessageBox.Show("조회 버튼 클릭");
        }
    }
}
