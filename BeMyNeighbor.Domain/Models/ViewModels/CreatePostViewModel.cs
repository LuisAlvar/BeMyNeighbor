
namespace BeMyNeighbor.Domain.Models.ViewModels{
  public class CreatePostViewModel{
    public int CommunityId { get; set; }
    public string UserComment { get; set; }
    public decimal lat { get; set; }
    public decimal lon { get; set; }
    public int TaskTypeId { get; set; }
    public int userId { get; set; }
  }
}

