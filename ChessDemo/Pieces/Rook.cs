using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDemo
{
    class Rook : Piece
    {
        public Rook(char color, Coordinate kordinat, float score = 5) : base(color, kordinat, score)
        {
        }
    }
}
