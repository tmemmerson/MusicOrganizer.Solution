using Microsoft.AspNetCore.Mvc; 
using MusicOrganizer.Models;
using System.Collections.Generic; 

namespace MusicOrganizer.Controllers
{

  public class AlbumController : Controller
{
  [HttpGet("/artists/{artistId}/albums/{albumId}")]
  public ActionResult New(int artistId)
  {
    Artist artist = Artist.Find(artistId);
    return View(artist);
  }

  public ActionResult Show(int artistId, int albumId)
  {
    Album album = Album.Find(albumId);
    Artist artist = Artist.Find(artistId);
    Dictionary <string, object> model = new Dictionary <string, object>();
    model.Add("artist", artist);
    model.Add("album", album);
    return View (model);
  }

  [HttpPost("/albums/delete")]
  public ActionResult DeleteAll()
  {
    Album.ClearAll();
    return View(); 
  }
}

}