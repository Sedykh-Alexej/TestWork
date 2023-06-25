using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int Wages { get; set; }
        public string Departament { get; set; }
        public bool InState { get; set; }

    }
}
