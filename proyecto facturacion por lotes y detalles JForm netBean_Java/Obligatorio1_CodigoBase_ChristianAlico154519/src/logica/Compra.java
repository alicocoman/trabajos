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
public class Compra {
    
    private String Cedula;
    private ArrayList<LineaCompra> lineasCompra = new ArrayList();
    private Factura factura;
    private double Total;
    
    public Factura getFactura() {
      
            return factura;
      
      
    }

    public void setFactura(Factura factura) {
        this.factura = factura;
    }
    
   

    public Compra(String Cedula) {
        this.Cedula = Cedula;
    }

    public String getCedula() {
        return Cedula;
    }

    public void setCedula(String Cedula) {
        this.Cedula = Cedula;
    }

    public ArrayList<LineaCompra> getLineasCompra() {
        return lineasCompra;
    }

    public void setLineasCompra(ArrayList<LineaCompra> lineasCompra) {
        this.lineasCompra = lineasCompra;
    }

    public double getTotal() {
        return Total;
    }

    public void setTotal(double Total) {
        this.Total = Total;
    }
    
    public void agregarLineaCompra(LineaCompra unaLinea){
        lineasCompra.add(unaLinea);
        
    }

    public void ProcesarCompra() {
        
        Cliente Cli = Fachada.getInstancia().buscarCliente(this.getCedula());
        
                Factura fa = new Factura(Cli);
                
                this.setFactura(fa);
                
                for (LineaCompra li : this.getLineasCompra()) {
                  
                    li.LlenarFactura(fa);

                }
                if (fa.getLineas().size() > 0) {
                    Fachada.getInstancia().agregar(fa);
                   
                }else{
                this.factura= null;
                
                }
                
    }
    
    
    
}
