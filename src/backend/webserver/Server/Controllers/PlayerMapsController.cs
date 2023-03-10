using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using Server.DatabaseConnection;

[ApiController]
[Route("[controller]")]
public class PlayerMapsController : ControllerBase
{
    [Authorize]
    [HttpGet("{username}")]
    public async Task<PlayerProgress> Get([FromRoute] string username)
    {
        PlayerProgress progress = await DownloadData.GetPlayerProgress(username);
        return progress;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<PlayerProgress> Post(PlayerProgress progress)
    {
        PostData.PostProgress(progress);
        Console.WriteLine("Player progress was posted");
        return progress;
    }
}