



/// Грузим css для работы формы
$("head").append(
    $(`<link rel="stylesheet" href="./test_form.css">`)
);


/// Варианты добавления элемент на форму
enum Anchor{
    Left = 1,
    Center = 2,
    Right = 3,
}


/// Класс реализующий функционал оверлея
class OverLay{
    // Создаем оверлей 
    public readonly overlay = $("<div id='overlay'></div>");

    public constructor(readonly parent: JQuery<HTMLElement>){
        // Удяляем старый оверлей (если он есть)
        $("#overlay").remove();
        
        // Клик по фону закрывает оверлей
        this.overlay.on("click", 
            function(e: any): void{
                if(e.target == $("#overlay")[0]){ 
                    OverLay.close(); 
                }
            }
        );
        parent.append(this.overlay);
    }

    /// Закрытие оверлея
    public static close(): void{
        $("#overlay").css("display", "none");
    }

    /// Добавление поля на оверлей
    public append(child: JQuery<HTMLElement>): void{ this.overlay.append(child); }

    /// Показ оверлея
    public show(): Promise<void>{
        return new Promise((resolve) => {
            this.overlay.css("display", "flex");
        });
    }
}


/// Класс реализующий хеадер формы
class HeaderForm{
    /// Хеадер формы
    public readonly data_form_header = $(`<header id = "data_form_header"></header>`);

    public constructor(readonly parent: JQuery<HTMLElement>){
        parent.append(this.data_form_header);
    }

    /// Добавление элемента на форму
    public append(child: JQuery<HTMLElement>, anc: Anchor = Anchor.Left): void{ 
        let css_style: any = { display: "flex", "justify-self": "flex-start", };

        switch(anc){
            case(Anchor.Left): {
                css_style["justify-self"] = "flex-start";
                break;
            }
            case(Anchor.Center): {
                css_style["justify-self"] = "center";
                break;
            }
            case(Anchor.Right): {
                css_style["justify-self"] = "flex-end";
                break;

            }
        }
        this.data_form_header.append(child.css(css_style));
    }
}


/// Класс реализующий функционал заголовка таблицы
class HeaderTableInput{
    // Заголовок таблицы
    public readonly table_head = $(` <thead id="table-head"> </thead> `);

    // Строка заголовка таблицы
    public readonly row_header = $(`<tr></tr>`);

    // Название колонки с названиями полей
    public readonly first_field_header = $(`<th class="first_col">Название поля</th>`);
    // Название колонки с значениями полей
    public readonly second_field_header = $(`<th class="second_col">Данные для поля</th>`);


    public constructor(readonly parent: JQuery<HTMLElement>){
        this.row_header.append(this.first_field_header)
        this.row_header.append(this.second_field_header)

        this.table_head.append(this.row_header);

        parent.append(this.table_head);
    }

    /// Изменения виджета для первого заголовка
    public change_first_header(new_widget: JQuery<HTMLElement>){
        this.first_field_header.empty();
        this.first_field_header.append(new_widget);
    }

    /// Изменения виджета для второго заголовка
    public change_second_header(new_widget: JQuery<HTMLElement>){
        this.second_field_header.empty();
        this.second_field_header.append(new_widget);
    }
}

class BodyTableInput{
    // Тело таблицы
    public readonly table_body = $(`<tbody id="table-body"></tbody>`);

    public constructor(readonly parent: JQuery<HTMLElement>){
        parent.append(this.table_body);
    }

    public append_row(label: string, id: string, type: string = "text"): void{
        let row_container = $("<tr></tr>");
        row_container.append($(`<td><p>${label}</p></td>`).css({
            width: "20%",
        }));
        row_container.append($(`<td><input type = ${type} id = ${id}></td>`).css({
            width: "80%",
        }));
        
        this.table_body.append(row_container);
    }
}


/// Класс реализующий функционал таблицы для ввода данных
class TableInput{
    // Заголовок таблицы
    public readonly table_head: HeaderTableInput;

    // Тело таблицы
    public readonly table_body: BodyTableInput;

    /// Добавляем таблицу на форму
    public readonly table_form = $(`
        <table id = "table_form">
        </table>
    `);

    public constructor(readonly parent: JQuery<HTMLElement>){
        // Добавляем заголовок
        this.table_head = new HeaderTableInput(this.table_form)

        // Добавляем тело таблицы
        this.table_body = new BodyTableInput(this.table_form);

        parent.append(this.table_form);
    }

}


abstract class BaseInputForm{
    /// Оверлей
    public readonly overlay: OverLay;

    /// Окно для формы
    public readonly window_form = $(`<div id = "window_form"></div>`);

    /// Форма окна
    public readonly data_form = $(`<form id = "data_form"></form>`); 

    /// Хеадер формы
    public readonly data_form_header: HeaderForm;

    /// Добавляем таблицу на форму
    public readonly table_form: TableInput; 

