namespace Ilary.Application.DTOs;

public class CreateJobApplicationDto
{
    public Guid CoderId { get; set; } // El Coder que aplica
    public Guid JobId { get; set; } // La Empresa que recibe la aplicación

}