using ChessDialer.Models;
using ChessDialer.Models.Board;
using System.Collections.Generic;

namespace ChessDialer.Interfaces
{
	public class TelephoneNumberCalculator : ITelephoneNumberCalculator
	{
		public List<string> GetAllCombinations(ChessBoardBase board, ChessPieceBase chessPiece, int combinationLength)
		{
			List<string> allPossibleNumbers = new List<string>();
			for (int x = 0; x < board.Width; x++)
			{
				for (int y = 0; y < board.Height; y++)
				{
					var phoneNumber = board.ValueAtLocation(x, y).ToString();
					if (combinationLength > 1)
						allPossibleNumbers.AddRange(GetNextNumbers(board, chessPiece, phoneNumber, new PositionOnBoard(x, y), combinationLength));
					else
						allPossibleNumbers.Add(phoneNumber);
				}
			}
			return allPossibleNumbers;
		}

		List<string> GetNextNumbers(ChessBoardBase board, ChessPieceBase piece, string phoneNumberStart, PositionOnBoard currentPosition, int combinationLength)
		{
			var nums = new List<string>();
			if (phoneNumberStart.Length == combinationLength)
				nums.Add(phoneNumberStart);
			else
			{
				var nextPossibleMoves = piece.PossibleNextMoves(board.Width, board.Height, currentPosition).Value;
				foreach (var nextPosition in nextPossibleMoves)
				{
					var newNum = phoneNumberStart + board.ValueAtLocation(nextPosition.XCoordinate, nextPosition.YCoordinate);

					if (newNum.Length < combinationLength)
					{
						nums.AddRange(GetNextNumbers(board, piece, newNum, nextPosition, combinationLength));
					}
					else
					{
						nums.Add(newNum);
					}
				}
			}
			return nums;
		}
	}
}
