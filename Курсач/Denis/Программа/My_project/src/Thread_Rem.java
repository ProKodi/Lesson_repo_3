




/// Класс потока для вывода текста
public class Thread_Rem extends Thread{
    protected RunLabel lab;
    protected long index = 0;

    public Thread_Rem(RunLabel lab){
        super();
        this.lab = lab;
    }

    public Thread_Rem(Thread_Rem self){
        this(self.lab);
        this.index = self.index;
    }


    public void run(){
        while (true) {
            try{
                String txt = this.lab.get_text();
                int len = txt.length();
                for(; this.index <= len; this.index += 1){
                    this.lab.setText(txt.substring(len - (int)index));
                    Thread.sleep((long)this.lab.get_count_seconds() * 100);
                }
                // Добавляем пробелы
                for(; this.index < (this.lab.get_cout_gaps() + len); this.index += 1){
                    this.lab.setText(" " + this.lab.getText());
                    Thread.sleep((long)this.lab.get_count_seconds() * 100);
                }
                // Обнуляем индекс
                this.index = 0;
            }
            catch (InterruptedException e) {break;}
        }
    }
}



