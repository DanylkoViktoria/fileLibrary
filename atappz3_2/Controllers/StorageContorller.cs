using BanderaHammer.Services;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    public StorageController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Route("Add")]
    [HttpPost]
    public IActionResult Add(string name, string path)
    {
        _unitOfWork.StorageService.AddStorage(new BLL.Storage { Name = name, Path = path });

        return Ok();
    }

    [Route("Delete")]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var result = _unitOfWork.StorageService.RemoveStorage(id);

        if (result)
            return Ok();
        else
            return BadRequest();
    }

    [Route("Get")]
    [HttpGet]
    public IActionResult Get(string search)
    {
        var result = _unitOfWork.StorageService.GetStorages(search);

        return Ok(result);
    }

}
