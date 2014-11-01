using System.Linq;

namespace CleanCode
{
    public class Chess
    {
        private readonly Board Board;

        public Chess(Board b)
        {
            this.Board = b;
        }

        public string GetWhiteStatus()
        {
            var bad = CheckForWhite();
            var ok = false;
            foreach (var loc1 in Board.Figures(Cell.White))
            {
                foreach (var loc2 in Board.Get(loc1).Figure.Moves(loc1, Board))
                {
                    var oldDest = Board.PerformMove(loc1, loc2);
                    ok = !CheckForWhite();
                    Board.PerformUndoMove(loc1, loc2, oldDest);
                }
            }
            if (bad)
                return ok ? "check" : "mate";
            return ok ? "ok" : "stalemate";
        }

        private bool CheckForWhite()
        {
            var bFlag = false;
            foreach (var loc in Board.Figures(Cell.Black))
            {
                var cell = Board.Get(loc);
                var moves = cell.Figure.Moves(loc, Board);
                foreach (var to in moves.Where(to => Board.Get(to).IsWhiteKing))
                    bFlag = true;
            }
            return bFlag;
        }
    }
}