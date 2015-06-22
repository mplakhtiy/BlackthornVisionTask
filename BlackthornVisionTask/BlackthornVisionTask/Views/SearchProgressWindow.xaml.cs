using BlackthornVisionTask.ViewModels;

namespace BlackthornVisionTask.Views
{
    /// <summary>
    /// Interaction logic for SearchProgressWindow.xaml
    /// </summary>
    public partial class SearchProgressWindow
    {
        public SearchProgressWindow()
        {
            InitializeComponent();
            DataContext = new SearchProgressWindowViewModel();
        }
    }
}
