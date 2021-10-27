

namespace ChessDemo
{
    class Coordinate
    {
       private int x;
       private int y;

        public Coordinate(int x,int y)
        {
            this.y = y;
            this.x = x;
        }
        public override string ToString()
        {
            return "(" + this.x + "," + this.y + ")"; 
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
