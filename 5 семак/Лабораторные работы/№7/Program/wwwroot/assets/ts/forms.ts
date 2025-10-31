





class InputForm{
    // Создаем оверлей 
    readonly overlay = $("<div id='modalOverlay'></div>").css({
        display: 'none',
        position: 'fixed',
        top: 0, left: 0,
        width: '100%', height: '100%',
        background: 'rgba(0, 0, 0, 0.8)',
        /* Центрируем картинку при открытии */
        justifyContent: 'center',
        alignItems: 'center',
        zIndex: 999
    });

    readonly form = $('<div id="popupForm"></div>').css({
        background: "#262641",
        position: "fixed",
        top:"50%",
        left:"50%",
        transform: "translate(-50%, -50%)",

        padding: "5%",
        zindex: 9999,
    });

    readonly closeBtn = $('<button>Закрыть</button>');

    public close_form(e: any): void{
        if (e.target === this.overlay[0] || e.target === this.closeBtn[0]) {
            this.overlay.css("display", "none");
            $("body").css("overflow", "");
        }
    }




}
