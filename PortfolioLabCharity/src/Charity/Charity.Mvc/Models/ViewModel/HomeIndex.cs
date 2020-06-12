using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Mvc.Models.DbModels;
using Charity.Mvc.Models.ItemSelect;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace Charity.Mvc.Models.ViewModel
{
    public class HomeIndex
    {
        public int TransferredBags { get; set; }
        public int SupportedOrganization { get; set; }

        public List<InstitutionSelectList> ListOfInstitutions { get; set; }
    }
}