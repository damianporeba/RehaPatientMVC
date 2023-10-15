using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;

namespace RehaPatientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
    }
}
