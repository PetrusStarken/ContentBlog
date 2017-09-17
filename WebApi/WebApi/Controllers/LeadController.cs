namespace WebApi.Controllers
{
    using BusinessServices;
    using BusinessEntities;
    using System.Web.Http;
    using System.Web;

    public class LeadController : ApiController
    {
        private readonly ILeadServices _leadServices;

        public LeadController()
        {
            _leadServices = new LeadServices();
        }

        public int Post([FromBody]LeadEntity leadEntity)
        {
            var userIpAddress = HttpContext.Current.Request.UserHostAddress;
            leadEntity.EnderecoIpv4 = userIpAddress;
            return _leadServices.Add(leadEntity);
        }
    }
}
