﻿using Pandatheque.AuthorizedAction.TestWebApp.Models;
using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public class IsModification : APolicy<IUtilisateurPolicyContext>, IIsModification
    {
        public override Task<bool> CheckAsync(IUtilisateurPolicyContext context)
        {
            return Task.FromResult(context.Utilisateur.Profile == Profile.Modification);
        }
    }
}
