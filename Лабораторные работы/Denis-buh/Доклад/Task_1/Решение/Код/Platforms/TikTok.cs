



class TikTok: IPlatform{
    public string download_video(string linck){
        return "video was downloaded";
    }

    public string get_description(string linck){
        return "description of the video";
    }

    public string get_author(string linck){
        return "author";
    }

    public int get_showers(string linck){
        return $"views to video by link {linck}".Length; 
    }

    public int get_likes(string linck){
        return $"likes to video by link {linck}".Length; 
    }

    public int get_dislikes(string linck){
        return $"dislikes to video by link {linck}".Length; 
    }
}
