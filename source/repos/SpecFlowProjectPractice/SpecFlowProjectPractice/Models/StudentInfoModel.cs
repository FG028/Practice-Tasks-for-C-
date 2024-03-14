namespace SpecFlowProjectPractice.Models
{
    public class StudentInfoModel
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string DateOfBirth { get; set; }
        public List<string> Subjects { get; set; }
        public List<string> Hobbies { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string StateAndCity { get; set; }
    }
}