using AutoMapper;
using Core.Model.AppSettingModel;
using Core.Repositories.ReklamlarR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ReklamlarService
{
   public class ReklamlarAppService : IReklamlarAppService
    {

        private readonly IReklamlarRepository _reklamlarRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<ReklamTariler> _options;
        public ReklamlarAppService(IOptions<ReklamTariler> options,IReklamlarRepository reklamlarRepository, IMapper mapper)
        {
            _reklamlarRepository = reklamlarRepository;
            _mapper = mapper;
            _options = options;
        }

        public ReklamTariler ReklamTarilerList()
        {
            ReklamTariler reklamTariler = new ReklamTariler();
           var aa= _options.Value;

              return reklamTariler;
        }
    }
}
