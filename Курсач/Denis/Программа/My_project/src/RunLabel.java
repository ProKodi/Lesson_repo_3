


import javax.swing.*;
import java.awt.*;

import java.awt.GraphicsEnvironment;



public class RunLabel extends JLabel {
    /// Текст для вывода
    protected String text = "Test for example";
    /// Получение строки для вывода
    public String get_text(){return this.text;}
    /// Установка строки для вывода
    public void set_text(String text) {this.text = text;}

    /// Задержка
    protected int count_miliseconds = 500;
    /// Установка задержки
    public void set_count_seconds(int count_seconds){this.count_miliseconds = count_seconds;}
    /// Выдача задержки
    public int get_count_miliseconds(){return this.count_miliseconds;}

    /// Шрифт для текста
    protected Font font = new Font(
        GraphicsEnvironment.getLocalGraphicsEnvironment().getAvailableFontFamilyNames()[0],
        Font.PLAIN, 21
    );
    /// Установка шрифта
    public void set_font(Font font){
        this.font = font;
        this.setFont(this.font);
    }
    /// Выдача шрифта
    public Font get_font(){return this.font;}


    /// Количество пробелов для строки
    protected int cout_gaps = 0;
    /// Определение количества пробелов для строки
    public int get_cout_gaps(){return this.cout_gaps;}
    /// Устанавливает количество пробелов
    public void set_cout_gaps(){
        // Определяем метрику шрифта
        FontMetrics metrics = Toolkit.getDefaultToolkit().getFontMetrics(this.font);
        // Определяем количество пробелов для ширины окна
        this.cout_gaps = this.getWidth() / metrics.stringWidth(" ");
    }

    /// Поток для прокручивания строки
    protected Thread_Rem thread_print = new Thread_Rem(this);

    public RunLabel(){super(); this.setFont(this.font);}

    /// Перезапуск строки
    public void reload(){this.thread_print.reload();}

    /// Запуск строки
    public void run_text(){
        this.set_cout_gaps();
        // Если поток работает
        if(this.thread_print.getState() == Thread.State.TIMED_WAITING){return;}
        // Если поток завершен
        if(this.thread_print.getState() == Thread.State.TERMINATED){
            this.thread_print = new Thread_Rem(this.thread_print);
        }
        this.thread_print.start();
    }

    /// Остановка строки
    public void stop_text(){
        if(this.thread_print == null){return;}
        this.thread_print.interrupt();
    }
}

