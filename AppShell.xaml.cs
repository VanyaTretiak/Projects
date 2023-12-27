namespace FinalApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GeneralTasksPage), typeof(GeneralTasksPage));
            Routing.RegisterRoute(nameof(AddTasksPage), typeof(AddTasksPage));
            Routing.RegisterRoute(nameof(FutureTasksPage), typeof(FutureTasksPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        }
    }
}