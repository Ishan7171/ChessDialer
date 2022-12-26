using System.Collections.Generic;

namespace ChessDialer.Models.ChessPieces
{
	public class Bishop : ChessPieceBase
	{
		public override KeyValuePair<PositionOnBoard, List<PositionOnBoard>> PossibleNextMoves(int boardWidth, int boardHeight, PositionOnBoard currentPosition)
		{
			var nextMoves = new List<PositionOnBoard>();
			for (int i = 1; i < boardWidth; i++)
			{
				int xCoordinate = currentPosition.XCoordinate - i;
				int yCoordinate = currentPosition.YCoordinate - i;
				if (xCoordinate >= 0 && yCoordinate >= 0)
					nextMoves.Add(new PositionOnBoard(xCoordinate, yCoordinate));

				xCoordinate = currentPosition.XCoordinate + i;
				yCoordinate = currentPosition.YCoordinate + i;
				if (xCoordinate < boardWidth && yCoordinate < boardHeight)
					nextMoves.Add(new PositionOnBoard(xCoordinate, yCoordinate));

				xCoordinate = currentPosition.XCoordinate + i;
				yCoordinate = currentPosition.YCoordinate - i;
				if (xCoordinate < boardWidth && yCoordinate >= 0)
					nextMoves.Add(new PositionOnBoard(xCoordinate, yCoordinate));

				xCoordinate = currentPosition.XCoordinate - i;
				yCoordinate = currentPosition.YCoordinate + i;
				if (xCoordinate >= 0 && yCoordinate < boardHeight)
					nextMoves.Add(new PositionOnBoard(xCoordinate, yCoordinate));

			}
			return new KeyValuePair<PositionOnBoard, List<PositionOnBoard>>(currentPosition, nextMoves);
		}
	}
}
