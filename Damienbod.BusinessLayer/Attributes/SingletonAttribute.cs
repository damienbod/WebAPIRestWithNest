namespace Damienbod.BusinessLayer.Attributes
{
    namespace MVC5UnitySlab.Business.Attributes
    {
        [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
        public class SingletonAttribute : System.Attribute
        {
            public double version;

            public SingletonAttribute()
            {
                version = 1.0;
            }
        }
    }
 }
