
using API.Dto.Entry;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class UsuarioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
    {
        IEnumerable<Usuario> result = await _unitOfWork.Usuarios.GetAllAsync();
        return Ok(result);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UsuarioEntryDto>> SaveOne(UsuarioEntryDto entryDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(entryDto);
        _unitOfWork.Usuarios.Add(usuario);
         await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioEntryDto>> DeleteOne(int id)
    {
        Usuario usuario = await _unitOfWork.Usuarios.GetAsync(id);
        if(usuario == null){
            return NotFound();
        }
        _unitOfWork.Usuarios.Delete(usuario);
         await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioEntryDto>> UpdateOne([FromBody]UsuarioEntryDto entryDto, [FromRoute]int id)
    {
        Usuario usuario = await _unitOfWork.Usuarios.GetAsync(id);
        if(usuario == null){
            return NotFound();
        }
        usuario.Persona.Correo = entryDto.Correo;
        usuario.Persona.Nombre = entryDto.Nombre;
        usuario.Password = entryDto.Password;
         await _unitOfWork.SaveAsync();
        return Created("Creado", entryDto);
    }
}