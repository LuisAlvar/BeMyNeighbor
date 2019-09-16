namespace BeMyNeighbor.Domain.Models{
  public class Messages{
    public string FetchDbError { get; set; }
    public string MessageToUser { get; set; }
    public string MessageType { get; set; }
    public string SourceType { get; set; }
    public string DestinationType { get; set;}
    public int DurationOfUser {get; set;}
    public void ReduceDuration(){
      if(this.DurationOfUser > 0){
        this.DurationOfUser -= 1;
      }else{
        this.MessageType = "";
        this.DurationOfUser = 0;
      }
    }
  }
}