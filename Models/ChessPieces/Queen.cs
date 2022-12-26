using System.Collections.Generic;

namespace ChessDialer.Models.ChessPieces
{
	public class Queen : ChessPieceBase
	{
		public override KeyValuePair<PositionOnBoard, List<PositionOnBoard>> PossibleNextMoves(int boardWidth, int boardHeight, PositionOnBoard currentPosition)
		{
			var nextMoves = new List<PositionOnBoard>();
			var bishop = new Bishop();
			nextMoves.AddRange(bishop.PossibleNextMoves(boardWidth, boardHeight, currentPosition).Value);

			var rook = new Rook();
			nextMoves.AddRange(rook.PossibleNextMoves(boardWidth, boardHeight, currentPosition).Value);

			return new KeyValuePair<PositionOnBoard, List<PositionOnBoard>>(currentPosition, nextMoves);
		}
	}
}
