﻿using Pandatheque.AuthorizedAction.TestWebApp.Models;
using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;
using System;
using System.Collections.Generic;

namespace Pandatheque.AuthorizedAction.TestWebApp.Actions
{
    public class ListerEnquetes : IListerEnquetes
    {
        private readonly IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker;

        public ListerEnquetes(
            IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker)
        {
            this.cloturerEnqueteChecker = cloturerEnqueteChecker;
        }

        public ICollection<Enquete> Execute()
        {
            List<Enquete> enquetes = new List<Enquete>
            {
                new Enquete
                {
                    Id = 1,
                    DateOuverture = new DateTime(2020, 3, 1),
                    DateFermeture = new DateTime(2020, 4, 30)
                },
                new Enquete
                {
                    Id = 2,
                    DateOuverture = new DateTime(2020, 2, 1),
                    DateFermeture = new DateTime(2020, 2, 19)
                },
                new Enquete
                {
                    Id = 3,
                    DateOuverture = new DateTime(2020, 4, 1),
                    DateFermeture = new DateTime(2020, 4, 5)
                },
                new Enquete
                {
                    Id = 4,
                    DateOuverture = new DateTime(2020, 3, 1),
                    DateFermeture = new DateTime(2020, 3, 31)
                },
            };

            // Fills the authorizations.
            foreach (Enquete enquete in enquetes)
            {
                CloturerEnquetePolicyContext context = new CloturerEnquetePolicyContext
                {
                    Utilisateur = Utilisateur.CreateAdmin(),
                    Enquete = enquete
                };

                enquete.CanCloture = this.cloturerEnqueteChecker.CheckPolicies(context).Allowed;
            }

            return enquetes;
        }
    }
}
