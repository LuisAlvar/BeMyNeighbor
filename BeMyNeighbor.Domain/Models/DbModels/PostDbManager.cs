using BeMyNeighbor.Data.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using BeMyNeighbor.Domain.Models.DbModels;
using BeMyNeighbor.Domain.Models;
using BeMyNeighbor.Domain.Models.ViewModels;

namespace BeMyNeighbor.Domain.Models.DbModels{
  public class PostDbManager{
    private PostDbManager(){}
    //Creation
    public static void CreatePost(CreatePostViewModel newPostInfo){
      try
      {
        var location =  new GeoLocation();
        location.Latitude = 2.43M;
        location.Longitude = 3.44M;

        var setDateTime = DateTime.Now;
        var newPost = new Post();
        newPost.User = CurrentUser.Storage().UserDb;
        newPost.GeoLocation = location;
        newPost.Community = DbManager.GetInstance().Community.Single( c => c.CommunityId ==  CurrentUser.Storage().UserDb.CommunityId);
        newPost.TaskType = DbManager.GetInstance().Task.Single(t => t.TaskTypeId ==  newPostInfo.TaskTypeId);
        newPost.DatePosted = setDateTime;
        newPost.DateModified = setDateTime;
        newPost.CommentTxt = newPostInfo.UserComment;
        newPost.DoneFlag = false;

        DbManager.GetInstance().Post.Add(newPost);

        DbManager.GetInstance().SaveChanges();          
      }
      catch (System.Exception)
      {
          
          throw;
      }
    }
    //Fetching 
    public static List<Post> FetchPostsByCommunityId(int commId){
      return DbManager.GetInstance().Post.Where(p => p.CommunityId == commId).ToList();
    }
    public static List<Tuple<User,Post>> FetchPostsByUsersCommunityId(){
      List<Tuple<User, Post>> a =  new List<Tuple<User, Post>>();
      var postList = DbManager.GetInstance().Post.Where(p => p.CommunityId == CurrentUser.Storage().UserDb.CommunityId).ToList();
      if(postList.Count == 0) return a;
      foreach (var post in postList)
      {
          var currentUser =  DbManager.GetInstance().User.Single(u => u.UserId == post.UserId); 
          a.Add(Tuple.Create(currentUser, post));
      }
      return a;
    }
    public static List<Post> FetchPostsByGeoLocationId(int geoId){
      return DbManager.GetInstance().Post.Where(p => p.GeoLocationId == geoId).ToList();
    }
    public static List<Post> FetchPostsByTaskTypeId(int tasktypeId){
      return DbManager.GetInstance().Post.Where(p => p.TaskTypeId == tasktypeId).ToList();
    }
    public static List<Task> FetchTaskForUser(){
      return DbManager.GetInstance().Task.ToList();
    }


    //Updating
    public static void EditPost(int id, string newDescription){
      var editingPost = FindPost(id);
      var editedTask = FindTask(editingPost.TaskTypeId);

      editedTask.TaskDescription = newDescription;
      DbManager.GetInstance().Task.Update(editedTask);
      DbManager.GetInstance().SaveChanges();
    }

    public static void SelectedPost(int id){
      //the current user can not select his own post 
      var editPost = DbManager.GetInstance().Post.Single(p => p.PostId == id && p.UserId != CurrentUser.Storage().UserDb.UserId);
      editPost.UserSelectedId = CurrentUser.Storage().UserDb.UserId;
      editPost.DateSelected = DateTime.Now;
      DbManager.GetInstance().Post.Update(editPost);
      DbManager.GetInstance().SaveChanges();
    }

    public static bool SelectedOtherUsersPost(int selectedPostId){
      var dateTime =  DateTime.Now;
      CurrentUser.Storage().Messages.SourceType  = "/Main/SelectedOtherOtherUsersPost";

      try
      {
        var fetchPost = FindPost(selectedPostId);
        fetchPost.UserSelected =  CurrentUser.Storage().UserDb;
        fetchPost.DateSelected =  dateTime;
        fetchPost.DoneFlag = false;
        DbManager.GetInstance().Post.Update(fetchPost);
        DbManager.GetInstance().SaveChanges();
      }
      catch (System.Exception)
      {
        CurrentUser.Storage().Messages.MessageType = "UnableToAcceptPost";
        CurrentUser.Storage().Messages.MessageToUser = "We are having service issues! We are currently working on it.";
        CurrentUser.Storage().Messages.DestinationType = "/Main/Index";
        CurrentUser.Storage().Messages.DurationOfUser = 1;
        return false;
      }
      return true;
    }

    //Deleting
    public static void DeletePost(int id){
      DbManager.GetInstance().Post.Remove(FindPost(id));
      DbManager.GetInstance().SaveChanges();
    }

    //Addtional functions 
    public static Task FindTask(int id){
      return DbManager.GetInstance().Task.Single(t => t.TaskTypeId == id);
    }
    public static Post FindPost(int id){
      return DbManager.GetInstance().Post.Single(p => p.PostId == id);
    }

    public static List<Post> FetchPostsLinkedWithUserID(int userID){
      List<Post> pList = new List<Post>();
      try{
         pList = DbManager.GetInstance()
         .Post.Where(p=> p.UserId == userID || p.UserSelected.UserId == userID 
         || (int) p.UserSelectedId == userID).ToList(); 
      }
      catch (System.Exception ex){
        System.Console.WriteLine(ex.ToString());
      }
      return pList;
    }
        public static void UpdatePostDoneFlag (int postID){
      
      try{
          var res = DbManager.GetInstance().Post.Single(c => c.PostId == postID);
          res.DoneFlag = true;
          DbManager.GetInstance().Attach(res);
          DbManager.GetInstance().SaveChanges();
      }catch (System.Exception ex){
          System.Console.WriteLine(ex.ToString());;
      }
    } 


  }


}