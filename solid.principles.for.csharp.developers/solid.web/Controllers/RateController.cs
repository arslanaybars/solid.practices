using Microsoft.AspNetCore.Mvc;
using solid.practices;
using solid.practices.Infrastructure.PolicySources;

namespace solid.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly RatingEngine _ratingEngine;
        private readonly StringPolicySource _policySource;

        public RateController(RatingEngine ratingEngine,
            StringPolicySource policySource)
        {
            _ratingEngine = ratingEngine;
            _policySource = policySource;
        }

        [HttpPost()]
        public ActionResult<decimal> Rate([FromBody] string policy)
        {
            _policySource.PolicyString = policy;
            _ratingEngine.Rate();

            return _ratingEngine.Rating;
        }
    }
}