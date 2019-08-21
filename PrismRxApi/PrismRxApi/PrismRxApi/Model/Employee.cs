using System.Runtime.Serialization;

namespace PrismRxApi.Model
{
    [DataContract]
    public class Employee
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "employee_name")]
        public string Name { get; set; }
        [DataMember(Name= "employee_salary")]
        public string Salary { get; set; }
        [DataMember(Name= "employee_age")]
        public string Age { get; set; }
        [DataMember(Name= "profile_image")]
        public string ProfileImage { get; set; }
    }
}
