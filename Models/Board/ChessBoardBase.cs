namespace ChessDialer.Models.Board
{
	public abstract class ChessBoardBase
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public char[,] Contents { get; set; }
		public char ValueAtLocation(int x, int y)
		{
			return Contents[x, y];
		}			
	}
}
