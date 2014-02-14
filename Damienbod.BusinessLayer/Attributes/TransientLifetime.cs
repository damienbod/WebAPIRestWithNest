namespace Damienbod.BusinessLayer.Attributes
{
    namespace MVC5UnitySlab.Business.Attributes
    {
        [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
        public class TransientLifetime : System.Attribute
        {
            public double version;

            public TransientLifetime()
            {
                version = 1.0;
            }
        }
    }
 }


