



/// <summary>Класс стек тудентов</summary>
class Stack_Student{
    protected Stack<Student> students = new Stack<Student>();

    /// <summary>Добавляем элемент в стек</summary>
    /// <param name="obj"></param>
    public void append(Student obj){students.Push(obj);}


}