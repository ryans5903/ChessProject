using System;
using System.ComponentModel;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        internal Pawn[,] pieces;
       

        public ChessBoard ()
        {
            pieces = new Pawn[MaxBoardWidth, MaxBoardHeight];
        }

      
        /// <summary>
        /// Method to add pawn to the board, validates if board position is valid and if so adds it the pawn.
        /// </summary>
        /// <param name="pawn">Pawn object to be added</param>
        /// <param name="xCoordinate">X-Coordinate to place pawn</param>
        /// <param name="yCoordinate">Y-coordinate to place pawn</param>
        /// <param name="pieceColour">Colour of pawn to add to the board (Black or White)</param>
        public void Add(Pawn pawn, int xCoordinate, int yCoordinate, PieceColor pieceColour)
        {
            
            //check if coordinates provided are legal board position
            bool legalPos = IsLegalBoardPosition(xCoordinate, yCoordinate);
            if (!legalPos)
            {
                Console.WriteLine($" xcoord: {xCoordinate} and ycoord: {yCoordinate} is not a legal board position");
                //Not legal so set x and y coords to -1.
                pawn.XCoordinate = -1;
                pawn.YCoordinate = -1; 
                return;
            }
           
            // Check if there's already a pawn here, if there is set X and Y pos to (-1,-1)
            try { 
                if (pieces[xCoordinate, yCoordinate] != null)
                {
                    Console.WriteLine($"Pawn already exists at {xCoordinate}, {yCoordinate}");
                    pawn.XCoordinate = -1;
                    pawn.YCoordinate = -1;
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught:" + e.Message + "Source: " + e.Source);
            }

            //If all cases are successful and we get here, add pawn
            pawn.XCoordinate = xCoordinate;
            pawn.YCoordinate = yCoordinate;
            pawn.PieceColor = pieceColour;
            pieces[xCoordinate, yCoordinate] = pawn;
        }

        /// <summary>
        /// Method to validate if the position to add a piece to is valid.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <returns>True or False depending on if position is valid or not</returns>
        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            bool isLegal = false;
            if(
                (xCoordinate >= 0 & yCoordinate >= 0)
                && 
                (xCoordinate <= (MaxBoardWidth -1) & yCoordinate <= (MaxBoardHeight -1))
                )
            {
                isLegal = true;
            }

            return isLegal;

        }

    }
}
