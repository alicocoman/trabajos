package logica;

import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author magda
 */
public class Factura {

    private Cliente cliente;
    private ArrayList<LineaFactura> lineas = new ArrayList();
    private int numero;
    private Date fecha;


  

    public Factura(Cliente cliente) {
        this.cliente = cliente;
    }

    public Date getFecha() {
        return fecha;
    }

    private void setFecha(Date fecha) {
        this.fecha = fecha;
    }

    public int getNumero() {
        return numero;
    }

    public void setNumero(int numero) {
        this.numero = numero;
    }

    public Cliente getCliente() {
        return cliente;
    }

    public void setCliente(Cliente cliente) {
        this.cliente = cliente;
    }

    public ArrayList<LineaFactura> getLineas() {
   
        return lineas;
       
    }

    public boolean agregar(int cantidad, Producto p) {
        if (cantidad <= 0 || p.getUnidades() < cantidad) {
            return false;
        }
        LineaFactura linea = buscar(p);
        if (linea == null) {
            lineas.add(new LineaFactura(p, cantidad));
            return true;
        }
        return linea.incrementar(cantidad);
    }

    public boolean tieneProducto(Producto unP) {
        return buscar(unP) != null;
    }

    public LineaFactura buscar(Producto unP) {
        for (LineaFactura l : lineas) {
            if (l.tieneProducto(unP)) {
                return l;
            }
        }
        return null;
    }

    @Override
    public String toString() {
        return "Factura{" + "cliente=" + cliente + ", lineas=" + lineas + '}';
    }

    public int getTotal() {
        int total = 0;
        for (LineaFactura lf : lineas) {
            total += lf.getTotal();
        }
        return total;
    }

    protected void bajarStock() {
        for (LineaFactura lf : lineas) {
            lf.bajarStock();
        }
    }

    public boolean validar() {
        return getTotal() > 0;
    }

    public void asignarFecha() {
        setFecha(new Date());
    }
}
