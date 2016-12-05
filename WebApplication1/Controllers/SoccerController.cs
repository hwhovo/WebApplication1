using Soccer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class SoccerController : Controller
    {
        SoccerContext db = new SoccerContext();

        // GET: Soccer
        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Team);
            return View(players.ToList());
        }

        public ActionResult TeamDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Team team = db.Teams.Include(t => t.Players).FirstOrDefault(t => t.Id == id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список команд для передачи в представление
            SelectList teams = new SelectList(db.Teams, "Id", "Name");
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Player player)
        {
            //Добавляем игрока в таблицу
            db.Players.Add(player);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }

        [HttpGet]
        async public Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Player player = await db.Players.FindAsync(id);

            if (player != null)
            {
                SelectList teams = new SelectList(db.Teams, "id", "Name", player.TeamId);
                ViewBag.Teams = teams;
                return View(player);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        async public Task<ActionResult> Edit(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}