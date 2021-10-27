using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDemo
{
    class Piece
    {
        private char color;
        private Coordinate coordinate;
        private float score;

        protected Piece(char color, Coordinate coordinate, float score)
        {
            this.color = color;
            this.coordinate = coordinate;
            this.score = score;
        }

        protected Piece()
        {
           
        }

        public char Color { get => color; set => color = value; }
        public Coordinate Coordinate { get => coordinate; set => coordinate = value; }
        public float Score { get => score; set => score = value; }
        

    }
}
