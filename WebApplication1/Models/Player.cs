using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soccer.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        //when 1 to many connection
        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}