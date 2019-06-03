using Application.YorumlarService.DTO;
using Core.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.YorumlarService
{
    public interface IYorumlarAppService
    {
        BaseResponse YorumYap(YorumRequest yorumRequest);
    }
}
