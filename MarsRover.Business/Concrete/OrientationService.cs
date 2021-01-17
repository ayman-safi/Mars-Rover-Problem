using MarsRover.Business.Abstract;
using MarsRover.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Business.Concrete
{
    public class OrientationService : IOrientationService
    {

        /// <summary>
        /// Find The final coordinates and heading Direction.
        /// </summary>
        /// <param name="CoordinatesBoundaries">is the upper-right coordinates of the plateau</param>
        /// <param name="MovesSet">series of instructions telling the rover how to explore the plateau.</param>
        /// <param name="CurrnetPosition">series of instructions telling the rover how to explore the plateau.</param>
        public string StartMovement(MovementModel input)
        {
            var isCurrentPositionValidFormat = SetCurrentPosition(input.CurrnetPosition);
            if (isCurrentPositionValidFormat)
            {
                foreach (var move in input.MovesSet)
                {
                    switch (move)
                    {
                        case 'M':
                            MoveForward();
                            break;
                        case 'L':
                            Rotate90Left();
                            break;
                        case 'R':
                            Rotate90Right();
                            break;
                        default:
                            Console.WriteLine($"Invalid Character {move}");
                            break;
                    }
                    //  down-left coordinates considered as (0,0)
                    if (X < 0 || X > input.CoordinatesBoundaries[0] || Y < 0 || Y > input.CoordinatesBoundaries[1])
                    {
                        throw new Exception($" Coordinates can not be beyond bounderies (0,0) and ({input.CoordinatesBoundaries[0]},{input.CoordinatesBoundaries[1]})");
                    }
                }
                Console.WriteLine($"Final coordinates and heading Direction is:");

                return $"{X} {Y} {Direction.ToString()}";

            }
            else
            {
                throw new Exception($"Invalid Format For your current position Input value.");
            }
        }


        #region Orientation Logic

        /// <summary>
        /// inital Coordinates and Heading Direction at 0 0 N
        /// </summary>
        public OrientationService()
        {
            X = Y = 0;
            Direction = Directions.N;
        }

        private int X { get; set; }
        private int Y { get; set; }
        private Directions Direction { get; set; }


        /// <summary>
        /// set the Current position of Rover 
        /// </summary>
        /// <param name="currentPostion"></param>
        /// <returns></returns>
        private bool SetCurrentPosition(string currentPostion)
        {
            var isCurrentPositionValidFormat = false;
            var currentPostionCharList = currentPostion.Split(' ');
            if (currentPostionCharList.Count() == 3)
            {
                try
                {
                    X = Convert.ToInt32(currentPostionCharList[0]);
                    Y = Convert.ToInt32(currentPostionCharList[1]);
                    Direction = (Directions)Enum.Parse(typeof(Directions), currentPostionCharList[2].ToString());
                    isCurrentPositionValidFormat = true;
                }
                catch
                {
                    isCurrentPositionValidFormat = false;
                }

            }

            return isCurrentPositionValidFormat;

        }
        /// <summary>
        /// Rotate To the left by 90 degree without movement
        /// </summary>
        private void Rotate90Left()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.W;
                    break;
                case Directions.S:
                    Direction = Directions.E;
                    break;
                case Directions.E:
                    Direction = Directions.N;
                    break;
                case Directions.W:
                    Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Rotate To the Right by 90 degree without movement
        /// </summary>
        private void Rotate90Right()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.E;
                    break;
                case Directions.S:
                    Direction = Directions.W;
                    break;
                case Directions.E:
                    Direction = Directions.S;
                    break;
                case Directions.W:
                    Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Make Forward Movement According To current Head Direction
        /// </summary>
        private void MoveForward()
        {
            switch (Direction)
            {
                case Directions.N:
                    Y += 1;
                    break;
                case Directions.S:
                    Y -= 1;
                    break;
                case Directions.E:
                    X += 1;
                    break;
                case Directions.W:
                    X -= 1;
                    break;
                default:
                    break;
            }
        }
        #endregion





    }
}

