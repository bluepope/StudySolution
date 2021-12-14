using Study.Core.Contexts;
using Study.Core.Entities;
using Study.ProjectApp1.Commons;

namespace Study.ProjectApp1
{
    public partial class Form1 : Form
    {
        /*
         * 1. Excel Load
         * 2. Sqlite �� Ef Core�� ���ؼ� �Է�?
         */

        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Text == "�ο�����") //�̰� ���� �����ִ� �޴��� �ƴ϶��?
            {
                if (tabControl1.TabPages.ContainsKey(e.Node.Text) == true)
                    return;

                var tabPage = new TabPage()
                {
                    Name = e.Node.Text,
                    Text = e.Node.Text,
                };
                tabPage.Controls.Add(new PersonManger());

                tabControl1.TabPages.Add(tabPage);
            }
        }
    }
}