using StardewShared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardewShared.DTOs
{
    public class CropResDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GrowthTime { get; set; }
        public Season Season { get; set; }
        public int BasePrice { get; set; }
        public int SilverPrice { get; set; }
        public int GoldPrice { get; set; }
        public int IridiumPrice { get; set; }
    }
}