    /// Строка кнопок
    public readonly row_bt = $(`<div id = "row_bt"></div>`);
    // Кнопка очистки
    public readonly bt_clear = $(`
        <button type="reset" id="bt_clear">
            <img src="https://api.iconify.design/lucide:eraser.svg?color=%230F172A&amp;width=16&amp;height=16" alt="Clear icon" id="irhyi-2" class="icon-clear"/>
            <span>Clear</span>
        </button>   
    `);
    // Кнопка закрытия
    public readonly bt_close = $(`
        <button type="button" id="bt_close">
            <img src="https://api.iconify.design/lucide:x.svg?color=%230F172A&amp;width=16&amp;height=16" >
            <p>Close</p>
        </button>
    `);
    // Кнопка сохранения
    public readonly bt_save = $(`
        <button type="submit" id="bt_save">
            <img src="https://api.iconify.design/lucide:save.svg?color=%23FFFFFF&amp;width=16&amp;height=16" alt="Save icon" id="i3ixg-2" >
            <span>Save</span>
        </button>
    `);





    public constructor(){
        /// Работа с Хеадером формы
        this.data_form_header = new HeaderForm(this.data_form);


        /// Работа с таблицей формы
        this.table_form = new TableInput(this.data_form);


        /// Работа с строкой кнопок
        this.bt_save.on("click", function(){
            console.log(12345);
        });
        this.row_bt.append(this.bt_save);

        this.bt_close.on("click", OverLay.close);
        this.row_bt.append(this.bt_close);
        this.row_bt.append(this.bt_clear);
        this.data_form.append(this.row_bt)

        this.window_form.append(this.data_form);

        this.overlay = new OverLay($("body")); 
        this.overlay.append(this.window_form);
    }


    /// Показ формы
    public async show(): Promise<void>{ return this.overlay.show() }


}



class TableInputForm extends BaseInputForm{

}

/*
abstract class BaseInputForm{
    /// Стиль строки для таблицы
    public abstract style_row: any; 
    /// Стиль ячейки
    public abstract style_cell: any; 


    /// Оверлей
    public readonly overlay: OverLay;


    /// Форма
    public readonly form = $('<div id="popupForm"></div>').css({

        zindex: 9999,
    }); 
    /// Форма с элементами
    public readonly form_items = $('<div></div>').css({
        background: "#262641",

        display: 'table',  */         /* Контейнер как таблица */
        /*bordercollapse: 'collapse',
        width: '100%',
        
        position: "fixed",
        top:"50%",
        left:"50%",
        transform: "translate(-50%, -50%)",

        padding: "3%",

    }); 

    /// Строка с кнопками
    public row_bt = $('<div></div>').css({
        background: "#1B1B2F",
        width: "100%",  

        margintop: "1%", 
        paddingright: "1%",

        display: "flex",
        justifycontent: "flex-end",*/ /* выравниваем по правому краю */
        /*gap: "1%",*/ /* расстояние между элементами */

        /*position: "sticky",
        bottom: "0px",

    });
    /// Кнопка закрытия формы
    public closeBtn = $('<button id = "close_overlay">Закрыть</button>');


    public constructor(){ 
        this.overlay = new OverLay($("body")); 
        // Закрытие формы
        this.closeBtn.on("click", OverLay.close);
        // Вставляем форму в оверлей
        this.overlay.append(this.form);
    }


    /// Добавление поля запроса на форму
    public append_row(name: string, id: string, type: string): void{

        let row = $("<div></div>").css(this.style_row);

        row.append(
            $(`<div>${`<label>${name}</label>`}</div>`).css(this.style_cell)
        );

        row.append(
            $(`<div>${`<input id = ${id} type = ${type}>`}</div>`).css(this.style_cell)
        );

        this.form_items.append(row);
    }

    /// Добавление поля запроса на форму
    public append_row_html(widget: JQuery<HTMLElement>): void{
        this.form_items.append(widget);
    }

    /// Показ формы
    public async show(): Promise<void>{
        this.form.append(this.form_items);
        this.row_bt.append(this.closeBtn);
        this.form.append(this.row_bt);

        return this.overlay.show()
    }
}


class TableForm extends BaseInputForm{
    // Стиль строки для таблицы
    public style_row = {
        display: "table-row",
    }

    // Стиль ячейки
    public style_cell = {
        display: "table-cell", 
        border: "1px solid #555",
        padding: "0.5rem",
        textalign: "center",
        verticalalign: "middle",
    }

    public style_form = {
        background: "#262641",

        display: 'table',*/           /* Контейнер как таблица */
        /*bordercollapse: 'collapse',
        width: '100%',
        
        position: "fixed",
        top:"50%",
        left:"50%",
        transform: "translate(-50%, -50%)",

        padding: "3%",
    }

    public constructor(){
        super();
    }
}
*/