using Core.Model.AppSettingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ReklamlarService
{
   public interface IReklamlarAppService
    {
        ReklamTariler ReklamTarilerList();
    }
}
