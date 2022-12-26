using System.Collections.Generic;

namespace ChessDialer.Models.ChessPieces
{
	public class Pawn : ChessPieceBase
	{
		public override KeyValuePair<PositionOnBoard, List<PositionOnBoard>> PossibleNextMoves(int boardWidth, int boardHeight, PositionOnBoard currentPosition)
		{
			var nextMoves = new List<PositionOnBoard>();
			for (int xCoordinate = currentPosition.XCoordinate + 1; xCoordinate < boardWidth; xCoordinate++)
				nextMoves.Add(new PositionOnBoard(xCoordinate, currentPosition.YCoordinate));

			return new KeyValuePair<PositionOnBoard, List<PositionOnBoard>>(currentPosition, nextMoves);
		}
	}
}
