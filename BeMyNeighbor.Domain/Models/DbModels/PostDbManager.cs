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
      DbManager.GetInstance().GeoLocation.Add(new GeoLocation(){
        Latitude = newPostInfo.lat,
        Longitude = newPostInfo.lon,
      });
      var lastGeolocationRecord = DbManager.GetInstance().GeoLocation.Last();
      var setDateTime = DateTime.Now;

      DbManager.GetInstance().Post.Add(new Post(){
        GeoLocationId = lastGeolocationRecord.GeoLocationId,
        CommunityId =  newPostInfo.CommunityId,
        DatePosted =  setDateTime,
        DateModified = setDateTime,
        UserId = CurrentUser.Storage().UserDb.UserId,
        DoneFlag = false,
        TaskTypeId = newPostInfo.TaskTypeId
      });

      DbManager.GetInstance().SaveChanges();
    }
    //Fetching 
    public static List<Post> FetchPostsByCommunityId(int commId){
      return DbManager.GetInstance().Post.Where(p => p.CommunityId == commId).ToList();
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

  }

}