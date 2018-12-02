using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace Swfast.Web.Util
{
    [DebuggerDisplay("{Identity.Name")]
    public class SimpleConfigurationPrincipal : IPrincipal
    {
        HashSet<string> _roles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public SimpleConfigurationPrincipal(IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            this.Identity = identity;

            string roleSetting = $"roles:{identity.Name}";
            var roles = ConfigurationManager.AppSettings[roleSetting];

            if (!string.IsNullOrEmpty(roles))
            {
                foreach (var role in roles?.Split('|'))
                {
                    _roles.Add(role);
                }
            }
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            return _roles.Contains(role);
        }


        public static void SetAuthenticatedPrincipal(IPrincipal principal)
        {
            if (principal == null || principal.Identity == null || !principal.Identity.IsAuthenticated || String.IsNullOrEmpty(principal.Identity.Name))
            {
                return;
            }

            if (!(principal is SimpleConfigurationPrincipal))
            {
                principal = new SimpleConfigurationPrincipal(principal.Identity);
            }

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }

            Thread.CurrentPrincipal = principal;
        }
    }
}