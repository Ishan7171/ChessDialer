namespace ChessDialer.Models.Board
{
	public class ChessBoardNumericKeypad : ChessBoardBase
	{
		public ChessBoardNumericKeypad(int width, int height)
		{
			Width = width;
			Height = height;
			Contents = new char[Width, Height];
			Populate();

		}
		void Populate()
		{
			Contents[0, 0] = '1';
			Contents[0, 1] = '2';
			Contents[0, 2] = '3';
			Contents[1, 0] = '4';
			Contents[1, 1] = '5';
			Contents[1, 2] = '6';
			Contents[2, 0] = '7';
			Contents[2, 1] = '8';
			Contents[2, 2] = '9';
			Contents[3, 0] = '*';
			Contents[3, 1] = '0';
			Contents[3, 2] = '#';
		}
	}
}
