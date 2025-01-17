﻿using MongoDB.Driver;
using System.Text;

namespace astn_course.Data
{
  public class Mongo
  {
    public static string _database = "ow";
    public static IMongoDatabase DbConnect(string name)
    {
      var mongoClient = new MongoClient();
      return mongoClient.GetDatabase(name);
    }

    private static readonly string Characters = "0123456789abcdefghijklmnopqrstuvwxyz";
    public static string RandomId()
    {
      DateTime date = DateTime.Now;

      var result = new StringBuilder();
      result.Append(DateTime.Now.ToString("yy"));
      result.Append(Characters[date.Month]);
      result.Append(Characters[date.Day]);
      result.Append(Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6));

      return result.ToString().ToUpper();
    }
  }
}
