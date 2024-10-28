



class SuperUser: BaseUser{
    public SuperUser(IPlatform platform): base(platform){}
    /// <summary>Функция для выдачи автора видео</summary>
    public string author(string linck){
        return platform.get_author(linck); 
    }
    /// <summary>Функция для выдачи количества просмотров у видео</summary>
    public int showers(string linck){
        return platform.get_showers(linck); 
    }

    /// <summary>Функция для выдачи количества лайков у видео</summary>
    public int likes(string linck){
        return platform.get_likes(linck); 
    }

    /// <summary>Функция для выдачи количества дизлайков у видео</summary>
    public int dislikes(string linck){
        return platform.get_dislikes(linck); 
    }
}