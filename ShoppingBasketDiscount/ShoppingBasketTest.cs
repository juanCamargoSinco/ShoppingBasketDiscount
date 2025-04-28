namespace ShoppingBasketDiscount
{
    public class ShoppingBasketTest
    {

        [Fact]
        public void Si_ConsultoUnItemNoAgregado_Debe_MostrarCantidadItemEnCero()
        {
            //Arrange
            var cesta = new CestaCompras();

            //Assert
            Assert.Equal(0, cesta.ObtenerCantidadItem("Item A"));
            //Tambien se podria cambiar a que si consulto un item que no esta en la lista devuelva excepcion
        }

        [Fact]
        public void Si_AgregoUnItemA_Debe_MostrarCantidadItemAEnUno()
        {
            //Arrange
            var cesta = new CestaCompras();
            var item = new Item("Item A", 1, 10);

            //Act
            cesta.AgregarItem(item);

            //Assert
            Assert.Equal(1, cesta.ObtenerCantidadItem(item.Nombre));
        }


        [Fact]
        public void Si_AgregoUnItemConCantidadNegativa_Debe_LanzarExcepcion()
        {
            //Arrange
            var cesta = new CestaCompras();
            var item = new Item("Item A", -1, 10);

            //Act
            var agregarItem = () => cesta.AgregarItem(item);

            //Assert
            var exception = Assert.Throws<ArgumentException>(agregarItem);
            Assert.Equal("Cantidad invalida", exception.Message);
        }

        [Fact]
        public void Si_AgregoUnItemConPrecioNegativo_Debe_LanzarExcepcion()
        {
            //Arrange
            var cesta = new CestaCompras();
            var item = new Item("Item A", 1, -10);

            //Act
            var agregarItem = () => cesta.AgregarItem(item);

            //Assert
            var exception = Assert.Throws<ArgumentException>(agregarItem);
            Assert.Equal("Precio invalido", exception.Message);
        }

        [Fact]
        public void Si_AgregoTresItemA_Debe_MostrarCantidadItemAEnTres()
        {
            //Arrange
            var cesta = new CestaCompras();
            var item = new Item("Item A", 1, 10);

            //Act
            cesta.AgregarItem(item);
            cesta.AgregarItem(item);
            cesta.AgregarItem(item);

            //Assert
            Assert.Equal(3, cesta.ObtenerCantidadItem(item.Nombre));
        }

        [Fact]
        public void Si_AgregoUnMismoItemVariasVeces_No_Debe_RepetirseItemEnLaListaDeItems()
        {
            //Arrange
            var cesta = new CestaCompras();
            var item = new Item("Item A", 1, 10);

            //Act
            cesta.AgregarItem(item);
            cesta.AgregarItem(item);
            cesta.AgregarItem(item);
            cesta.AgregarItem(item);

            //Assert
            int cantidadRepeticionesElementoEnCesta = cesta.Items.Count(x => x.Nombre == item.Nombre);
            Assert.Equal(1, cantidadRepeticionesElementoEnCesta);

        }

        [Fact]
        public void Si_CestaComprasTieneUnItem_Debe_TotalSerPrecioProducto()
        {
            //Arrange
            var cesta = new CestaCompras();
            var item = new Item("Item A", 1, 10);
            cesta.AgregarItem(item);

            //Assert
            Assert.Equal(10, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TengoMultiplesItems_Debe_TotalSerSumatoriaDePrecioPorCantidadDeLosMultipesItems()
        {
            //Arrange
            var cesta = new CestaCompras();
            var itemA = new Item("Item A", 2, 10);
            var itemB = new Item("Item B", 2, 20);
            var itemC = new Item("Item C", 1, 15);

            //Act
            cesta.AgregarItem(itemA);
            cesta.AgregarItem(itemB);
            cesta.AgregarItem(itemC);

            //Assert
            Assert.Equal(75, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TotalPrecioCestaEsMayora100_Debe_AplicarDescuentoDel5Porciento()
        {
            //Arrange
            var cesta = new CestaCompras();
            var itemA = new Item("Item A", 5, 10);
            var itemB = new Item("Item B", 3, 20);
            var itemC = new Item("Item C", 1, 30);
            cesta.AgregarItem(itemA);
            cesta.AgregarItem(itemB);
            cesta.AgregarItem(itemC);


            //Assert
            Assert.Equal(133, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TotalPrecioCestaEs100_No_Debe_AplicarDescuento()
        {
            //Arrange
            var cesta = new CestaCompras();
            var item = new Item("Item A", 10, 10);
            cesta.AgregarItem(item);

            //Assert
            Assert.Equal(100, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TotalPrecioCestaEsMayora200_Debe_AplicarDescuentoDel10Porciento()
        {
            //Arrange
            var cesta = new CestaCompras();
            var itemA = new Item("Item A", 10, 10);
            var itemB = new Item("Item B", 5, 20);
            var itemC = new Item("Item C", 1, 30);
            cesta.AgregarItem(itemA);
            cesta.AgregarItem(itemB);
            cesta.AgregarItem(itemC);


            //Assert
            Assert.Equal(207, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TotalPrecioCestaEs200_Debe_AplicarDescuentoDel5Porciento()
        {
            //Arrange
            var cesta = new CestaCompras();
            var itemA = new Item("Item A", 20, 10);
            cesta.AgregarItem(itemA);

            //Assert
            Assert.Equal(190, cesta.CalcularPrecioTotalCesta());
        }

    }
}