using BeMyNeighbor.Data.Entities;

namespace BeMyNeighbor.Domain.Models{
  public class CurrentUser{
    private static User _user;
    private CurrentUser(){}
    public static User Storage(){
      if(_user == null){
        _user = new User();
      }
      return _user;
    }

    //once the user successful login we want to save his 
    //information in a singleton for future use throughout 
    //the application. 
    public static void SetStorage(User signinUser){
      _user = signinUser;
    } 

  }
}