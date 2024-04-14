using MongoDB.Bson.Serialization.Attributes;

namespace astn_course.Model
{
  [BsonIgnoreExtraElements]
  public class LearnedModel
  {
    [BsonId]
    public string id { get; set; }
    public string course { get; set; }
    public string course_name { get; set; }
    public string user { get; set; }
    public bool finish { get; set; }
    public string instructor { get; set; }
    public long date_start { get; set; }
    public long date_finish { get; set; }
    public List<Lesson> lessons { get; set; } = new();

    public class Lesson
    {
      public string id { get; set; }
      public long date { get; set; }
      public bool done { get; set; }
      public bool pass { get; set; }
      public int type { get; set; }
    }
  }
}
