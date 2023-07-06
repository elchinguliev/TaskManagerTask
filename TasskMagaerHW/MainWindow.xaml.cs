using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TasskMagaerHW.Commands;

namespace TasskMagaerHW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        
        public ObservableCollection<Process> Processes { get; set; }

        public RelayCommand EndProcessCommand { get; set; }
        public RelayCommand AddProcessCommand { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Processes = new   ObservableCollection<Process>    (Process.GetProcesses());


   

            EndProcessCommand = new RelayCommand((obj) =>
            {
                if (processListView.SelectedItem is null)
                {
                    return;
                }
                if (processListView.SelectedItem is Process process)
                {
                    try
                    {
                        process.Kill();
                        Processes.Remove(process);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            });

            AddProcessCommand = new RelayCommand((obj) =>
            {
                if (string.IsNullOrEmpty(createProcessTxt.Text))
                {
                    MessageBox.Show("Write proccess you want to create");
                    return;
                }

                try
                {
                    var createProccess = Process.Start(createProcessTxt.Text);

                }
                catch (Exception )
                {

                    MessageBox.Show("Can not found such a program");
                }

            });
        }
    }
}
