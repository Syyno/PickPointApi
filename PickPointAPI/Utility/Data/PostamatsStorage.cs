using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using PickPointAPI.Models;

namespace PickPointAPI.Util
{
    public class PostamatsStorage
    {
        public  ImmutableList<PostamatStore> Postamats { get; private set; }

        public PostamatsStorage()
        {
            Postamats = AddDataToPostamats.GetInitialPostamats().ToImmutableList();
        }
    }
}
