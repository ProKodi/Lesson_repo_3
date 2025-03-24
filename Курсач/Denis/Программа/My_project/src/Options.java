




import javax.swing.*;
import java.awt.*;

import java.util.HashMap;
import java.util.function.Function;


class Options extends JDialog{
    protected JTextField text_for_print;
    protected JSpinner count_seconds;

    protected JComboBox<String> font_selected;
    protected JSpinner font_size;
    protected JComboBox<String> font_style;
    protected HashMap<String, Integer> types = new HashMap<>();

    protected JButton save;

    protected RunLabel runlabel = null;


    public Options(String title, RunLabel label){
        super();
        this.runlabel = label;
        this.setTitle(title);
        this.setModalityType(ModalityType.APPLICATION_MODAL);
        this.setMinimumSize(new Dimension(400, 300));
        types.put("Обычное написание", Font.PLAIN);
        types.put("Жирное написание", Font.BOLD);
        types.put("Курсивное написание", Font.ITALIC);


        /*threads.put("При перезапуске строки начинать с места остановки", new Function<RunLabel, IRunThread>() {
            @Override
            public IRunThread apply(RunLabel runLabel) {return new Thread_Rem(runLabel);}
        });*/
        //threads.put("При перезапуске строки начинать с начала");

        this.setLayout(new GridLayout(2, 1));


        /// Ввод текста
        JPanel panel = new JPanel();
        panel.setLayout(new GridLayout(6, 2));
        panel.add(new JLabel("Введите текст для бегущей строки"));

        this.text_for_print = new JTextField();
        panel.add(this.text_for_print);
        this.text_for_print.setText(this.runlabel.get_text());

        /// Ввод задержки
        panel.add(new JLabel("Введите задержку"));
        this.count_seconds = new JSpinner();
        panel.add(this.count_seconds);
        count_seconds.setModel(new SpinnerNumberModel(this.runlabel.get_count_seconds(), 1, 100, 1));

        /// Выбор шрифта
        String[] fonts = GraphicsEnvironment.getLocalGraphicsEnvironment().getAvailableFontFamilyNames();
        Font select_font = this.runlabel.get_font();

        panel.add(new JLabel("Выберете шрифт"));
        font_selected = new JComboBox<>(fonts);
        font_selected.setSelectedItem(select_font.getFontName());
        panel.add(font_selected);

        panel.add(new JLabel("Введите размер шрифта"));
        font_size = new JSpinner();
        font_size.setModel(new SpinnerNumberModel(select_font.getSize(), 6, 100, 1));
        panel.add(font_size);

        panel.add(new JLabel("Начертание шрифта"));
        font_style = new JComboBox<>(types.keySet().toArray(new String[0]));
        panel.add(font_style);

        this.save = new JButton("Сохранить изменения");
        this.save.addActionListener(e -> this.save_option());
        panel.add(this.save);

        this.add(panel);

        this.add(new JPanel());


    }

    void save_option(){
        if(this.text_for_print.getText().length() <= 0){
            JOptionPane.showMessageDialog(this, "Вы не ввели текст для строки", "Ошибка", JOptionPane.ERROR_MESSAGE);
            return;
        }
        this.runlabel.set_text(this.text_for_print.getText());
        this.runlabel.set_count_seconds((int)this.count_seconds.getValue());
        Font new_font = new Font(
                (String)this.font_selected.getSelectedItem(),
                this.types.get((String)this.font_style.getSelectedItem()),
                (int)this.font_size.getValue()
        );
        this.runlabel.set_font(new_font);
        if(!this.text_for_print.getText().equals(this.runlabel.get_text())){
            this.runlabel.reload();
        }
    }
}
