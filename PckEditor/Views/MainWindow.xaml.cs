using PckEditor.ViewModel;
using System.Text;
using System.Windows;

namespace PckEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            InitializeComponent();
            DataContext = new MainViewModel();

           
        }
    }
}
