using Study.Controls;
using Study.Core.Contexts;
using Study.Core.Entities;
using Study.Module.Manage;

using System.Reflection;

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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //return true 의 경우 여기서 이벤트가 종료됨 (키 입력이 불가능)
            //return false 의 경우 이벤트 전파
            switch (keyData)
            {
                case (Keys.Control | Keys.S):
                    OnSave();
                    return true;

                case (Keys.F2):
                    OnSearch();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OnSearch();
        }

        void OnSearch()
        {
            //현재 열려있는 창의 조회 기능을 실행한다

            var module = tabControl1.SelectedTab?.Controls[0];

            if (module != null)
            {
                (module as StudyUserControl).OnSearch();
            }
        }

        void OnSave()
        {
            //현재 열려있는 창의 저장 기능을 실행한다

            var module = tabControl1.SelectedTab?.Controls[0];

            if (module != null)
            {
                (module as StudyUserControl).OnSave();
            }
        }
    }
}