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

namespace Study.ProjectApp1
{
    public partial class PersonManger : UserControl
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
    }
}
