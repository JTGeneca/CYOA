using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathsTakenRepo.Interfaces;

namespace PathsTakenRepo
{
    public class PathsTakenRepo
    {
         private readonly IRepository _repo;

        public PathsTakenRepo(IRepository pathRepository)
        {
            _repo = pathRepository;
        }

        public void AddPath(PathsTakenData.PathsTakenData pathData)
        {
            _repo.Add<PathsTakenData.PathsTakenData>(pathData);
        }
    }
}
