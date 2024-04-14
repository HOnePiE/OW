using MongoDB.Bson.Serialization.Attributes;

namespace astn_course.Model
{
    [BsonIgnoreExtraElements]
    public class AssignmentItemModel
    {
        [BsonId]
        public string id {  get; set; } 
        public string user_create { get; set; }
        public string submit_status { get; set; }   
        public int grade { get;set; }
        public long date_create { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public long date_submmit { get; set; }   
        public long last_edit { get; set; }
        public List<string> listFiles { get; set; }
        public string teacher {  get; set; }  
        public List<string> comments { get; set; }
        public List<string> feedbacks { get; set; } 

    }
}
