using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using PickPointAPI.Models;

namespace PickPointAPI.Services
{
    public interface IPostamatOperations
    {
        PostamatStore GetPostamat(int postamatId);
        ImmutableList<PostamatStore> GetPostamats();
        bool IsPostamatExists(int postamatId);
        bool IsPostamatActive(int postamatId);
    }
}
