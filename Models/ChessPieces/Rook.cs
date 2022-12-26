using System.Collections.Generic;

namespace ChessDialer.Models
{
	public class Rook : ChessPieceBase
	{
		public override KeyValuePair<PositionOnBoard, List<PositionOnBoard>> PossibleNextMoves(int boardWidth, int boardHeight, PositionOnBoard currentPosition)
		{
			var nextMoves = new List<PositionOnBoard>();
			for (int xCoordinate = 0; xCoordinate < boardWidth; xCoordinate++)
			{
				if (xCoordinate != currentPosition.XCoordinate)
					nextMoves.Add(new PositionOnBoard(xCoordinate, currentPosition.YCoordinate));
			}
			for (int yCoordinate = 0; yCoordinate < boardHeight; yCoordinate++)
			{
				if (yCoordinate != currentPosition.YCoordinate)
					nextMoves.Add(new PositionOnBoard(currentPosition.XCoordinate, yCoordinate));
			}
			return new KeyValuePair<PositionOnBoard, List<PositionOnBoard>>(currentPosition, nextMoves);
		}
	}
}
