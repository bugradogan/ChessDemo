using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChessDemo
{
    class Board
    {
        // Create 2D Piece Array for Board 
        Piece[,] board = new Piece[8, 8];

        // White and Black Piece Score
        float whiteSCore = 0;
        float blackScore = 0;

        // Writer for Sonuçlar.txt
        StreamWriter Write;

        //Txt file name
        string fileName;
        public Board()
        {
            // Write Sonuçlar.txt in ChessDemoChessDemo\bin\Debug
            Write = new StreamWriter("Result/Sonuçlar.txt");
            // Write Result Title
            Write.WriteLine("Tahta Dosya Adı     Sonuçlar");
            Console.WriteLine("Tahta Dosya Adı     Sonuçlar");

            // Get al txt files from current directory - ChessDemoChessDemo\bin\Debug
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt", SearchOption.TopDirectoryOnly);

            // Read,split  and fill board from txt files
            for (int i = 0; i < files.Length; i++)
            {
                fileName = files[i];
                var lines = File.ReadLines(fileName);
                int x = 0, y;
                foreach (var line in lines)
                {
                    string[] words = line.Split(' ');
                    y = 0;
                    char color;
                    // cell[0] = Piece type
                    // cell[1] = Piece color
                    foreach (var cell in words)
                    {
                        color = cell[1];
                        if (cell[0] == 'p')
                        {
                            board[x, y] = new Pawn(color, new Coordinate(x, y));
                            if (color == 's')
                                blackScore += 1;
                            else
                                whiteSCore += 1;
                        }
                        else if (cell[0] == 'a')
                        {
                            board[x, y] = new Knight(color, new Coordinate(x, y));
                            if (color == 's')
                                blackScore += 3;
                            else
                                whiteSCore += 3;
                        }
                        else if (cell[0] == 'f')
                        {
                            board[x, y] = new Bishop(color, new Coordinate(x, y));
                            if (color == 's')
                                blackScore += 3;
                            else
                                whiteSCore += 3;
                        }
                        else if (cell[0] == 'k')
                        {
                            board[x, y] = new Rook(color, new Coordinate(x, y));
                            if (color == 's')
                                blackScore += 5;
                            else
                                whiteSCore += 5;
                        }
                        else if (cell[0] == 'v')
                        {
                            board[x, y] = new Queen(color, new Coordinate(x, y));
                            if (color == 's')
                                blackScore += 9;
                            else
                                whiteSCore += 9;
                        }
                        else if (cell[0] == 's')
                        {
                            board[x, y] = new King(color, new Coordinate(x, y));
                            if (color == 's')
                                blackScore += 100;
                            else
                                whiteSCore += 100;
                        }
                        else
                        {
                            board[x, y] = new Empty();
                        }
                        y++;
                    }
                    x++;
                }
                Start();
            }
            // Close write file
            Write.Close();
        }

        public void Start()
        {
            char color = ' ';
            Coordinate location;
            Piece piece = null;
            List<Coordinate> targets = new List<Coordinate>();      
           
            // Scan Board
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    // Get Current Piece
                    piece = GetChessMan(x, y);
                    // Get Current Color
                    color = piece.Color;
                    // Get Current Coord
                    location = piece.Coordinate;
                    switch (piece)
                    {
                        // If piece = pawn
                        case Pawn p:
                            // Get All Pawn targets from board
                            List<Coordinate>  pTargets = new Pawn(color, location).targetPoints(board);
                            foreach (var item in pTargets)
                            {
                                // Add the target list If the target piece  is not empty and has different colors
                                if (GetChessMan(item.X, item.Y).GetType() != typeof(Empty) && GetChessMan(item.X, item.Y).Color != color)
                                {
                                    targets.Add(item);
                                }
                            }
                            break;
                        // If piece = pawn
                        case Knight k:
                            // Get All Knight targets from board
                            List<Coordinate> kTargets = new Knight(color, location).targetPoints(board);
                            foreach (var item in kTargets)
                            {
                                // Add the target list If the target piece is not empty and has different colors
                                if (GetChessMan(item.X, item.Y).GetType() != typeof(Empty) && GetChessMan(item.X, item.Y).Color != color)
                                {
                                    targets.Add(item);
                                }
                            }
                            break;
                        case Queen q:
                            List<Coordinate> qTargets = new Queen(color, location).targetPoints(board);
                            foreach (var item in qTargets)
                            {
                                // Add the target list If the target piece is not empty and has different colors
                                if (GetChessMan(item.X, item.Y).GetType() != typeof(Empty) && GetChessMan(item.X, item.Y).Color != color)
                                {
                                    targets.Add(item);
                                }
                            }
                            break;

                    }

                }
            }

            // Scan all targets
            foreach (Coordinate target in targets)
            {
                // Get target piece from board
                Piece targetPiece = GetChessMan(target.X, target.Y);
                // Get target piece color from board
                char targetColor = targetPiece.Color;

                // Decrease score if the target is white
                if (targetColor == 'b')
                {
                    whiteSCore -= targetPiece.Score / 2;
                    // If the target has been scanned, set score to zero.
                    targetPiece.Score = 0;
                }

                // Decrease score if the target is black
                if (targetColor == 's')
                {
                    blackScore -= targetPiece.Score / 2;
                    // If the target has been scanned, set score to zero.
                    targetPiece.Score = 0;
                }

            }
            // Print result console and Sonuçlar.txt file in Result/Sonuçlar.txt
            PrintResult();
            // Set scores to 0 for other boards.
            whiteSCore = 0;
            blackScore = 0;

        }

        // Getting the piece from the X,Y coordinates on the board.
        private Piece GetChessMan(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < 8 && y < 8)
                return board[x, y];
            return new Empty();
        }

        // Print result console and Sonuçlar.txt file in Result/Sonuçlar.txt
        public void PrintResult()
        {
            // Split file path for board.txt type
            string lastWord = fileName.Split('\\').Last();
            // Print result console and Sonuçlar.txt file in Result/Sonuçlar.txt
            Write.WriteLine(lastWord + "          Siyah: " + blackScore + " Beyaz: " + whiteSCore);            
            Console.WriteLine(lastWord + "          Siyah: " + blackScore + " Beyaz: " + whiteSCore);
        }
    }
}
