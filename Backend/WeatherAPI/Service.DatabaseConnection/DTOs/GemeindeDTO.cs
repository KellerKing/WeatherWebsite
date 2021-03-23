using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Database.Contracts
{
  public class GemeindeDTO
  {
    public string Gemeinde { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string Plz { get; set; }
    public string KLand { get; set; }
  }
}
