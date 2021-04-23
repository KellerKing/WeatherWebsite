using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPI.ServiceLibrary.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPITests;

namespace WeatherAPI.ServiceLibrary.Domains.Tests
{
  [TestClass()]
  public class WeatherUpdateBuisnessLogicTest
  {

    [TestMethod()]
    public void DeleteForecastsIfActualExists_Test()
    {
      var mockDBConnector = new DatabaseConnector_Mock();
      var resultEntrysToDelete = WeatherUpdateBuisnessLogic.DeleteForecastsIfActualExists(mockDBConnector);

      Assert.Fail();
    }
  }
}