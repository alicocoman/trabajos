package logica;

/**
 *
 * @author magda
 */
public class Producto {

    private String nombre;
    private int precio;
    private int unidades;
    private Proveedor proveedor;
    private int codigo;

    public Producto() {
    }

    public Producto(String nombre, int precio, int stock, Proveedor proveedor) {
        this.nombre = nombre;
        this.precio = precio;
        this.unidades = stock;
        this.proveedor = proveedor;
    }

    public int getUnidades() {
        return unidades;
    }

    public boolean setUnidades(int unidades) {
        if (validarUnidades(unidades)) {
            this.unidades = unidades;
            return true;
        }
        return false;
    }

    public Proveedor getProveedor() {
        return proveedor;
    }

    public void setProveedor(Proveedor proveedor) {
        this.proveedor = proveedor;
    }

    public int getPrecio() {
        return precio;
    }

    public boolean setPrecio(int precio) {
        if (validarPrecio(precio)) {
            this.precio = precio;
            return true;
        }
        return false;
    }

    public String getNombre() {
        return nombre;
    }

    public boolean setNombre(String nombre) {

        if (validarNombre(nombre)) {
            this.nombre = nombre.trim();
            return true;
        }
        return false;
    }

    @Override
    public String toString() {
        return "Producto{" + "nombre=" + nombre + ", precio=" + precio + ", unidades=" + unidades + ", proveedor=" + proveedor + ", codigo=" + codigo + '}';
    }

    public void setCodigo(int cod) {
        codigo = cod;
    }

    public boolean validar() {
        return validarProveedor(proveedor) && validarNombre(nombre) && validarPrecio(precio) && validarUnidades(unidades);
    }

    private boolean validarNombre(String nombre) {
        if (nombre == null) {
            return false;
        }
        nombre = nombre.trim();
        return !nombre.equals("");
    }

    private boolean validarPrecio(int precio) {
        return precio > 0;
    }

    private boolean validarUnidades(int unidades) {
        return unidades > 0;
    }

    private boolean validarProveedor(Proveedor proveedor) {
        return proveedor != null;
    }

    public int getCodigo() {
        return codigo;
    }

    protected void modificarUnidades(int valor) {
        unidades += valor;
    }
}
