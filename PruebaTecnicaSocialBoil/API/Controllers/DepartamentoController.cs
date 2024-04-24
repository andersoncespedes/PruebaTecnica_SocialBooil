

using API.Dto.Entry;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
        [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Departamento>>> GetAll()
    {
        IEnumerable<Departamento> result = await _unitOfWork.Departamentos.GetAllAsync();
        return Ok(result);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DepartamentoEntryDto>> SaveOne(DepartamentoEntryDto entryDto)
    {
        Departamento usuario = _mapper.Map<Departamento>(entryDto);
        _unitOfWork.Departamentos.Add(usuario);
         await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoEntryDto>> DeleteOne(int id)
    {
        Departamento entidad = await _unitOfWork.Departamentos.GetAsync(id);
        if(entidad == null){
            return NotFound();
        }
        _unitOfWork.Departamentos.Delete(entidad);
         await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoEntryDto>> UpdateOne([FromBody]DepartamentoEntryDto entryDto, [FromRoute]int id)
    {
        Departamento entidad = await _unitOfWork.Departamentos.GetAsync(id);
        if(entidad == null){
            return NotFound();
        }
        entidad.NombreDepartamento = entryDto.NombreDepartamento;
        entidad.NombreDivision = entryDto.NombreDivision;
        entidad.NombreLocalidad = entryDto.NombreLocalidad;
         await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
}