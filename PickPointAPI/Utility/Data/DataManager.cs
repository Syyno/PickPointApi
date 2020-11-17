using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickPointAPI.Services;

namespace PickPointAPI.Util
{
    public class DataManager
    {
        public IOrderOperations Orders { get; }
        public IPostamatOperations Postamats { get; }

        public DataManager(IOrderOperations orderOperations, IPostamatOperations postamatOperations)
        {
            Orders = orderOperations;
            Postamats = postamatOperations;
        }
    }
}
