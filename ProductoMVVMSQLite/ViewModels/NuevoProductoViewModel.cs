using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using PropertyChanged;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class NuevoProductoViewModel
    {
        public bool CreacionDeProducto { get; private set; }
        public bool SoloLectura { get; private set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }


        public NuevoProductoViewModel()
        {
            CreacionDeProducto = true;
            SoloLectura = false;
        }

        public NuevoProductoViewModel(Producto productoSeleccionado)
        {
            CreacionDeProducto = false;
            SoloLectura = true;
            Nombre = productoSeleccionado.Nombre;
            Cantidad = productoSeleccionado.Cantidad.ToString();
            Descripcion = productoSeleccionado.Descripcion;
        }

        public ICommand CrearProducto =>
            new Command(async () =>
            {
                Producto producto = new Producto
                {
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    Cantidad = Int32.Parse(Cantidad)
                };
                App.productoRepository.Add(producto);
                Util.ListaProductos = App.productoRepository.GetAll();

                await App.Current.MainPage.Navigation.PopAsync();
            });

    }
}
