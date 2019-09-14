using BeMyNeighbor.Domain.Models;
using BeMyNeighbor.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BeMyNeighbor.Domain.Models{
  public class CurrentUser{
    private static LocalUser _user;
    private CurrentUser(){}
    public static LocalUser Storage(){
      if(_user == null){
        _user = new LocalUser();
      }
      return _user;
    }

    //once the user successful login we want to save his 
    //information in a singleton for future use throughout 
    //the application. 
    public static void SetStorage(LocalUser signinUser){
      _user = signinUser;
    } 

    public static void DeleteStorage(){
      _user = new LocalUser();
    }

  }

  public class LocalUser{
    public User UserDb { get; set; }
    public Messages Messages { get; set; }
    public Address AddressDb { get; set;}

    //SignIn or SignUp Properties
    [Required(ErrorMessage = "Forget your password!")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Please enter a username or email!")]
    public string UsernameOrEmail { get; set;}
    public LocalUser(){
      UserDb = new User();
      Messages = new Messages();
      AddressDb = new Address();
    }
    public void CleanMessages(){
      this.Messages = new Messages();
    }
  }
}