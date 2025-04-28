namespace ShoppingBasketDiscount;

public class CestaCompras
{
    private readonly List<Item> _items = [];
    public IReadOnlyList<Item> Items => _items;

    public void AgregarItem(Item item)
    {
        ValidarItem(item);

        var itemExistente = _items.FirstOrDefault(x => x.Nombre == item.Nombre);

        if (itemExistente != null)
        {
            itemExistente.AumentarCantidad(item.Cantidad);
        }
        else
        {
            _items.Add(new Item(item.Nombre, item.Cantidad, item.PrecioUnitario));
        }
    }


    public int ObtenerCantidadItem(string producto)
    {
        return _items.Where(x => x.Nombre == producto).FirstOrDefault()?.Cantidad ?? 0;
    }

    public decimal CalcularPrecioTotalCesta()
    {
        var subTotal = _items.Sum(x => x.PrecioTotal);
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
    private static void ValidarItem(Item item)
    {
        if (item.PrecioUnitario < 0)
            throw new ArgumentException("Precio invalido");

        if (item.Cantidad < 0)
            throw new ArgumentException("Cantidad invalida");
    }

}