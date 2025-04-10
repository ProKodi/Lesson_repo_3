




/// Класс потока для вывода текста
public class Thread_Rem extends Thread{
    protected RunLabel lab;
    protected long index;

    public Thread_Rem(RunLabel lab, long index){
        super(); this.lab = lab; this.index = index;
    }

    public Thread_Rem(RunLabel lab){this(lab, 0);}

    public Thread_Rem(Thread_Rem self){this(self.lab, self.index);}

    public void reload(){this.index = 0;}


    public void run(){
        while (true) {
            try{
                for(; this.index <= this.lab.get_text().length(); this.index += 1){
                    this.lab.setText(this.lab.get_text().substring(
                            this.lab.get_text().length() - (int)index
                    ));
                    Thread.sleep((long)this.lab.get_count_miliseconds());
                }
                // Добавляем пробелы
                for(; this.index < (this.lab.get_cout_gaps() + this.lab.get_text().length()); this.index += 1){
                    this.lab.setText(" " + this.lab.getText());
                    Thread.sleep((long)this.lab.get_count_miliseconds());
                }
                // Обнуляем индекс
                this.index = 0;
            }
            catch (InterruptedException e) {break;}
        }
    }
}



