using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PickPointAPI.Models;
using PickPointAPI.Models.DTO.Postamat_DTO_s;

namespace PickPointAPI.Util
{
    public class PostamatProfile : Profile
    {
        public PostamatProfile()
        {
            CreateMap<PostamatReturn, PostamatStore>();
            CreateMap<PostamatStore, PostamatReturn>();
        }
    }
}
