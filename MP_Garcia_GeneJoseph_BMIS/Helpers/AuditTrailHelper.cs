﻿using MP_Garcia_GeneJoseph_BMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Garcia_GeneJoseph_BMIS.Helpers
{
    class AuditTrailHelper
    {

        public static void RecordAction(string message)
        {
            Entities dbEnt = new Entities();

            AuditTrail trail = new AuditTrail();
            var trails = dbEnt.AuditTrail.AuditTrails();
            trail.TrailId = trails.Count > 0 ? trails.Max(m=>m.TrailId) + 1 : 1;
            trail.AccountId = UserSession.User.AccountId;
            trail.Message = message;
            trail.ActionDate = DateTime.Now;

            dbEnt.AuditTrail.InsertAuditTrail(trail);
        }
    }
}
