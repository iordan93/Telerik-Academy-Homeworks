namespace MinesweeperGame
{
    using System;
    using System.Linq;

    public class Score
    {
        private string nickname;
        private int points;

        public Score()
        {
        }

        public Score(string nickname, int points)
        {
            this.nickname = nickname;
            this.points = points;
        }

        public string Nickname
        {
            get { return this.nickname; }
            set { this.nickname = value; }
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }
    }
}
