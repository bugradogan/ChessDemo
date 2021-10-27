using System.Collections.Generic;


namespace ChessDemo
{
    class Knight : Piece, ILegalMoves
    {
        public Knight(char color, Coordinate kordinat, float score = 3) : base(color, kordinat, score)
        {
        }

        public List<Coordinate> targetPoints(Piece[,] board)
        {
            List<Coordinate> kordinats = new List<Coordinate>();
            int x = this.Coordinate.X;
            int y = this.Coordinate.Y;

            // Knight Down Movement
            kordinats.Add(new Coordinate(x + 2, y + 1));
            kordinats.Add(new Coordinate(x + 2, y - 1));
            // Knight Up Movement
            kordinats.Add(new Coordinate(x - 2, y + 1));
            kordinats.Add(new Coordinate(x - 2, y - 1));
            // Knight Left Movement
            kordinats.Add(new Coordinate(x - 1, y - 2));
            kordinats.Add(new Coordinate(x + 1, y - 2));
            // Knight Right Movement
            kordinats.Add(new Coordinate(x - 1, y + 2));
            kordinats.Add(new Coordinate(x + 1, y + 2));

            return kordinats;
        }
    }
}
