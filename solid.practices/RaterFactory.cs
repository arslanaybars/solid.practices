using System;

namespace solid.practices
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            try
            {
                //switch (policy.Type)
                //{
                //    case PolicyType.Auto:
                //        return new AutoPolicyRater(engine, engine.Logger);
                //    case PolicyType.Land:
                //        return new LandPolicyRater(engine, engine.Logger);
                //    case PolicyType.Flood:
                //        return new FloodPolicyRater(engine, engine.Logger);
                //    case PolicyType.Life:
                //        return new LifePolicyRater(engine, engine.Logger);
                //    default:
                //        return null;
                //}

                return (Rater)Activator.CreateInstance(Type.GetType($"solid.practices.{policy.Type}PolicyRater"), new object[] { engine, engine.Logger });
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
