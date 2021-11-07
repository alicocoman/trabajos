/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package UI;

import java.util.ArrayList;
import javax.swing.JOptionPane;
import javax.swing.table.DefaultTableModel;
import logica.Compra;
import logica.Lote;
import logica.Fachada;
import logica.LineaFactura;

/**
 *
 * @author Admin
 */
public class ConsultaDeLotes extends javax.swing.JFrame {

    ArrayList<Lote> lotesProcesados = Fachada.getInstancia().getLote(true);
    ArrayList<Compra> compraSeleccionada;

    /**
     * Creates new form ConsultaDeLotes
     */
    public ConsultaDeLotes() {
        initComponents();
        LotesAProcesar();

        setLocationRelativeTo(null);

    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        tablaLote = new javax.swing.JTable();
        compras = new javax.swing.JLabel();
        facturas = new javax.swing.JLabel();
        monto = new javax.swing.JLabel();
        jScrollPane2 = new javax.swing.JScrollPane();
        tablaCompras = new javax.swing.JTable();
        jScrollPane3 = new javax.swing.JScrollPane();
        tablaFacturas = new javax.swing.JTable();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Consultar Lotes Procesados");

        tablaLote.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {

            }
        ));
        tablaLote.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tablaLoteMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(tablaLote);

        tablaCompras.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {},
                {},
                {},
                {}
            },
            new String [] {

            }
        ));
        tablaCompras.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tablaComprasMouseClicked(evt);
            }
        });
        jScrollPane2.setViewportView(tablaCompras);

        tablaFacturas.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {},
                {},
                {},
                {}
            },
            new String [] {

            }
        ));
        jScrollPane3.setViewportView(tablaFacturas);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 375, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(43, 43, 43)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(facturas)
                            .addComponent(compras)
                            .addComponent(monto)))
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jScrollPane3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap(468, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(77, 77, 77)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 107, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(compras)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(facturas)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(monto)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 100, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 83, Short.MAX_VALUE)
                .addComponent(jScrollPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 107, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void tablaLoteMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tablaLoteMouseClicked
        seleccionarLote(tablaLote.getSelectedRow());
    }//GEN-LAST:event_tablaLoteMouseClicked

    private void tablaComprasMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tablaComprasMouseClicked

        
        seleccionarCompra(tablaCompras.getSelectedRow());
    }//GEN-LAST:event_tablaComprasMouseClicked

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(ConsultaDeLotes.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(ConsultaDeLotes.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(ConsultaDeLotes.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(ConsultaDeLotes.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new ConsultaDeLotes().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel compras;
    private javax.swing.JLabel facturas;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JLabel monto;
    private javax.swing.JTable tablaCompras;
    private javax.swing.JTable tablaFacturas;
    private javax.swing.JTable tablaLote;
    // End of variables declaration//GEN-END:variables

    public void LotesAProcesar() {
        jScrollPane2.setVisible(false);
        jScrollPane3.setVisible(false);
        DefaultTableModel datos = new DefaultTableModel();
        datos.addColumn("Id");
        datos.addColumn("Descripcion");
        datos.addColumn("Cantidad de compras");

        int fila = 0;
        datos.setNumRows(lotesProcesados.size());

        for (Lote L : lotesProcesados) {

            datos.setValueAt(L.getId(), fila, 0);
            datos.setValueAt(L.getDescripcion(), fila, 1);
            datos.setValueAt(L.getListaCompras().size(), fila, 2);
            fila++;

        }
        tablaLote.setModel(datos);

    }

    private void seleccionarLote(int selectedRow) {
   
        if (selectedRow != -1) {
            Lote selec = lotesProcesados.get(selectedRow);
            compras.setText("Cantidad de compras del lote: " + selec.getListaCompras().size());
            facturas.setText("Cantidad de facturas generadas: " + selec.FacXlote());
            monto.setText("Monto total facturado por lote: " + selec.MontoFacturas());
            ListaCompras(selectedRow);
          jScrollPane2.setVisible(true);
            jScrollPane3.setVisible(true);
        }

    }

    private void ListaCompras(int selectedRow) {
         Lote unLote= lotesProcesados.get(selectedRow);
       compraSeleccionada = new ArrayList(unLote.getListaCompras());
        ArrayList<Compra> comprasDelLote = unLote.getListaCompras();
        DefaultTableModel datos2 = new DefaultTableModel();
        datos2.addColumn("Cliente");
        datos2.addColumn("Nombre");
        datos2.addColumn("Cant Item Compras");
        datos2.addColumn("Cant Item Factura");
        datos2.addColumn("Monto de la Factura");

        int fila = 0;
        datos2.setNumRows(comprasDelLote.size());

        for (Compra c:comprasDelLote) {
           
            datos2.setValueAt(c.getCedula(), fila, 0);
            datos2.setValueAt(Fachada.getInstancia().buscarCliente(c.getCedula()).getNombre(), fila, 1);
            datos2.setValueAt(c.getLineasCompra().size(), fila, 2);
            if(c.getFactura()==null){
            datos2.setValueAt(0, fila, 3);
            datos2.setValueAt(0, fila, 4);
            
            }else{
             datos2.setValueAt(c.getFactura().getLineas().size(), fila, 3);
             datos2.setValueAt(c.getFactura().getTotal(), fila, 4);
            }
            
            
            fila++;

        }
        tablaCompras.setModel(datos2);

    }

    private void seleccionarCompra(int selec) {
          DefaultTableModel datos3 = new DefaultTableModel();
        
        
        if (selec != -1) {
           Compra seleccionada = compraSeleccionada.get(selec);
           if(seleccionada.getFactura()!=null){
           
              datos3.addColumn("Cantidad");
              datos3.addColumn("Nombre del Producto");
              datos3.addColumn("Subtotal");
                int fila = 0;
                
                datos3.setNumRows(seleccionada.getFactura().getLineas().size());
                 if (seleccionada.getFactura().getLineas().size() > 0) {
                        for (LineaFactura LiFa : seleccionada.getFactura().getLineas()) {
                            datos3.setValueAt(LiFa.getCantidad(), fila, 0);
                            datos3.setValueAt(LiFa.getProducto().getNombre(), fila, 1);
                            datos3.setValueAt(LiFa.getTotal(), fila, 2);
                            fila++;

                        }
                
           } 
               
               
               
         }else {

                        JOptionPane.showMessageDialog(this, "No hay facturas");
                        datos3.setNumRows(0);
                    }
                    tablaFacturas.setModel(datos3);
        }
       
      

    }
}