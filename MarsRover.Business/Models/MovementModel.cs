using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business.Models
{
    public class MovementModel
    {
        public List<int> CoordinatesBoundaries { get; set; }
        public string MovesSet { get; set; }
        public string CurrnetPosition { get; set; }
    }
}
