



/// Грузим css для работы формы
import "../test_form.css"


import * as InputForm from "./InputForm";



export class TableInputForm extends InputForm.BaseInputForm{

}



(window as any).TableInputForm = TableInputForm;
