using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreMVCByLaxmiBhattarai.Models
{
    public class Student
    {
            [Key]
            public int Sid { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Department { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }

       
    }
}

