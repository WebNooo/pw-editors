using Helper.Pck;
using System.Collections.ObjectModel;
using System.Windows;

namespace PckEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class SomeVM
    {
        public ObservableCollection<SomeItemVM> Items { get; set; }

        public SomeVM()
        {
            Items = new ObservableCollection<SomeItemVM>();
        }
    }


    public class SomeItemVM
    {
        public string id { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var pck = new Pck();
            pck.Open("E:\\pw152\\element\\configs.pck");

            SomeVM data = new SomeVM();
            data.Items.Add(new SomeItemVM() { id = "3" });
            data.Items.Add(new SomeItemVM() { id = "4" });
            data.Items.Add(new SomeItemVM() { id = "1" });
            data.Items.Add(new SomeItemVM() { id = "2" });

            this.DataContext = data;
        }
    }
}
