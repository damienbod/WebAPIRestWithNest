using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace WebAPIRestWithNest.Versioning
{
    /// <summary>
    /// Provides an attribute route that's restricted to a specific version of the api.
    /// </summary>
    internal class VersionedRoute : RouteFactoryAttribute
    {
        public VersionedRoute(string template, int allowedVersion)
            : base(template)
        {
            AllowedVersion = allowedVersion;
        }

        public int AllowedVersion
        {
            get;
            private set;
        }

        public override IDictionary<string, object> Constraints
        {
            get
            {
                var constraints = new HttpRouteValueDictionary();
                constraints.Add("version", new VersionConstraint(AllowedVersion));
                return constraints;
            }
        }
    }
}