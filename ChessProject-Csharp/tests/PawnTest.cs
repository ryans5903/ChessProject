﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;  

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class PawnTest
	{
		private ChessBoard chessBoard;
		private Pawn pawn;

		[TestInitialize]
		public void SetUp()
		{
			chessBoard = new ChessBoard();
			pawn = new Pawn(PieceColor.Black);
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_XCoordinate()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			Assert.AreEqual(pawn.XCoordinate, 6);
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_YCoordinate()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			Assert.AreEqual(pawn.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			pawn.Move(MovementType.Move, 7, 3);
            Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			pawn.Move(MovementType.Move, 4, 3);
            Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Black_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			pawn.Move(MovementType.Move, 6, 2);
			Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 2);
		}

        [TestMethod]
        public void Pawn_White_Move_LegalCoordinates_Forward_UpdatesCoordinates()
        {
            chessBoard.Add(pawn, 6, 3, PieceColor.White);
            pawn.Move(MovementType.Move, 6, 4);
            Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 4);
        }

        [TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
        public void Pawn_Capture_LegalCoordinates_Forward_UpdatesCoordinates()
        {
            chessBoard.Add(pawn, 6, 3, PieceColor.Black);
            pawn.Move(MovementType.Capture, 6, 2);
			
        }
        		
    }
}
