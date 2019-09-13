using BeMyNeighbor.Domain.Models;
using BeMyNeighbor.Data.Entities;

namespace BeMyNeighbor.Domain.Models{
  public class CurrentUser{
    private static LocalUser _user;
    private CurrentUser(){}
    public static LocalUser Storage(){
      if(_user == null){
        _user = new LocalUser();
        _user.UserDb = new Data.Entities.User();
        _user.Messages = new Messages();
      }
      return _user;
    }

    //once the user successful login we want to save his 
    //information in a singleton for future use throughout 
    //the application. 
    public static void SetStorage(LocalUser signinUser){
      _user = signinUser;
    } 

    public Messages Messages { get; set; }
  }

  public class LocalUser{
    public User UserDb { get; set; }
    public Messages Messages { get; set; }

    //SignIn or SignUp Properties
    public string Password { get; set; }
    public string UsernameOrEmail { get; set;}
  }
}