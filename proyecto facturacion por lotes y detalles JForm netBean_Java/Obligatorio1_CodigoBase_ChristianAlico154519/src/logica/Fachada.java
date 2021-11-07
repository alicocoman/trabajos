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
public class Fachada {
    
    private ControlClientes cCliente = ControlClientes.getInstancia();
    private ControlStock cStock = ControlStock.getInstancia();
    private ControlFacturas cFactura = ControlFacturas.getInstancia();
    private ControlLote cLote = ControlLote.getInstancia();
   
   
    
    private static Fachada instancia = new Fachada();
            
    public static synchronized Fachada getInstancia(){
      if(instancia == null)
            instancia = new Fachada();
        return instancia;
    }
    
    private Fachada(){        
        
    }
    public Cliente buscarCliente(String Ci){
        return cCliente.buscarCliente(Ci);
    
    }

    public ArrayList<Lote> getLote(boolean proce) {
            return cLote.getLote(proce);
    }
    
     public Producto buscarP(int codigo) {
     return cStock.buscarP(codigo);
     }
     
       public boolean agregar(Factura unaFactura) {
       
           return cFactura.agregar(unaFactura);
       }
       
       
     

   

  
    
    
    
    
    
}
