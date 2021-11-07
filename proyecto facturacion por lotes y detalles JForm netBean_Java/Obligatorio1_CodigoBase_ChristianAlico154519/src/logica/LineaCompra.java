/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package logica;

import java.util.ArrayList;
       

/**
 *
 * @author Admin
 */
public class LineaCompra {
    private Producto Prod;
    private int Cant;
    private double Total;

    public LineaCompra(Producto Prod, int Cant) {
        this.Prod = Prod;
        this.Cant = Cant;
        this.Total = Prod.getPrecio()*Cant;
    }

    public Producto getProd() {
        return Prod;
    }

    public void setProd(Producto Prod) {
        this.Prod = Prod;
    }

    public int getCant() {
        return Cant;
    }

    public void setCant(int Cant) {
        this.Cant = Cant;
    }

    public double getTotal() {
        return Total;
    }

    public void LlenarFactura(Factura fa){
    
          Producto p = Fachada.getInstancia().buscarP(this.getProd().getCodigo());
                    if (p.getUnidades() > this.getCant()) {
                        fa.agregar(this.getCant(), p);

                    }
    }

   
    
}
