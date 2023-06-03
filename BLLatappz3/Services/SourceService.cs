using AutoMapper;
using BLL;
using DAL;
using ServiceAbstract;
using System.Collections.Generic;
using System.Linq;

public class SourceService
{
    private readonly IDataAccessService<DAL.Source> _service;
    public SourceService()
    {
        _service = new DataService<DAL.Source>();
    }
    public void AddSource(BLL.Source source, int storageId)
    {
        var sourceConfig = new MapperConfiguration(cfg => cfg.CreateMap<BLL.Source, DAL.Source>());
        var sourceMapper = new Mapper(sourceConfig);

        var sourceEntity = sourceMapper.Map<DAL.Source>(source);
       
        sourceEntity.StorageId = storageId;

        _service.Add(sourceEntity);
    }
    public bool RemoveSource(int Id)
    {
        var entity = _service.GetById(Id);

        if (entity == null)
            return false;

        _service.Delete(entity);

        return true;
    }

    public List<BLL.Source> GetSources(string search)
    {
        var sourceConfig = new MapperConfiguration(cfg => cfg.CreateMap<DAL.Source, BLL.Source>());
        var sourceMapper = new Mapper(sourceConfig);

        var Query = _service.GetAll();

        if (!string.IsNullOrEmpty(search))
        {
            search = search.ToLower();
            Query = Query.Where(x => x.FileName.ToLower().Contains(search) || x.Name.ToLower().Contains(search));
        }

        List<BLL.Source> sources = sourceMapper.Map<List<BLL.Source>>(Query.ToList());
        return sources;
    }
}