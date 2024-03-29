using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class NuevoProductoPage : ContentPage
{
	public NuevoProductoPage()
	{
		InitializeComponent();
		BindingContext = new NuevoProductoViewModel();
	}

    public NuevoProductoPage(Producto pSeleccionado)
    {
        InitializeComponent();
        BindingContext = new NuevoProductoViewModel(pSeleccionado);
    }
}