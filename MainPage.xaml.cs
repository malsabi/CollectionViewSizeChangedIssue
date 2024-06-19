using System.Collections.ObjectModel;

namespace CollectionViewSizeChangedIssue
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ObservableCollection<AssessmentModel> list = [];
            for (int i = 0; i < 100; i++)
            {
                list.Add(new AssessmentModel()
                {
                    ProgramName = "International Assessment " + i.ToString(),
                    CourseName = "English " + i.ToString(),
                    DueDate = DateTime.Now.ToShortDateString()
                });
            }
            CView.ItemsSource = list;
        }
    }
}