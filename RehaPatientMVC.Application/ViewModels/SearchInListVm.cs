using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels
{
    public class SearchInListVm
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public string searchString { get; set; }
    }
}
