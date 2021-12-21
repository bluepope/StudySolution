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
         * 2. Sqlite �� Ef Core�� ���ؼ� �Է�?
         */

        public Form1()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //return true �� ��� ���⼭ �̺�Ʈ�� ����� (Ű �Է��� �Ұ���)
            //return false �� ��� �̺�Ʈ ����
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OnSearch();
        }

        void OnSearch()
        {
            //���� �����ִ� â�� ��ȸ ����� �����Ѵ�

            var module = tabControl1.SelectedTab?.Controls[0];

            if (module != null)
            {
                (module as StudyUserControl).OnSearch();
            }
        }

        void OnSave()
        {
            //���� �����ִ� â�� ���� ����� �����Ѵ�

            var module = tabControl1.SelectedTab?.Controls[0];

            if (module != null)
            {
                (module as StudyUserControl).OnSave();
            }
        }
    }
}