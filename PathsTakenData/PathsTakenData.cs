using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace PathsTakenData
{
    public class PathsTakenData
    {
        public List<string> Paths;
        public int Id;

        public PathsTakenData()
        {
            Paths = new List<string>();
        }
    }
}
