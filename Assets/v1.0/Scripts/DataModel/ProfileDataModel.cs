
using System;
using System.Collections.Generic;

public class ProfileDataModel
{
    public string UserName;
    public string ImageURL;
    public string Bio;

    public int PostCounts => Posts.Count;
    public int FollowerCount { get; set; }
    public int FollowingCount { get; set; }
    public List<Post> Posts;

    public ProfileDataModel()
    {
        Posts = new List<Post>();
    }
}

public class Post
{
    public string ThumbnailURL;
    public PostInfo PostInfo;
}

public class PostInfo
{
    public User User;
    public List<string> ImageURL;
    public string Description;
    public List<string> LikedUserID;
    public List<CommentInfo> CommentInfos;

    public PostInfo()
    {
        User = new User();
        CommentInfos = new List<CommentInfo>();
    }
}

public class CommentInfo
{
    public string Comment;
    public List<string> LikedUserID;
    public DateTime TimeStamp;
    public User User;
}

public class User
{
    public string UserID;
    public string UserName;
    public string ProfileImageURL;
}
