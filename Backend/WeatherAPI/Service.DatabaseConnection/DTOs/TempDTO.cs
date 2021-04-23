using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Database
{
  public class TempDTO
  {
    public DateTime Time { get; set; }
    public int? Id { get; set; }
    public float? TempMax { get; set; }
    public float? TempMin { get; set; }
    public float? TempCurrent { get; set; }
    public string Description { get; set; }
    public string  Gemeinde { get; set; }
    public string Type { get; set; }
  }
}
