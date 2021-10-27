using System.Collections.Generic;

namespace ChessDemo
{
    class Queen : Piece, ILegalMoves
    {
        List<Coordinate> coordinates = new List<Coordinate>();
        public Queen(char color, Coordinate kordinat, float score = 9) : base(color, kordinat, score)
        {
        }

        public List<Coordinate> targetPoints(Piece[,] board)
        {
           
            int x = this.Coordinate.X;
            int y = this.Coordinate.Y;
            // Get Right Targets
            ScanBoard(board, 0, 1);
            // Get Left Targets 
            ScanBoard(board, 0, -1);
            // Get Down Targets  
            ScanBoard(board, 1, 0);
            //  Get Up Targets    
            ScanBoard(board, -1, 0);
            // Get Lower Right Cross Targets
            ScanBoard(board, 1, 1);
            // Get Lower Left Cross Targets
            ScanBoard(board, 1, -1);
            // Get Up Right Cross Targets
            ScanBoard(board, -1, 1);
            // Get Up Left Cross Targets
            ScanBoard(board, -1, -1);

            return coordinates;

        }

        void ScanBoard(Piece[,] board, int r, int k)
        {

            for (int i = 1; i < 8; i++)
            {
                int x = 0;
                int y = 0;
                if (r == 0)
                    x = this.Coordinate.X;
                else if (r == 1)
                    x = this.Coordinate.X + i;
                else
                    x = this.Coordinate.X - i;

                if (k == 0)
                    y = this.Coordinate.Y;
                else if (k == 1)
                    y = this.Coordinate.Y + i;
                else
                    y = this.Coordinate.Y - i;

                if (x >= 0 && y >= 0 && x < 8 && y < 8 && this.Coordinate != board[x, y].Coordinate && board[x, y].GetType() != typeof(Empty))
                {
                    if (this.Color != board[x, y].Color)
                    {
                        coordinates.Add(board[x, y].Coordinate);
                    }
                    break;
                }

            }
        }


    }
}



