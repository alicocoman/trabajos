package logica;

/**
 *
 * @author magda
 */
public class LineaFactura {

    private Producto producto;
    private int cantidad;

    public LineaFactura(Producto producto, int cantidad) {
        this.producto = producto;
        this.cantidad = cantidad;
    }

    public Producto getProducto() {
        return producto;
    }

    public void setProducto(Producto producto) {
        this.producto = producto;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public boolean tieneProducto(Producto unP) {
        return this.getProducto() == unP;
    }

    @Override
    public String toString() {
        return "LineaFactura{" + "producto=" + producto + ", cantidad=" + cantidad + '}';
    }

    public int getTotal() {
        return cantidad * producto.getPrecio();
    }

    public boolean incrementar(int cuanto) {
        if (cantidad + cuanto <= producto.getUnidades()) { //hay stock?
            cantidad += cuanto;
            return true;
        }
        return false;
    }

    public void bajarStock() {
        producto.modificarUnidades(cantidad * -1);
    }
}
