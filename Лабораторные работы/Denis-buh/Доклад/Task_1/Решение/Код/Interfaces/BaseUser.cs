



class BaseUser{
    // Ссылка на объект реализации (вместо класса BaseUser работать будет он)
    protected IPlatform platform; 
    public BaseUser(IPlatform platform){
        // Устанавливаем объект реализации 
        this.platform = platform; 
    }

    /// <summary>Скачиваем видео</summary>
    public string video(string linck){
        // Какой-нибудь код который может быть необходим для работы метода
        // Делегирование работы объекту реализации
        return platform.download_video(linck); 
    }

    /// <summary>Скачиваем видео</summary>
    public string description(string linck){
        // Какой-нибудь код который может быть необходим для работы метода
        // Делегирование работы объекту реализации
        return platform.get_description(linck); 
    }
}