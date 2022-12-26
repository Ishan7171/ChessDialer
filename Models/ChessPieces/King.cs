using System.Collections.Generic;

namespace ChessDialer.Models.ChessPieces
{
	public class King : ChessPieceBase
	{
		public override KeyValuePair<PositionOnBoard, List<PositionOnBoard>> PossibleNextMoves(int boardWidth, int boardHeight, PositionOnBoard currentPosition)
		{
			var nextMoves = new List<PositionOnBoard>();
			for (int xCoordinate = currentPosition.XCoordinate - 1; xCoordinate <= currentPosition.XCoordinate + 1; xCoordinate++)
			{
				for (int yCoordinate = currentPosition.YCoordinate - 1; yCoordinate <= currentPosition.YCoordinate + 1; yCoordinate++)
				{
					if ((xCoordinate == currentPosition.XCoordinate && yCoordinate == currentPosition.YCoordinate) || (xCoordinate >= boardWidth || xCoordinate <= -1) || (yCoordinate >= boardHeight || yCoordinate <= -1))
						continue;

					nextMoves.Add(new PositionOnBoard(xCoordinate, yCoordinate));

				}
			}
			return new KeyValuePair<PositionOnBoard, List<PositionOnBoard>>(currentPosition, nextMoves);
		}
	}
}
