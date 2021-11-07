package main;
import UI.Menu;




public class Inicio {

    public static void main(String[] args) throws Exception {
        DatosPrueba.cargar();
        new Menu().setVisible(true);
        // Inicializar aquie el menu principal
    }
}
