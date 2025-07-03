using System.ComponentModel.DataAnnotations.Schema;

namespace StardewApp.Models;

public class UserCrop
{
    public int Id { get; set; }
    
    public int CropId { get; set; }   
    
    [ForeignKey("CropId")] 
    public Crop Crop { get; set; }
    public Fertilizer Fertilizer { get; set; }
    
    public int Quantity { get; set; }
    

}