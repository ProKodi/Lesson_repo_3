



import {/*OverLay, ButtonState, HeaderForm, TableInput*/} from "../Main_index.js"

import {OverLay} from "../OverLay.js";
import {ButtonState} from "../BaseEnum.js";


import {HeaderForm} from "./index.js";
import {TableInput} from "../TableInput/index.js";








export abstract class BaseInputForm{
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
        <button type="button" id="bt_save">
            <img src="https://api.iconify.design/lucide:save.svg?color=%23FFFFFF&amp;width=16&amp;height=16" alt="Save icon" id="i3ixg-2" >
            <span>Save</span>
        </button>
    `);

    /// Флаг кнопок
    public state_button: ButtonState = ButtonState.Close;


    public SaveForm(){
        console.log(12345);
        this.state_button = ButtonState.Save;
        OverLay.close();
    }

    public CloseForm(){
        console.log(12345);
        this.state_button = ButtonState.Close;
        OverLay.close();
    }





    public constructor(){
        /// Работа с Хеадером формы
        this.data_form_header = new HeaderForm(this.data_form);


        /// Работа с таблицей формы
        this.table_form = new TableInput(this.data_form);


        /// Работа с строкой кнопок
        this.bt_save.on("click", this.SaveForm);
        this.row_bt.append(this.bt_save);

        this.bt_close.on("click", this.CloseForm);
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

(window as any).BaseInputForm = BaseInputForm;