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
         public PathsTakenData.PathsTakenData _pathData;

         public PathsTakenRepo(IRepository pathRepository, PathsTakenData.PathsTakenData pathData)
        {
            _repo = pathRepository;
             _pathData = pathData;
        }

        public void AddPath(List<string> paths)
        {
            foreach (var path in paths)
            {
                _pathData.Paths.Add(path);
            }
            _pathData.Id = _repo.All<PathsTakenData.PathsTakenData>().Count();
            _repo.Add<PathsTakenData.PathsTakenData>(_pathData);
        }
    }
}
