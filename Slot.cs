namespace ConnectFour {
    internal class Slot {
        public string? color;
        public int row;
        public int col;
        public Slot(int row, int col) {
            this.row = row;
            this.col = col;
        }
    }
}
