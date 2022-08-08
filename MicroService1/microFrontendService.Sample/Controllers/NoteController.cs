using Microsoft.AspNetCore.Mvc;

namespace microFrontendService.Sample.Controllers;

[ApiController]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    private readonly ILogger<NoteController> _logger;

    public NoteController(ILogger<NoteController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetNotes")]
    [Route("List")]
    public IEnumerable<Note> Get()
    {
        var notes = new List<Note>();
        notes.Add(new Note {Id = 1, Comment = "This is sample note 1"});
        notes.Add(new Note{Id = 2, Comment = "This is sample note 2."});
        return notes;
    }

    [HttpGet(Name = "GetNote")]
    [Route("{id}")]
    public Note Get([FromRoute] long id)
    {
        var note = new Note();
            note.Id = id;
        if(id == 1){
            note.Comment = "This is sample note 1";
            note.Author = "Author1";
        }
        else if(id == 2){
            note.Comment = "This is sample note 2";
            note.Author = "Author2";
        }

        return note;
    }
}
