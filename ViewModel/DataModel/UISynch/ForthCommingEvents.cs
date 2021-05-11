using DBAdapter.EF;
using System.Linq;
using System;
using DBAdapter;
using AutoMapper;
using ViewModel.VM.ForthCommingEvent;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ViewModel.DataModel.UISynch
{
    public class ForthCommingEvents:coreentity
    {
        public string createJSon()
        {
            string ReturnResult = string.Empty;

            VM_INIT_FORTH_COMMING_EVENTS obj = new VM_INIT_FORTH_COMMING_EVENTS();

             var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<IEI_TBL_FRTH_EVENT>, VM_IEI_TBL_FRTH_EVENT>();
                cfg.CreateMap<IEI_TBL_TECH_PROPOSAL, VM_IEI_TBL_TECH_PROPOSAL>();
                cfg.CreateMap<IEI_TBL_TECH_PROG_HD, VM_IEI_TBL_TECH_PROG_HD>();
                cfg.CreateMap<IEI_TBL_TECH_DIVISION_MAST, VM_IEI_TBL_TECH_DIVISION_MAST>();
                cfg.CreateMap<IEI_TBL_TECH_ASSOCIATE, VM_IEI_TBL_TECH_ASSOCIATE>();
                cfg.CreateMap<IEI_TBL_CENTMAST, VM_IEI_TBL_CENTMAST>();
            });

            IMapper mapper = new Mapper(config);

            var _IEI_TBL_FRTH_EVENT = objtIEIEntities.IEI_TBL_FRTH_EVENT.ToList();

            obj.IEI_TBL_FRTH_EVENT = mapper.Map<List<IEI_TBL_FRTH_EVENT>, List<VM_IEI_TBL_FRTH_EVENT>>(_IEI_TBL_FRTH_EVENT);

            ReturnResult = JsonConvert.SerializeObject(obj);


            return ReturnResult;
        }

    }
}
