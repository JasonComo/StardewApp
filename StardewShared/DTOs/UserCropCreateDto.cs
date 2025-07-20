using StardewShared.Enums;
namespace StardewShared.DTOs;
public class UserCropCreateDto
{
    public string CropName { get; set; }          
    public Fertilizer Fertilizer { get; set; }    
    public int Quantity { get; set; }   
}
