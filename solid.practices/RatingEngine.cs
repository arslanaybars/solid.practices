namespace solid.practices
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        //public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        //public FilePolicySource PolicySource { get; set; } = new FilePolicySource();

        //public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();

        public IRatingContext Context { get; set; } = new DefaultRatingContext();

        public decimal Rating { get; set; }

        public RatingEngine()
        {
            Context.Engine = this;
        }

        public void Rate()
        {
            Context.Log("Starting rate.");

            Context.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = Context.LoadPolicyFromFile();

            var policy = Context.GetPolicyFromJsonString(policyJson);

            var rater = Context.CreateRaterForPolicy(policy, Context);

            rater.Rate(policy);

            Context.Log("Rating completed.");
        }
    }
}
