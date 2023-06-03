using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using ServiceAbstract;
using System.Collections.Generic;
using System.Linq;

public class StorageService
{
    private readonly IDataAccessService<DAL.Storage> _service;
    public StorageService()
    {
        _service = new DataService<DAL.Storage>();
    }
    public void AddStorage(BLL.Storage storage)
    {
        var storageConfig = new MapperConfiguration(cfg => cfg.CreateMap<BLL.Storage, DAL.Storage>());
        var storageMapper = new Mapper(storageConfig);

        var storageEntity = storageMapper.Map<DAL.Storage>(storage);

        _service.Add(storageEntity);
    }
    public bool RemoveStorage(int Id)
    {
        var entity = _service.GetById(Id);

        if (entity == null)
            return false;

        _service.Delete(entity);

        return true;
    }

    public List<BLL.Storage> GetStorages(string search)
    {
        var storageConfig = new MapperConfiguration(cfg => cfg.CreateMap<DAL.Storage, BLL.Storage>());
        var storageMapper = new Mapper(storageConfig);

        var Query = _service.GetAll();

        if (!string.IsNullOrEmpty(search))
        {
            search = search.ToLower();
            Query = Query.Where(x => x.Name.ToLower().Contains(search) || x.Path.ToLower().Contains(search));
        }

        List<BLL.Storage> storages = storageMapper.Map<List<BLL.Storage>>(Query.ToList());
        return storages;
    }
}