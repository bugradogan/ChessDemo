using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDemo
{
    class Bishop : Piece
    {
        public Bishop(char color, Coordinate kordinat, float score = 3) : base(color, kordinat, score)
        {
        }
    }
}
