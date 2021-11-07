/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package logica;

import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author magda
 */
public class ControlFacturas {

    private ArrayList<Factura> facturas;
    private int proximoNumeroFactura = 0;
    private static ControlFacturas instancia;

    private ControlFacturas() {
        facturas = new ArrayList();
    }
    
    public static synchronized ControlFacturas getInstancia() {
        if(instancia == null)
            instancia = new ControlFacturas();
        
        return instancia;
    }

    public ArrayList<Factura> getFacturas() {
        return facturas;
    }

    public boolean agregar(Factura unaFactura) {
        if (unaFactura.validar()) {
            facturas.add(unaFactura);
            unaFactura.asignarFecha();
            unaFactura.setNumero(++proximoNumeroFactura);
            unaFactura.bajarStock();
            return true;
        }
        return false;
    }

    public boolean clienteComproProducto(Cliente c, Producto p) {
        boolean ret = false;
        for (Factura f : facturas) {
            if (f.getCliente().equals(c) && f.tieneProducto(p)) {
                ret = true;
            }
        }
        return ret;
    }

    public Factura ultimaCompra(Cliente c, Producto p) {
        Factura ultima = null;
        for (Factura f : facturas) {
            if (f.getCliente() == c && f.tieneProducto(p)) {
                ultima = f;
            }
        }
        return ultima;
    }

  

    
}
