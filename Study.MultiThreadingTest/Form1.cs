using Study.MultiThreadingTest.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study.MultiThreadingTest
{
    public partial class Form1 : Form
    {
        BackgroundWorker BackgroundWorker1 { get; set; } = new BackgroundWorker();
        Thread Thread1 { get; set; }

        CancellationTokenSource _cts;
        CancellationTokenSource _cts2;

        Form1ViewModel _viewModel = new Form1ViewModel();

        public Form1()
        {
            InitializeComponent();

            //BackgroundWorker1.WorkerReportsProgress = true;
            BackgroundWorker1.WorkerSupportsCancellation = true;
            BackgroundWorker1.DoWork += BackgroundWorker1_DoWork;

            //lblProgressPercent.DataBindings.Add(new Binding("Text", _viewModel, "PercentText"));
            lblProgressPercent.DataBindings.Add(new Binding(nameof(lblProgressPercent.Text), _viewModel, nameof(_viewModel.PercentText)));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.btnTaskCancel.Enabled = false;
            this.btnControlGridCancel.Enabled = false;
            this.btnViewModelGridCancel.Enabled = false;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //1. 이렇게 하면 UI Thread 에서 동작하기때문에 UI 동작 자체가 차단된다.
            /*
            this.lblThreadId.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            for (int i=0; i <= 100; i++)
            {
                this.lblProgressPercent.Text = i.ToString();
            }
            */

            //2. Task가 없던시절 그리고 Winform 객체를 이용하는 BackgroundWorker 의 사용 별도의 Thread를 이용하는 방법
            if (BackgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                BackgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (BackgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                BackgroundWorker1.CancelAsync();
            }
        }

        void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Thread.CurrentThread.ManagedThreadId
            BackgroundWorker worker = this.BackgroundWorker1;

            int threadId = Thread.CurrentThread.ManagedThreadId;

            Invoke(new MethodInvoker(() =>
            {
                //여기서부터는 UI 스레드영역
                this.lblThreadId.Text = threadId.ToString();
            }));

            for (int i = 0; i <= 100; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(200);

                    //현재의 스레드가 UI 스레드가 맞는가??
                    if (InvokeRequired)
                    {
                        //아니면 현재 Form의 Invoke를 통해 UI 스레드에서 호출하도록
                        Invoke(new MethodInvoker(() =>
                        {
                            //여기서부터는 UI 스레드영역
                            this.lblProgressPercent.Text = i.ToString();
                        }));
                    }
                    else //아니면 그냥 현재의 스레드에서 동작할건지
                    {
                        this.lblProgressPercent.Text = i.ToString();
                    }
                }
            }
        }

        void Thread1_DoWork()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Invoke(new MethodInvoker(() =>
            {
                //여기서부터는 UI 스레드영역
                this.lblThreadId.Text = threadId.ToString();
            }));

            try
            {
                for (int i = 0; i <= 100; i++)
                {
                    System.Threading.Thread.Sleep(200);

                    //현재의 스레드가 UI 스레드가 맞는가??
                    if (InvokeRequired)
                    {
                        //아니면 현재 Form의 Invoke를 통해 UI 스레드에서 호출하도록
                        Invoke(new MethodInvoker(() =>
                        {
                            //여기서부터는 UI 스레드영역
                            this.lblProgressPercent.Text = i.ToString();
                        }));
                    }
                    else //아니면 그냥 현재의 스레드에서 동작할건지
                    {
                        this.lblProgressPercent.Text = i.ToString();
                    }
                    //}
                }
            }
            catch (ThreadInterruptedException)
            {
            }
        }

        private void btnThreadRun_Click(object sender, EventArgs e)
        {
            if (this.Thread1?.ThreadState == ThreadState.Running)
                return;

            this.Thread1 = new Thread(Thread1_DoWork);
            this.Thread1.Start();
        }

        private void btnThreadCancel_Click(object sender, EventArgs e)
        {
            this.Thread1.Interrupt(); //스레드 중지 후
            this.Thread1.Join(); //Thread1 을 UI 스레드로 합친다
        }

        private async void btnTaskRun_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            this.btnTaskCancel.Enabled = true;

            _cts = new CancellationTokenSource();

            var task = Task.Run(() =>
            {
                //최초 실행하자마자 취소요청이 들어왔는지 확인
                _cts.Token.ThrowIfCancellationRequested();

                int threadId = Thread.CurrentThread.ManagedThreadId;

                Invoke(new MethodInvoker(() =>
                {
                    //여기서부터는 UI 스레드영역
                    this.lblThreadId.Text = threadId.ToString();
                }));

                for (int i = 0; i <= 100; i++)
                {
                    //작업중 취소요청이 있는지 확인
                    if (_cts.Token.IsCancellationRequested)
                    {
                        // Clean up here, then...
                        _cts.Token.ThrowIfCancellationRequested();
                    }

                    System.Threading.Thread.Sleep(200);

                    //현재의 스레드가 UI 스레드가 맞는가??
                    if (InvokeRequired)
                    {
                        //아니면 현재 Form의 Invoke를 통해 UI 스레드에서 호출하도록
                        Invoke(new MethodInvoker(() =>
                        {
                            //여기서부터는 UI 스레드영역
                            //this.lblProgressPercent.Text = i.ToString();
                            _viewModel.PercentText = i.ToString();
                        }));
                    }
                    else //아니면 그냥 현재의 스레드에서 동작할건지
                    {
                        //this.lblProgressPercent.Text = i.ToString();
                        _viewModel.PercentText = i.ToString();
                    }
                    //}
                }
            }, _cts.Token);

            try
            {
                await task;
            }
            catch (OperationCanceledException ex)
            {
                //ex.Message
            }
            finally
            {
                (sender as Button).Enabled = true;
                this.btnTaskCancel.Enabled = false;
            }
        }

        private void btnTaskCancel_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }

        private async void btnControlGridRun_Click(object sender, EventArgs e)
        {
            _viewModel.SampleDataList.Clear();

            _viewModel.SampleDataList.Add(new SampleData() { Col1 = "1" });
            _viewModel.SampleDataList.Add(new SampleData() { Col1 = "2" });
            _viewModel.SampleDataList.Add(new SampleData() { Col1 = "3" });

            this.dataGridView1.DataSource = _viewModel.SampleDataList;

            (sender as Button).Enabled = false;
            this.btnControlGridCancel.Enabled = true;

            _cts2 = new CancellationTokenSource();

            var task = Task.Run(() =>
            {
                //최초 실행하자마자 취소요청이 들어왔는지 확인
                _cts2.Token.ThrowIfCancellationRequested();

                for (int i = 0; i <= 100; i++)
                {
                    //작업중 취소요청이 있는지 확인
                    if (_cts2.Token.IsCancellationRequested)
                    {
                        // Clean up here, then...
                        _cts2.Token.ThrowIfCancellationRequested();
                    }

                    System.Threading.Thread.Sleep(200);

                    Invoke(new MethodInvoker(() =>
                    {
                        //여기서부터는 UI 스레드영역
                        dataGridView1.Rows[i % 3].Cells["Column1"].Value = i.ToString();
                    }));
                    
                }
            }, _cts2.Token);

            try
            {
                await task;
            }
            catch (OperationCanceledException ex)
            {
                //ex.Message
            }
            finally
            {
                (sender as Button).Enabled = true;
                this.btnControlGridCancel.Enabled = false;
            }
        }

        private void btnControlGridCancel_Click(object sender, EventArgs e)
        {
            _cts2.Cancel();
        }

        private async void btnViewModelGridRun_Click(object sender, EventArgs e)
        {
            _viewModel.SampleDataList.Clear();

            _viewModel.SampleDataList.Add(new SampleData() { Col1 = "1" });
            _viewModel.SampleDataList.Add(new SampleData() { Col1 = "2" });
            _viewModel.SampleDataList.Add(new SampleData() { Col1 = "3" });

            this.dataGridView1.DataSource = _viewModel.SampleDataList;

            (sender as Button).Enabled = false;
            this.btnControlGridCancel.Enabled = true;

            _cts2 = new CancellationTokenSource();

            var task = Task.Run(() =>
            {
                //최초 실행하자마자 취소요청이 들어왔는지 확인
                _cts2.Token.ThrowIfCancellationRequested();

                for (int i = 0; i <= 100; i++)
                {
                    //작업중 취소요청이 있는지 확인
                    if (_cts2.Token.IsCancellationRequested)
                    {
                        // Clean up here, then...
                        _cts2.Token.ThrowIfCancellationRequested();
                    }

                    System.Threading.Thread.Sleep(200);

                    if (InvokeRequired)
                    {
                        //아니면 현재 Form의 Invoke를 통해 UI 스레드에서 호출하도록
                        Invoke(new MethodInvoker(() =>
                        {
                            //여기서부터는 UI 스레드영역
                            //this.lblProgressPercent.Text = i.ToString();
                            _viewModel.SampleDataList[i % 3].Col1 = i.ToString();
                        }));
                    }
                    else //아니면 그냥 현재의 스레드에서 동작할건지
                    {
                        //this.lblProgressPercent.Text = i.ToString();
                        _viewModel.SampleDataList[i % 3].Col1 = i.ToString();
                    }
                }
            }, _cts2.Token);

            try
            {
                await task;
            }
            catch (OperationCanceledException ex)
            {
                //ex.Message
            }
            finally
            {
                (sender as Button).Enabled = true;
                this.btnControlGridCancel.Enabled = false;
            }
        }

        private void btnViewModelGridCancel_Click(object sender, EventArgs e)
        {
            _cts2.Cancel();
        }
    }
}
