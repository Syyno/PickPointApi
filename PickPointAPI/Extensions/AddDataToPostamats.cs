using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickPointAPI.Models;

namespace PickPointAPI.Util
{
    public static class AddDataToPostamats
    {
        public static List<PostamatStore> GetInitialPostamats()
        {
            return new List<PostamatStore>()
            {
                new PostamatStore("1") {Address = "174 Sherwood Street, OH 43119", Status = true},
                new PostamatStore("2") {Address = "7985 School Street Longview, TX 75604", Status = true},
                new PostamatStore("3") {Address = "871 Peninsula Drive Pearl, MS 39208", Status = false},
            };
        }
    }
}
