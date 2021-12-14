using Study.Core.Contexts;
using Study.Core.Entities;
using Study.ProjectApp1.Commons;

namespace Study.ProjectApp1
{
    public partial class Form1 : Form
    {
        /*
         * 1. Excel Load
         * 2. Sqlite 에 Ef Core를 통해서 입력?
         */

        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Text == "인원관리") //이고 현재 열려있는 메뉴가 아니라면?
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