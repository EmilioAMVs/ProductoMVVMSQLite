using ProductoMVVMSQLite.Models;
using PropertyChanged;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EditProductoViewModel
    {
        public Producto ProductoEditar { get; set; }

        public EditProductoViewModel(Producto productoSeleccionado)
        {
            ProductoEditar = productoSeleccionado;
        }

        public ICommand EditarProducto =>
            new Command( async () => 
            {
                Producto productoEditado = new Producto
                {
                    Nombre = ProductoEditar.Nombre,
                    Descripcion = ProductoEditar.Descripcion,
                    Cantidad = ProductoEditar.Cantidad
                };

                App.productoRepository.Update(productoEditado);
                await App.Current.MainPage.Navigation.PopAsync();
            });
    }
}
