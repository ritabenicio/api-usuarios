using Microsoft.AspNetCore.Mvc;

using CRUDUSUARIO.Context;

namespace CRUDUSUARIO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{

    // GET api/usuario
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> Get()
    {

        var context = new ApplicationContext();
        var users = context.Usuarios.ToList();

        return Ok(users);
    }

    // GET api/usuario/5
    [HttpGet("{id}")]
    public ActionResult<Usuario> Get(int id)
    {
        var context = new ApplicationContext();
        var user = context.Usuarios.Find(id);

        return Ok(user);
    }

    // POST api/usuario
    [HttpPost]
    public IActionResult Post([FromBody] UsuarioDTO usuario)
    {
        var context = new ApplicationContext();
        var novoUsuario = new Usuario { Id = usuario.id, Nome = usuario.nome, Cpf = usuario.cpf, Email = usuario.email };
        context.Usuarios.Add(novoUsuario);
        context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = usuario.id }, usuario);
    }

    // PUT api/usuario/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UsuarioDTO usuario)
    {
        var context = new ApplicationContext();
        var user = context.Usuarios.Find(id);

        if (user != null)
        {
            user.Nome = usuario.nome;
            user.Email = usuario.email;
            user.Cpf = usuario.cpf;

            context.SaveChanges();
        }

        return NoContent();
    }

    // DELETE api/usuario/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var context = new ApplicationContext();

        // Encontre o registro pelo ID
        var registro = context.Usuarios.Find(id);

        if (registro != null)
        {
            // Remova o registro
            context.Usuarios.Remove(registro);
            context.SaveChanges();
            Console.WriteLine("Registro removido com sucesso!");
        }

        return NoContent();
    }
}

public class UsuarioDTO
{
    public int id { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public string email { get; set; }
}
