using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class ArtistController : Controller
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }
    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View(); 
    }
    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      return RedirectToAction("Index");
    }
    [HttpGet("/artist/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary <string, object> model = new Dictionary<string, object> ();
      Artist newArtist = Artist.Find(id);
      List <Album> artistAlbums = newArtist.Albums;
      model.Add("artist", newArtist);
      model.Add("albums", artistAlbums);
      return View(model);
    }
  }
}