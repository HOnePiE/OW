using MongoDB.Bson.Serialization.Attributes;

namespace astn_course.Model
{
    [BsonIgnoreExtraElements]
    public class DepartmentModel
    {
        [BsonId]
        public string id { get;set; }
        public string name { get;set; }
        public bool delete { get;set; }
        public List<string> members { get; set; }
        public string major { get; set; }

        public class Member
        {
            public string id{ get; set; }
            public int role{ get; set; }

        }
    }

    
}
