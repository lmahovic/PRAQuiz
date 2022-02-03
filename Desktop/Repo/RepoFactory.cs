using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRAQuiz.Repo;


namespace PRAQuiz.Repo
{
   public static class RepoFactory
    {
        public static IRepo GetRepository() => new MemoryRepo();

    }
}
