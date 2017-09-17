namespace WebApi.Controllers
{
    using BusinessServices;
    using BusinessEntities;
    using System.Web.Http;

    public class LeadController : ApiController
    {
        private readonly ILeadServices _leadServices;

        public LeadController()
        {
            _leadServices = new LeadServices();
        }

        public int Post([FromBody]LeadEntity lead)
        {
            return _leadServices.Add(lead);
        }
    }
}
