using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class EditProductoPage : ContentPage
{
	public EditProductoPage(Producto pEditar)
	{
		InitializeComponent();
		BindingContext = new EditProductoViewModel(pEditar);
	}

}