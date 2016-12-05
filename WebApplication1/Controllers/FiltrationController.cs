using Filtration.Models;
using Soccer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Filtration.Controllers
{
    public class FiltrationController:Controller
    {
        SoccerContext db = new SoccerContext();

        public ActionResult Index(int? team, string position)
        {
            IQueryable<Player> players = db.Players.Include(p => p.Team);
            if (team != null && team != 0)
            {
                players = players.Where(p => p.TeamId == team);
            }
            if (!String.IsNullOrEmpty(position) && !position.Equals("All"))
            {
                players = players.Where(p => p.Position == position);
            }

            List<Team> teams = db.Teams.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            teams.Insert(0, new Team { Name = "All", Id = 0 });

            PlayersListViewModel plvm = new PlayersListViewModel
            {
                Players = players.ToList(),
                Teams = new SelectList(teams, "Id", "Name"),
                Positions = new SelectList(new List<string>()
            {
                "All",
                "Forward",
                "Halfback",
                "Defender",
                "GoalKeeper"
            })
            };
            return View(plvm);
        }

        [HttpPost]
        public ActionResult Edit(PlayerViewModel playerModel)
        {
            Player player = db.Players.Find(playerModel.Id);
            if (player == null)
                return HttpNotFound();
            player.Position = playerModel.Position;
            player.Age = playerModel.Age;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}