using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDemo
{
    class King : Piece
    {
        public King(char color, Coordinate kordinat, float score = 100) : base(color, kordinat, score)
        {
        }
    }
}
