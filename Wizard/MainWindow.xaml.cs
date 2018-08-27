using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wizard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            var types = new List<string>() { "C1", "C2", "C3", "C4" };
            var availableRecords = new ObservableCollection<DataRecord>();
            availableRecords.Add(new DataRecord() { Id = 1, Name = "A1", Country = "SGP" });
            availableRecords.Add(new DataRecord() { Id = 2, Name = "A2", Country = "SGP" });
            availableRecords.Add(new DataRecord() { Id = 3, Name = "A3", Country = "SGP" });
            availableRecords.Add(new DataRecord() { Id = 4, Name = "A4", Country = "India" });

            WorkflowTypes = types;
            Records = availableRecords;
            PopupViewModel = new PopupViewModel();
            this.LocationChanged += MainWindow_LocationChanged;
            this.SizeChanged += MainWindow_SizeChanged;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResetPopUp();
        }

        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {

            ResetPopUp();

        }

        private void ResetPopUp()
        {
            var offset = PopupLabel.HorizontalOffset;
            PopupLabel.HorizontalOffset = offset + 1;
            PopupLabel.HorizontalOffset = offset;

            offset = PopupCombo.HorizontalOffset;
            PopupCombo.HorizontalOffset = offset + 1;
            PopupCombo.HorizontalOffset = offset;

            offset = PopupButton.HorizontalOffset;
            PopupButton.HorizontalOffset = offset + 1;
            PopupButton.HorizontalOffset = offset;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<string> workflowTypes;

        private PopupViewModel popupViewModel;

        private ObservableCollection<DataRecord> records;

        public List<string> WorkflowTypes { get => workflowTypes; set
            {
                workflowTypes = value;
                NotifyChanges("WorkflowTypes");
            }
        }
        public ObservableCollection<DataRecord> Records { get => records; set
            {
                records = value;
                NotifyChanges("Records");
            }
        }

        public PopupViewModel PopupViewModel
        {
            get => popupViewModel;
            set
            {
                popupViewModel = value;
                NotifyChanges("PopupViewModel");

            }
        }

        private void NotifyChanges(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var newWindow = new MessageBox();
            //newWindow.ShowDialog();

            
        }
    }

    public class DataRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }


    }

    public class PopupViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChanges(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool showFirstPopup=true;
        private bool showSecondPopup;
        private bool showThirdPopup;

        public bool ShowFirstPopup
        {
            get => showFirstPopup;
            set
            {
                showFirstPopup = value;
                
                NotifyChanges("ShowFirstPopup");
                if (!value)
                    ShowSecondPopup = true;
            }
        }
        public bool ShowSecondPopup
        {
            get => showSecondPopup;
            set
            {
                showSecondPopup = value;
                NotifyChanges("ShowSecondPopup");

                if (!value)
                    ShowThirdPopup = true;
             }
        }
        public bool ShowThirdPopup
        {
            get => showThirdPopup;
            set
            {
                showThirdPopup = value;
                NotifyChanges("ShowThirdPopup");
            }
        }
    }
    
}
