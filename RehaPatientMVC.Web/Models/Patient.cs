using System.ComponentModel;

namespace RehaPatientMVC.Web.Models
{
    public class Patient
    {
        [DisplayName("Identyfikator")]
        public int Id { get; set; }
        [DisplayName("Imię")]
        public string  Name { get; set; }
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }

    }
}
