using System.Collections.Generic;

namespace ChessDialer.Models.ChessPieces
{
	public class Knight : ChessPieceBase
	{
		public override KeyValuePair<PositionOnBoard, List<PositionOnBoard>> PossibleNextMoves(int boardWidth, int boardHeight, PositionOnBoard currentPosition)
		{
			var nextMoves = new List<PositionOnBoard>();
			for (int i = 2; i >= 1; i--)
				for (int j = 1; j <= 2; j++)
				{
					if (i == j)
						continue;

					int xCoordinate = currentPosition.XCoordinate - i;
					int yCoordinate = currentPosition.YCoordinate - j;
					if (xCoordinate >= 0 && yCoordinate >= 0 && xCoordinate < boardWidth && yCoordinate < boardHeight)
						nextMoves.Add(new PositionOnBoard(xCoordinate, yCoordinate));

					yCoordinate = currentPosition.YCoordinate + j;
					if (xCoordinate >= 0 && yCoordinate >= 0 && xCoordinate < boardWidth && yCoordinate < boardHeight)
						nextMoves.Add(new PositionOnBoard(xCoordinate, yCoordinate));

					xCoordinate = currentPosition.XCoordinate + i;
					yCoordinate = currentPosition.YCoordinate - j;
					if (xCoordinate >= 0 && yCoordinate >= 0 && xCoordinate < boardWidth && yCoordinate < boardHeight)
						nextMoves.Add(new PositionOnBoard(xCoordinate, yCoordinate));

					yCoordinate = currentPosition.YCoordinate + j;
					if (xCoordinate >= 0 && yCoordinate >= 0 && xCoordinate < boardWidth && yCoordinate < boardHeight)
						nextMoves.Add(new PositionOnBoard(xCoordinate, yCoordinate));

				}

			return new KeyValuePair<PositionOnBoard, List<PositionOnBoard>>(currentPosition, nextMoves);
		}
	}
}
