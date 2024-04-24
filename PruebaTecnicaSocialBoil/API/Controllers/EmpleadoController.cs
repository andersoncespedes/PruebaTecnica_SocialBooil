
using API.Dto.Entry;
using API.Dto.Output;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class EmpleadoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetAll()
    {
        
        IEnumerable<Empleado> result = await _unitOfWork.Empleados.GetAllAsync();
        return _mapper.Map<List<EmpleadoDto>>(result);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<EmpleadoEntryDto>> SaveOne(EmpleadoEntryDto entryDto)
    {
        
        Cargo cargo = _unitOfWork.Cargos.Find(e => e.Nombre == entryDto.CargoNombre).FirstOrDefault();
        if(cargo == null){
            return NotFound();
        }
        Empleado entidad = _mapper.Map<Empleado>(entryDto);
        entidad.Cargo = cargo;
        _unitOfWork.Empleados.Add(entidad);
        await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoEntryDto>> DeleteOne(int id)
    {
        Empleado entidad = await _unitOfWork.Empleados.GetAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        _unitOfWork.Empleados.Delete(entidad);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoEntryDto>> UpdateOne([FromBody] EmpleadoEntryDto entryDto, [FromRoute] int id)
    {
        Empleado entidad = await _unitOfWork.Empleados.GetAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        entidad.Salario = entryDto.Salario;
        entidad.Persona.Nombre = entryDto.Nombre;
        entidad.Persona.Correo = entryDto.Correo;
        Cargo cargo = _unitOfWork.Cargos.Find(e => e.Nombre == entryDto.CargoNombre).FirstOrDefault();
        if(cargo == null){
            return NotFound();
        }
        entidad.Cargo = cargo;
        await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
}