package logica;

import java.util.ArrayList;

public class ControlStock {

    private ArrayList<Producto> productos = new ArrayList();
    private ArrayList<Proveedor> proveedores = new ArrayList();
    private int proximoCodigoproducto = 0;
    
    private static ControlStock instancia;

    private ControlStock() {
    }
    
    public synchronized static ControlStock getInstancia() {
        if (instancia == null)
            instancia = new ControlStock();
        
        return instancia;
    }

    public ArrayList<Producto> getProductos() {
        return productos;
    }

    public ArrayList<Proveedor> getProveedores() {
        return proveedores;
    }

    public Producto getProductoMenorPrecio() {
        Producto menor = productos.get(0);
        Producto p;
        for (int x = 1; x < productos.size(); x++) {
            p = productos.get(x);
            if (p.getPrecio() < menor.getPrecio()) {
                menor = p;
            }
        }
        return menor;
    }

    public void agregar(Proveedor unProveedor) {
        proveedores.add(unProveedor);
    }

    public boolean agregar(Producto unProducto) {

        if (unProducto.validar()) {
            unProducto.setCodigo(generarCodigoProducto());
            productos.add(unProducto);
            unProducto.getProveedor().agregar(unProducto);
            return true;
        }
        return false;
    }

    private int generarCodigoProducto() {
        proximoCodigoproducto++;
        return proximoCodigoproducto;
    }

    public Producto buscarP(int codigo) {
        for (Producto p : productos) {
            if (p.getCodigo() == codigo) {
                return p;
            }
        }
        return null;
    }
    
    
    
}
