using Microsoft.AspNetCore.Mvc;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("Controller")]
public class MedicoController : ControllerBase
{
    private static readonly string[] Nomes = new[]
    {
        "Dr.Matheus", "Dr.Eduardo", "Dr.Welvis", "Dr.Giuseppe", "Dr.Pedro", "Dr.Rafael", "Dr.Jose", "Dr.Henrique", "Dr.Antonio", "Dr.Scorching"
    };

    private readonly ILogger<MedicoController> _logger;

    public MedicoController(ILogger<MedicoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Medicos")]
    public IEnumerable<Medico> Get()
    {
        return Enumerable.Range(1, 10).Select(index => new Medico
        {
            Id = index,
            Data = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            CRM = Random .Shared.Next(10000, 99999),
            Nome = Nomes[Random.Shared.Next(Nomes.Length)]
        })
        .ToArray();
    }
    [HttpPost(Name = "Medicos")]
    public IActionResult Post([FromBody] Medico medico)
    {
        return CreatedAtAction(nameof(Get), new { id = medico.Id }, medico);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Medico medico)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }

}
