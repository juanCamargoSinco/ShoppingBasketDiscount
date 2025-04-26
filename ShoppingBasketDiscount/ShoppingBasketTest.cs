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
        }

        [Fact]
        public void Si_AgregoUnItemA_Debe_MostrarCantidadItemAEnUno()
        {
            //Arrange
            var cesta = new CestaCompras();

            //Act
            cesta.AgregarItem("Item A", 1, 10);

            //Assert
            Assert.Equal(1, cesta.ObtenerCantidadItem("Item A"));
        }


        [Fact]
        public void Si_AgregoUnItemConCantidadNegativa_Debe_LanzarExcepcion()
        {
            //Arrange
            var cesta = new CestaCompras();

            //Act
            var action = () => cesta.AgregarItem("Item A", -1, 10);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Si_AgregoUnItemConPrecioNegativo_Debe_LanzarExcepcion()
        {
            //Arrange
            var cesta = new CestaCompras();

            //Act
            var action = () => cesta.AgregarItem("Item A", 1, -10);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Si_AgregoSieteItemA_Debe_MostrarCantidadItemAEnSiete()
        {
            //Arrange
            var cesta = new CestaCompras();

            //Act
            cesta.AgregarItem("Item A", 1, 10);
            cesta.AgregarItem("Item A", 4, 10);
            cesta.AgregarItem("Item A", 2, 10);

            //Assert
            Assert.Equal(7, cesta.ObtenerCantidadItem("Item A"));
        }

        [Fact]
        public void Si_AgregoUnMismoItemVariasVeces_No_Debe_RepetirseItemEnLaListaDeItems()
        {
            //Arrange
            var cesta = new CestaCompras();

            //Act
            cesta.AgregarItem("Item A", 1, 10);
            cesta.AgregarItem("Item A", 1, 10);
            cesta.AgregarItem("Item A", 1, 10);
            cesta.AgregarItem("Item A", 1, 10);

            //Assert
            Assert.Equal(1, cesta.Items.Count(x => x.Nombre == "Item A"));

        }

        [Fact]
        public void Si_CestaComprasTieneUnItem_Debe_TotalSerPrecioProducto()
        {
            //Arrange
            var cesta = new CestaCompras();
            cesta.AgregarItem("Item A", 1, 10);

            //Assert
            Assert.Equal(10, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TengoMultiplesItems_Debe_TotalSerSumatoriaDePrecioPorCantidadDeLosMultipesItems()
        {
            //Arrange
            var cesta = new CestaCompras();

            //Act
            cesta.AgregarItem("Item A", 2, 10);
            cesta.AgregarItem("Item B", 2, 20);
            cesta.AgregarItem("Item C", 1, 15);

            //Assert
            Assert.Equal(75, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TotalPrecioCestaEsMayora100_Debe_AplicarDescuentoDel5Porciento()
        {
            //Arrange
            var cesta = new CestaCompras();
            cesta.AgregarItem("Item A", 5, 10);
            cesta.AgregarItem("Item B", 3, 20);
            cesta.AgregarItem("Item C", 1, 30);


            //Assert
            Assert.Equal(133, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TotalPrecioCestaEs100_No_Debe_AplicarDescuento()
        {
            //Arrange
            var cesta = new CestaCompras();
            cesta.AgregarItem("Item A", 10, 10);

            //Assert
            Assert.Equal(100, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TotalPrecioCestaEsMayora200_Debe_AplicarDescuentoDel10Porciento()
        {
            //Arrange
            var cesta = new CestaCompras();
            cesta.AgregarItem("Item A", 10, 10);
            cesta.AgregarItem("Item B", 5, 20);
            cesta.AgregarItem("Item C", 1, 30);


            //Assert
            Assert.Equal(207, cesta.CalcularPrecioTotalCesta());
        }

        [Fact]
        public void Si_TotalPrecioCestaEs200_Debe_AplicarDescuentoDel5Porciento()
        {
            //Arrange
            var cesta = new CestaCompras();
            cesta.AgregarItem("Item A", 20, 10);

            //Assert
            Assert.Equal(190, cesta.CalcularPrecioTotalCesta());
        }

    }
}