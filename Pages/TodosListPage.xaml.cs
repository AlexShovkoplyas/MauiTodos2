using MauiTodos2.ViewModels;

namespace MauiTodos2.Pages;

public partial class TodosListPage : ContentPage
{
	public TodosListPage(TodosListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}