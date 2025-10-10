using System;
using library_management_system_api.DTOs.Siswa;
using library_management_system_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace library_management_system_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SiswaController : ControllerBase
{
    private readonly ISiswaService _siswaService;
    public SiswaController(ISiswaService siswaService)
    {
        _siswaService = siswaService;
    }

    [HttpPost]
    public async Task<ActionResult<SiswaDto>> PostSiswa([FromBody] CreateSiswaDto createSiswaDto)
    {
        var newSiswa = await _siswaService.CreateSiswaAsync(createSiswaDto);
        var result = CreatedAtAction(nameof(GetSiswa), new { id = newSiswa.Id }, newSiswa);
        return result;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SiswaDto>>> GetAllSiswas()
    {
        var siswas = await _siswaService.GetAllSiswasAsync();
        return Ok(siswas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SiswaDto>> GetSiswa(Guid id)
    {
        var siswa = await _siswaService.GetByIdSiswaAsync(id);
        if (siswa is null) return NotFound("Siswa is not found!");

        return Ok(siswa);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<SiswaDto>> PatchSiswa(Guid id, [FromBody] PatchSiswaDto patchSiswaDto)
    {
        var wasUpdated = await _siswaService.PatchSiswaAsync(id, patchSiswaDto);
        if (wasUpdated is null) return NotFound("Siswa is not found!");

        return Ok(wasUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<SiswaDto>> DeleteSiswa(Guid id)
    {
        var wasDeleted = await _siswaService.DeleteSiswaAsync(id);
        if (!wasDeleted) return NotFound("Siswa is not found!");

        return NoContent();
    }
}
