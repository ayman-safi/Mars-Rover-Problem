using MarsRover.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business.Abstract
{
    public interface IOrientationService
    {

        string StartMovement(MovementModel input);
    }
}
