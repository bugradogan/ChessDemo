using System.Collections.Generic;


namespace ChessDemo
{
    interface ILegalMoves
    {
        List<Coordinate> targetPoints(Piece[,] board);
    }
}
