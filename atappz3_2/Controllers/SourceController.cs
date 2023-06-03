using BanderaHammer.Services;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class SourceController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    public SourceController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Route("Add")]
    [HttpPost]
    public IActionResult Add(string filename, string name, int storage, int type)
    {
        _unitOfWork.SourceService.AddSource(new BLL.Source { FileName = filename, Name = name, Type = (SourceType)type, StorageId = storage }, storage);

        return Ok();
    }

    [Route("Delete")]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var result = _unitOfWork.SourceService.RemoveSource(id);

        if (result)
            return Ok();
        else
            return BadRequest();
    }

    [Route("Get")]
    [HttpGet]
    public IActionResult Get(string search)
    {
        var result = _unitOfWork.SourceService.GetSources(search);

        return Ok(result);
    }

}
