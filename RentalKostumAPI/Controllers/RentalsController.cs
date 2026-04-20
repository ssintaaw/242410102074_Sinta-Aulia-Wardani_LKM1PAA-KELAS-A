using Microsoft.AspNetCore.Mvc;
using RentalKostumAPI.Model;
using RentalKostumAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class RentalsController : ControllerBase
{
    private readonly RentalService _service;

    public RentalsController(RentalService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _service.GetAll();
        return Ok(new { status = "success", data });
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var data = _service.GetById(id);

        if (data == null)
            return NotFound(new { status = "error", message = "Data tidak ditemukan" });

        return Ok(new { status = "success", data });
    }

    [HttpPost]
    public IActionResult Create(Rental rental)
    {
        _service.Create(rental);
        return Ok(new { status = "success", message = "Data berhasil ditambah" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Rental rental)
    {
        _service.Update(id, rental);
        return Ok(new { status = "success", message = "Data berhasil diupdate" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok(new { status = "success", message = "Data berhasil dihapus" });
    }
}