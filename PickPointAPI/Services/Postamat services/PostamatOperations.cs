using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PickPointAPI.Models;
using PickPointAPI.Util;

namespace PickPointAPI.Services
{
    public class PostamatOperations : IPostamatOperations
    {
        private readonly ImmutableList<PostamatStore> _postamats;

        public PostamatOperations(PostamatsStorage postamats)
        {
            _postamats = postamats.Postamats;
        }
        public PostamatStore GetPostamat(int postamatId)
        {
            return _postamats.FirstOrDefault(p => p.Number == postamatId.ToString());
        }

        public ImmutableList<PostamatStore> GetPostamats()
        {
            return _postamats;
        }

        public bool IsPostamatExists(int postamatId)
        {
            return _postamats.Any(p => p.Number == postamatId.ToString());
        }

        public bool IsPostamatActive(int postamatId)
        {
            PostamatStore postamat = _postamats.FirstOrDefault(p => p.Number == postamatId.ToString());
            if (postamat != null)
                return postamat.Status;
            return false;
        }
    }
}
