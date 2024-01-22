using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProductoViewModel
    {
        public ObservableCollection<Producto> ListaProductos { get; set; }

        public ProductoViewModel() 
        {
            Util.ListaProductos = App.productoRepository.GetAll();
            ListaProductos = new ObservableCollection<Producto>(Util.ListaProductos);
            App.productoRepository.ProductoAgregado += ProductoRepository_ProductoAgregado;
        }

        private void ProductoRepository_ProductoAgregado(object sender, EventArgs e)
        {
            Util.ListaProductos = App.productoRepository.GetAll();
            ListaProductos = new ObservableCollection<Producto>(Util.ListaProductos);
        }

        public ICommand CrearProducto =>
            new Command(async () =>
            {
               await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoPage());
            });

        public ICommand EditarProducto => 
            new Command<Producto>(async (productoSeleccionado) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new EditProductoPage(productoSeleccionado));
            });

        public ICommand VerProducto =>
            new Command<Producto>(async (productoSeleccionado) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoPage(productoSeleccionado));
            });

        public ICommand EliminarProducto =>
            new Command<Producto>(async (productoSeleccionado) =>
            {
                bool validacion = await App.Current.MainPage.DisplayAlert(
                    "Eliminacion de Producto",
                    "Seguro deseas eliminar el producto seleccionado?",
                    "Sí",
                    "No"
                );
                if (validacion)
                {
                    App.productoRepository.Delete(productoSeleccionado);
                }
            });

    }
}
