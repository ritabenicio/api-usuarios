using System.ComponentModel.DataAnnotations.Schema;

[Table("tb_usuario")]
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
}