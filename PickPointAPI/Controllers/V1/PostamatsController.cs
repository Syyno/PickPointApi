using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PickPointAPI.Models;
using PickPointAPI.Models.DTO.Postamat_DTO_s;
using PickPointAPI.Services;
using PickPointAPI.Util;

namespace PickPointAPI.Controllers
{
    [ApiController]
    public class PostamatsController : ControllerBase
    {
        private readonly IPostamatOperations _repository;
        private readonly IMapper _mapper;

        public PostamatsController(IPostamatOperations repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet(ApiRoutes.Postamats.Get, Name = "GetPostamat")]
        public IActionResult GetPostamat(string postamatId)
        {
            int id;
            if (!Int32.TryParse(postamatId, out id))
            {
                return BadRequest();
            }
            if (_repository.IsPostamatExists(id))
            {
                PostamatStore postamatFromStorage = _repository.GetPostamat(id);
                var postamatToReturn = _mapper.Map<PostamatReturn>(postamatFromStorage);
                return Ok(postamatToReturn);
            }
            return NotFound();
        }

        [HttpGet(ApiRoutes.Postamats.GetAll, Name = "GetPostamats")]
        public IActionResult GetPostamats()
        {
            List<PostamatReturn> postamatsToReturn = new List<PostamatReturn>();
            foreach (var postamatToStore in _repository.GetPostamats())
            {
                postamatsToReturn.Add(_mapper.Map<PostamatReturn>(postamatToStore));
            }
            return Ok(postamatsToReturn);
        }

    }
}
