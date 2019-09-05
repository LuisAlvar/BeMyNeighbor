using System;

namespace BeMyNeighbor.Data.Entities{
  public class Post{
    public int PostId { get; set; }
    public string GeoLocation { get; set; }
    public int CommunityId { get; set; }
    public DateTime DatePosted { get; set;}
    // public Task TaskType { get; set;} -> waiting for someone to create taks 
  }
}