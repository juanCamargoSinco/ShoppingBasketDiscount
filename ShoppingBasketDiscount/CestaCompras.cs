namespace ShoppingBasketDiscount;

public class CestaCompras
{
    private readonly List<Item> _items = [];
    public IReadOnlyList<Item> Items => _items;

    public void AgregarItem(string nombre, int cantidad, int precio)
    {
        ValidarItem(cantidad, precio);

        var itemExistente = _items.FirstOrDefault(x => x.Nombre == nombre);

        if (itemExistente != null)
        {
            itemExistente.AumentarCantidad(cantidad);
        }
        else
        {
            _items.Add(new Item(nombre, cantidad, precio));
        }

    }


    public int ObtenerCantidadItem(string producto)
    {
        return _items.Where(x => x.Nombre == producto).FirstOrDefault()?.Cantidad ?? 0;
    }

    public decimal CalcularPrecioTotalCesta()
    {
        var subTotal = _items.Sum(x => x.PrecioUnitario * x.Cantidad);
        var tasaDescuento = ObtenerTasaDescuento(subTotal);
        var valorDescuento = subTotal * tasaDescuento;
        var total = subTotal - valorDescuento;
        return total;
    }

    private static decimal ObtenerTasaDescuento(decimal subTotal)
    {
        return subTotal switch
        {
            > 200 => 0.10m,
            > 100 => 0.05m,
            _ => 0m
        };
    }
    private static void ValidarItem(int cantidad, int precio)
    {
        if (precio < 0)
            throw new ArgumentException("Precio invalido");

        if (cantidad < 0)
            throw new ArgumentException("Cantidad invalida");
    }

}