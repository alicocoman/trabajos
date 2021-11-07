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
public class ControlLote {

    private static ControlLote instancia;
    private ArrayList<Lote> lotes = new ArrayList();

    private ControlLote() {
    }

    public synchronized static ControlLote getInstancia() {
        if (instancia == null) {
            instancia = new ControlLote();
        }

        return instancia;
    }

   

    public ArrayList<Lote> getLote(boolean proce) {
        ArrayList<Lote> lote = new ArrayList();
        for (Lote L : lotes) {
            if (L.GetProcesado() == proce) {
                lote.add(L);

            }

        }

        return lote;
    }

    public void AgregarLote(Lote unLote) {

        lotes.add(unLote);

    }

   

}
