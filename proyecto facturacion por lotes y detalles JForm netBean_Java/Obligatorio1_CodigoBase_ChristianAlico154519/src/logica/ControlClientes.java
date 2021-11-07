/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package logica;

import java.util.ArrayList;

/**
 *
 * @author magda
 */
public class ControlClientes {

    private static ControlClientes instancia;
    private ArrayList<Cliente> clientes = new ArrayList();

    private ControlClientes() {
    }
    
    public synchronized static ControlClientes getInstancia() {
        if(instancia == null)
            instancia = new ControlClientes();
        
        return instancia;
    }

    public ArrayList<Cliente> getClientes() {
        return clientes;
    }

    public ArrayList clientesNoCompraronProductoMenorPrecio() {
        return clientesCompraronOnoProductoMenorPrecio(false);
    }

    public ArrayList clientesCompraronProductoMenorPrecio() {
        return clientesCompraronOnoProductoMenorPrecio(true);
    }

    private ArrayList clientesCompraronOnoProductoMenorPrecio(boolean compraron) {
        Producto menor = ControlStock.getInstancia().getProductoMenorPrecio();
        ArrayList<Cliente> retorno = new ArrayList<Cliente>();

        for (Cliente c : clientes) {
            if (ControlFacturas.getInstancia().clienteComproProducto(c, menor) == compraron) {
                retorno.add(c);
            }
        }
        return retorno;
    }

    public boolean existeCliente(Cliente c) {
        return clientes.contains(c);
    }

    public boolean agregar(Cliente c) {
        boolean ok = false;
        if (c.validar() && !this.existeCliente(c)) {
            clientes.add(c);
            ok = true;
        }
        return ok;
    }

    public Cliente buscarCliente(String cedula) {
        if (cedula == null || cedula.trim().isEmpty()) {
            return null;
        }
        for (Cliente c : clientes) {
            if (c.getCedula().equals(cedula)) {
                return c;
            }
        }
        return null;
    }
}
