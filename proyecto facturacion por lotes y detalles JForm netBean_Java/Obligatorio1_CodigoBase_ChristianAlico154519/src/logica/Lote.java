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
 * @author Admin
 */
public class Lote {
    private ArrayList<Compra> listaCompras = new ArrayList();
    private String Id;
    private String Descripcion;
    private boolean Procesado;

    public Date getFecha() {
        return fecha;
    }
    public int FacXlote(){
        int facturas=0;
        for(Compra c:listaCompras){
            if(c.getFactura()!=null ){
            facturas++;
            }
        
        }
        return facturas;
    }
    public int MontoFacturas(){
    
        int total=0;
        for(Compra c:listaCompras){
            if(c.getFactura()!=null){
                total+=c.getFactura().getTotal();
            }
        
        }
        
        
        return total;
    
    }

    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }
    private Date fecha;

    public void setProcesado(boolean Procesado) {
        this.Procesado = Procesado;
    }

    public Lote(String Id, String Descripcion) {
        this.Id = Id;
        this.Descripcion = Descripcion;
        this.Procesado = false;
    }

    public boolean GetProcesado(){
    return this.Procesado;
    }
    public ArrayList<Compra> getListaCompras() {
        return listaCompras;
    }

    public void setListaCompras(ArrayList<Compra> listaCompras) {
        this.listaCompras = listaCompras;
    }

    public String getId() {
        return Id;
    }

    public void setId(String Id) {
        this.Id = Id;
    }

    public String getDescripcion() {
        return Descripcion;
    }

    public void setDescripcion(String Descripcion) {
        this.Descripcion = Descripcion;
    }
    
    public void agregarCompra(Compra unaCompra){
        
        this.listaCompras.add(unaCompra);
    }
    
    public boolean ProLote(){
        
         if (this == null) {
            return false;
        }

        if (this.getListaCompras().size()==0) {
            return false;
        } else {
            this.setProcesado(true);
            this.setFecha(new Date());
            for (Compra c : this.getListaCompras()) {
                 // cambiar para compra
                 
                 c.ProcesarCompra();
               
            }

        }
        return true;

        
        
   
    }
    
}
