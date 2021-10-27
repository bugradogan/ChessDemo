using System.Collections.Generic;


namespace ChessDemo
{
    class Pawn : Piece,ILegalMoves
    {
        public Pawn(char color, Coordinate coordinate, float score = 1) : base(color, coordinate, score)
        {
        }

        public List<Coordinate> targetPoints(Piece[,] board)
        {
            List<Coordinate> kordinats = new List<Coordinate>();
            int x = this.Coordinate.X;
            int y = this.Coordinate.Y;
            if (this.Color == 's')
            {
                kordinats.Add(new Coordinate(x + 1, y - 1));
                kordinats.Add(new Coordinate(x + 1, y + 1));
            }
            else
            {
                kordinats.Add(new Coordinate(x - 1, y - 1));
                kordinats.Add(new Coordinate(x - 1, y + 1));
            }
            return kordinats;
        }
    }
}
