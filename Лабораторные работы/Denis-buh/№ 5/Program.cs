﻿



/* Создать абстрактный класс Человек с полями:
    год рождения, пол, фамилия, имя. 

Предусмотреть виртуальный метод
    вывода данных на экран // (ToString?)
    и вычисления возраста. 

? Абстрактный класс должен содержать хотя бы один абстрактный метод. ?

Функции вывода данных объявить виртуальной в базовом классе и 
    переопределить ее в производных классах


На его [абстрактный класс Человек] основе создать классы: 
    Пациент больницы (с указанием шифра заболевания и даты госпитализации), 
    Врач (специальность, должность), 
    Пациент поликлиники (дата прохождения диспансеризации, диспансерный учет (да, нет). 
    
Создать объекты всех производных классов и продемонстрировать работу всех методов производных классов.

Согласно варианту, список объектов (не менее 6 элементов), информацию о которых размещать в модальном окне. 
Создать список объектов класса Врач, модифицировать его, удалив всех терапевтов.
Элементы списка выводить в одном компоненте, например, в ListBox.
При модификации списков в программе на форме использовать переключатель типа CheckBox.

В проекте использовать непрямоугольные формы. 

Построить UML-диаграмму классов программы
*/



internal static class Program{
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main(){
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainWindow());
        //Application.Run(new ShowInform.ShowInform());
    }
}

