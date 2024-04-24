
using API.Dto.Entry;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class CargoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CargoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Cargo>>> GetAll()
    {
        IEnumerable<Cargo> result = await _unitOfWork.Cargos.GetAllAsync();
        return Ok(result);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Cargo>> SaveOne(CargoEntryDto entryDto)
    {
        Cargo usuario = _mapper.Map<Cargo>(entryDto);
        _unitOfWork.Cargos.Add(usuario);
        await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CargoEntryDto>> DeleteOne(int id)
    {
        Cargo entidad = await _unitOfWork.Cargos.GetAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        _unitOfWork.Cargos.Delete(entidad);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CargoEntryDto>> UpdateOne([FromBody] CargoEntryDto entryDto, [FromRoute] int id)
    {
        Cargo entidad = await _unitOfWork.Cargos.GetAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        entidad.Descripcion = entryDto.Descripcion;
        entidad.Nombre = entryDto.Nombre;
        await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
}