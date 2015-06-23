using BlackthornVisionTask.ViewModels;

namespace BlackthornVisionTask.Views
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow
    {
        public ResultWindow()
        {
            InitializeComponent();
            DataContext = new ResultWindowViewModel();
        }
    }
}
