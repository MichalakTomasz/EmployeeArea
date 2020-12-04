using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EmployeeArea.TimeSheets.Views
{
    public partial class ViewTimeSheets : UserControl
    {
        public ViewTimeSheets()
        {
            InitializeComponent();
            DispatcherTimer asf = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            asf.Tick += Asf_Tick;
            asf.Start();
        }

        private void Asf_Tick(object sender, EventArgs e)
        {
            timer.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
