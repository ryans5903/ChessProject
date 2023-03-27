using System;

namespace SolarWinds.MSP.Chess
{
    public class Pawn
    {
        private ChessBoard chessBoard;
        private int xCoordinate;
        private int yCoordinate;
        private PieceColor pieceColor;
        
        public ChessBoard ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return xCoordinate; }
            set { xCoordinate = value; }
        }
        
        public int YCoordinate
        {
            get { return yCoordinate; }
            set { yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return pieceColor; }
            set { pieceColor = value; }
        }

        public Pawn(PieceColor pieceColor)
        {
            this.pieceColor = pieceColor;
        }

        /// <summary>
        /// Method to move pawn to new place on the board, currently only implemented for move but will hanlde if it is passed a capture command.
        /// </summary>
        /// <param name="movementType">Move or Capture accepted, will only execute Move</param>
        /// <param name="newX">X-Coordinate to move pawn to</param>
        /// <param name="newY">Y-coordinate to move pawn to</param>
        /// <exception cref="NotImplementedException">Exception provided if Capture is passed</exception>
        public void Move(MovementType movementType, int newX, int newY)
        {
            // Split here based on Movement type
            switch (movementType)
            {
                //Currently only implemented case being handled, if any others throw exception. 
                case MovementType.Move:
                    //Check move
                    bool move = CheckMove(newX, newY, this.pieceColor);
                    if (move)
                    {
                        this.XCoordinate = newX;
                        this.YCoordinate = newY;

                    }

                    break;
                case MovementType.Capture: //Not yet implemented but code here to future proof. 
                    throw new NotImplementedException();

            }
                      
        }

        /// <summary>
        /// Method to check the validity of a Pawn move depending on piece colour.
        /// Currently only implemented for move, not capture movements. 
        /// </summary>
        /// <param name="newX">X-Coordinate to move pawn toX/param>
        /// <param name="newY">Y-Coordinate to move pawn to</param>
        /// <returns>True or False depending on if move is valid for a pawn</returns>
        internal bool CheckMove(int newX, int newY, PieceColor pawnColour)
        {
            bool move = false;

            //get pawn pos
            int currX = this.XCoordinate;
            int currY = this.YCoordinate;
            
            //If moving X coords return early
            if (newX != currX) // Check we are not going left or right, inform user if we are at this point just a console line.
            {
                Console.WriteLine("Illegal move: Cannot move pawn left or right, only forwards");
                return move;
            }
            

            switch (pawnColour)
            {
                case PieceColor.Black:
                    //check new coords are an upward (forward) move, not diagonal or backwards.
                    // else if statements are only here to provide user information and don't give any functional impact to the code. 
                    if (newX == currX && newY == (currY - 1))
                    {
                        move = true;

                    }

                    break;

                case PieceColor.White:
                    //check new coords are a downward (forward) move, not diagonal or backwards.
                    // else if statements are only here to provide user information and don't give any functional impact to the code. 
                    if (newX == currX && newY == (currY + 1))
                    {
                        move = true;
                    }
                    break;
            }
          
            return move;
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
