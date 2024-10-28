



interface IPlatform{
    /// <summary>Функция для скачивания видео</summary>
    /// <param name="linck">Ссылка на видео</param>
    public string download_video(string linck); 

    /// <summary>Функция для выдачи описания к видео</summary>
    /// <param name="linck">Ссылка на видео</param>
    public string get_description(string linck);

    /// <summary>Функция для выдачи автора видео</summary>
    /// <param name="linck">Ссылка на видео</param>
    public string get_author(string linck);

    /// <summary>Функция для выдачи количества просмотров у видео</summary>
    /// <param name="linck">Ссылка на видео</param>
    public int get_showers(string linck);

    /// <summary>Функция для выдачи количества лайков у видео</summary>
    /// <param name="linck">Ссылка на видео</param>
    public int get_likes(string linck);

    /// <summary>Функция для выдачи количества дизлайков у видео</summary>
    /// <param name="linck">Ссылка на видео</param>
    public int get_dislikes(string linck);
}
