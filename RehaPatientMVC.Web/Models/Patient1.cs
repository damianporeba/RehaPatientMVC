using System.ComponentModel;

namespace RehaPatientMVC.Web.Models;

    public class Patient1
    {
     [DisplayName("ID pacjenta")]
        public int Id { get; set; }

    public Patient1(int id)
        {
            Id = id;
        }

    public Patient1()
    {
    }
}

