



import javax.swing.*;
import java.awt.*;

import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;




public class MainWindow extends JFrame {
    protected RunLabel label = null;


    public MainWindow(String title) {
        super(title);
        this.setMinimumSize(new Dimension(400, 100));
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);


        JMenuBar menuBar = new JMenuBar();


        JMenuItem option = new JMenuItem("Опции");
        option.setCursor(new Cursor(Cursor.HAND_CURSOR));
        option.addMouseListener(new java.awt.event.MouseAdapter() {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt ) {
                Options wind = new Options("Опции", label);
                wind.setVisible(true);
            }
        });
        menuBar.add(option);


        JMenuItem start_string = new JMenuItem("Запустить строку");
        start_string.setCursor(new Cursor(Cursor.HAND_CURSOR));
        start_string.addMouseListener(new java.awt.event.MouseAdapter() {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt ) {label.run_text();}
        });
        menuBar.add(start_string);

        JMenuItem reload = new JMenuItem("Остановить строку");
        reload.setCursor(new Cursor(Cursor.HAND_CURSOR));
        reload.addMouseListener(new java.awt.event.MouseAdapter() {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt ) {label.stop_text();}
        });
        menuBar.add(reload);




        addComponentListener(new ComponentListener() {
            @Override
            public void componentResized(ComponentEvent e) {label.set_cout_gaps();}
            @Override
            public void componentMoved(ComponentEvent e) {}
            @Override
            public void componentShown(ComponentEvent e) {}
            @Override
            public void componentHidden(ComponentEvent e) {}
        });

        this.label = new RunLabel("Test for example", 2);


        this.setJMenuBar(menuBar);
        this.add(this.label, BorderLayout.NORTH);
    }



}
