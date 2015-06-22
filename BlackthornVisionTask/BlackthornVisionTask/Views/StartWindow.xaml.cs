using BlackthornVisionTask.ViewModels;

namespace BlackthornVisionTask.Views
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow
    {
        public StartWindow()
        {
            InitializeComponent();
            DataContext = new StartWindowViewModel();
        }
    }
}
