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
        public string StateAndCity { get; set; }

        public StudentInfoModel(Dictionary<string, string> data)
        {
            StudentName = data["Student Name"];
            StudentEmail = data["Student Email"];
            Gender = data["Gender"];
            Mobile = data["Mobile"];
            string dobString = data["Date of Birth"];
            DateOfBirth = "10 March,2000";
            Subjects = data["Subjects"].Split(',').Select(x => x.Trim()).ToList();
            Hobbies = data["Hobbies"].Split(',').Select(x => x.Trim()).ToList();
            Address = data["Address"];
            StateAndCity = data["State and City"];
        }
    }
}