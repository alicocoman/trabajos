package main;

import logica.Cliente;
import logica.Compra;
import logica.ControlClientes;
import logica.ControlFacturas;
import logica.ControlLote;
import logica.ControlStock;
import logica.Factura;
import logica.LineaCompra;
import logica.Lote;
import logica.Producto;
import logica.Proveedor;

/**
 *
 * @author magda
 */
public class DatosPrueba {

    public static void cargar() {

        Proveedor elFerreteroInc = new Proveedor("El Ferretero Inc.");
        Proveedor steelman = new Proveedor("Steelman Corp.");

        Producto tornillo = new Producto("Tornillo", 2, 80000, elFerreteroInc);
        Producto arandela = new Producto("Arandela", 1, 50000, elFerreteroInc);
        Producto tuerca = new Producto("Tuerca", 3, 10000, elFerreteroInc);
        Producto bulon = new Producto("Bulon", 4, 10000, elFerreteroInc);
        Producto destornillador = new Producto("Destornillador", 15, 200, steelman);
        Producto nivelLaser = new Producto("Nivel laser", 75, 1, steelman);
        Producto tenaza = new Producto("Tenaza", 25, 1, steelman);
        Producto pinzas = new Producto("Pinzas", 20, 1, steelman);

        Cliente juan = new Cliente("11111111", "Juan");
        Cliente ana = new Cliente("22222222", "Ana");
        Cliente pedro = new Cliente("33333333", "Pedro");
        Cliente maria = new Cliente("44444444", "Maria");

        Factura f01 = new Factura(ana);
        f01.agregar(10, tornillo);
        f01.agregar(20, arandela);

        Factura f02 = new Factura(pedro);
        f02.agregar(100, tuerca);
        f02.agregar(100, bulon);
        f02.agregar(2, pinzas);
        
    
        
        ///////////////////////////////////////////////////////////////////////

        ControlStock.getInstancia().agregar(steelman);
        ControlStock.getInstancia().agregar(elFerreteroInc);

        ControlStock.getInstancia().agregar(tornillo);
        ControlStock.getInstancia().agregar(arandela);
        ControlStock.getInstancia().agregar(tuerca);
        ControlStock.getInstancia().agregar(bulon);
        ControlStock.getInstancia().agregar(destornillador);
        ControlStock.getInstancia().agregar(nivelLaser);
        ControlStock.getInstancia().agregar(tenaza);
        ControlStock.getInstancia().agregar(pinzas);

        ControlClientes.getInstancia().agregar(juan);
        ControlClientes.getInstancia().agregar(ana);
        ControlClientes.getInstancia().agregar(pedro);
        ControlClientes.getInstancia().agregar(maria);

        ControlFacturas.getInstancia().agregar(f01);
        ControlFacturas.getInstancia().agregar(f02);
        
        
           Lote l01 = new Lote("001","Lote ferretería");
        LineaCompra i1 = new LineaCompra(tornillo,100);
        LineaCompra i2 = new LineaCompra(arandela,100);
        Compra compra = new Compra("11111111");
        compra.agregarLineaCompra(i1);
        compra.agregarLineaCompra(i2);
        l01.getListaCompras().add(compra);

        Compra compra2 = new Compra("22222222");
        LineaCompra i3 = new LineaCompra(tuerca,25);
        LineaCompra i4 = new LineaCompra(bulon,25);
        LineaCompra i5 = new LineaCompra(arandela,25);
        compra2.agregarLineaCompra(i3);
        compra2.agregarLineaCompra(i4);
        compra2.agregarLineaCompra(i5);
        l01.getListaCompras().add(compra2);

        Lote l02 = new Lote("002","Lote pinturas");


        Lote l03 = new Lote("003","Lote de herramientas");
        Compra compra3 = new Compra("33333333");
        LineaCompra i6 = new LineaCompra(destornillador,5);
        LineaCompra i7 = new LineaCompra(nivelLaser,2);
        compra3.agregarLineaCompra(i6);
        compra3.agregarLineaCompra(i7);
        l03.getListaCompras().add(compra3);

        Compra compra4 = new Compra("44444444");
        LineaCompra i8 = new LineaCompra(tenaza,5);
        LineaCompra i9 = new LineaCompra(pinzas,5);
        compra4.agregarLineaCompra(i8);
        compra4.agregarLineaCompra(i9);
        l03.getListaCompras().add(compra4);


        ControlLote.getInstancia().AgregarLote(l01);
        ControlLote.getInstancia().AgregarLote(l02);
        ControlLote.getInstancia().AgregarLote(l03);
        /**
         * Agregar datos de pruebas de lotes aqui.
         * (Se pueden agregar proveedores, productos, clientes y facturas, 
         * pero no modificar los datos provistos)
         */
        
    }
}
