using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathsTakenData;
using PathsTakenRepo.Interfaces;

namespace PathsTakenManager
{
    public class PathsTaken
    {
        private readonly IRepository _repo;
        public global::PathsTakenData.PathsTakenData _pathData;

        public PathsTaken(IRepository pathsRepository, PathsTakenData.PathsTakenData pathData)
        {
            _repo = pathsRepository;
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
