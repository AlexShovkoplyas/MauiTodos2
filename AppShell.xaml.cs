using MauiTodos2.ViewModels;

namespace MauiTodos2
{
    public partial class AppShell : Shell
    {
        private readonly AppShellViewModel viewModel;

        public AppShell(AppShellViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //some initialization
        }
    }
}
