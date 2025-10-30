



document.querySelectorAll("#editableTable td").forEach(td => {
  td.addEventListener("dblclick", () => {
    td.contentEditable = true;     // включаем редактирование
    td.focus();                    // ставим курсор внутрь
  });

  td.addEventListener("blur", () => {
    td.contentEditable = false;    // выключаем редактирование при потере фокуса
  });

  td.addEventListener("keydown", (e) => {
    if (e.key === "Enter") {       // по Enter завершаем редактирование
      e.preventDefault();
      td.blur();
    }
  });
});