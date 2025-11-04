







import * as InputForm from "./InputForm/index.js";



/// Грузим css для работы формы
$("head").append(
    $(`<link rel="stylesheet" href="./test_form.css">`)
);



export class TableInputForm extends InputForm.BaseInputForm{

}



(window as any).TableInputForm = TableInputForm;

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