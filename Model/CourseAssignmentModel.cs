using MongoDB.Bson.Serialization.Attributes;

namespace astn_course.Model
{
    [BsonIgnoreExtraElements]
    public class CourseAssignmentModel
    {
        [BsonId]
        public string id { get; set; }  
        public string name { get; set; }    
        public string major { get; set; }   
        public string course { get; set; }
        public string course_name { get; set; }
        public List<Assignment> assignments {  get; set; }
        public List<string> members {  get; set; }
        public string password {  get; set; }   

        public class Assignment
        {
            public string id { get; set; }
            public string name { get; set; }
            public string date_create { get; set; }
            public long start { get; set; }
            public long end { get; set; }
            public bool done { get;set; }
        }
        
      
    }
}
