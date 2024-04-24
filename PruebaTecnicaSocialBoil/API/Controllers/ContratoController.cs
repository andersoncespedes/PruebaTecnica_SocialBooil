
using API.Dto.Entry;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ContratoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ContratoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Contrato>>> GetAll()
    {
        IEnumerable<Departamento> result = await _unitOfWork.Departamentos.GetAllAsync();
        return Ok(result);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ContratoEntryDto>> SaveOne(ContratoEntryDto entryDto)
    {
        Contrato usuario = _mapper.Map<Contrato>(entryDto);
        _unitOfWork.Contratos.Add(usuario);
        await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContratoEntryDto>> DeleteOne(int id)
    {
        Contrato entidad = await _unitOfWork.Contratos.GetAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        _unitOfWork.Contratos.Delete(entidad);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContratoEntryDto>> UpdateOne([FromBody] ContratoEntryDto entryDto, [FromRoute] int id)
    {
        Contrato entidad = await _unitOfWork.Contratos.GetAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        entidad.FechaAlta = entryDto.FechaAlta;
        entidad.FechaBaja = entryDto.FechaBaja;
        entidad.Monto = entryDto.Monto;
        entidad.Servicio = entryDto.Servicio;
        await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
}
