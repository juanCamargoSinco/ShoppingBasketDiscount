namespace ShoppingBasketDiscount;

public class Item(string nombre, int cantidad, decimal precio)
{
    public string Nombre { get; } = nombre;
    public int Cantidad { get; private set; } = cantidad;
    public decimal PrecioUnitario { get; } = precio;

    public void AumentarCantidad(int cantidad)
    {
        Cantidad += cantidad;
    }
}