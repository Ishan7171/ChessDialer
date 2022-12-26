using System.Collections.Generic;

namespace ChessDialer.Models
{
	public abstract class ChessPieceBase
	{
		public abstract KeyValuePair<PositionOnBoard, List<PositionOnBoard>> PossibleNextMoves(int boardWidth, int boardHeight, PositionOnBoard currentPosition);
	}

	public class PositionOnBoard
	{
		public int XCoordinate { get; set; }
		public int YCoordinate { get; set; }

		public PositionOnBoard(int xCoordinate, int yCoordinate)
		{
			XCoordinate = xCoordinate;
			YCoordinate = yCoordinate;
		}
	}
}
