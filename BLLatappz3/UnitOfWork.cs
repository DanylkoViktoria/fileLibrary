using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanderaHammer.Services
{
    public class UnitOfWork
    {
        private SourceService _sourceService;
        private StorageService _storageService;
      
        public SourceService SourceService => _sourceService ?? (_sourceService = new SourceService());
        public StorageService StorageService => _storageService ?? (_storageService = new StorageService());

        public UnitOfWork()
        {
            
        }
    }
}
