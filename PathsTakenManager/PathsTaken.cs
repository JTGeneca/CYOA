using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathsTakenData;
using PathsTakenData = PathsTakenData.PathsTakenData;

namespace PathsTakenManager
{
    public class PathsTaken
    {
        private PathsTakenRepo.PathsTakenRepo _repo;
        public global::PathsTakenData.PathsTakenData _pathData;

        public PathsTaken(PathsTakenRepo.PathsTakenRepo pathsRepository, global::PathsTakenData.PathsTakenData pathData)
        {
            _repo = pathsRepository;
            _pathData = pathData;
        }

        public void AddPath(List<string> paths, int Id)
        {
            foreach (var path in paths)
            {
                _pathData.Paths.Add(path);
            }
            _pathData.Id = Id;
            _repo.AddPath(_pathData);
        }

    }
}
