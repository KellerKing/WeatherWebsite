using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WeatherAPI.DataAccess.Tests
{
  [TestClass()]
  public class DatabaseConnectorTests_DatabseConnectior
  {

    [TestMethod()]
    public void SaveWeatherToDatabaseTest_GetOrteToRefreshAsync1()
    {
      var db = new DatabaseConnector();
      var result = db.GetOrteToRefreshAsync(new MySqlConnector.MySqlConnection()).Result;
      Assert.IsNotNull(result);
    }
  }
}