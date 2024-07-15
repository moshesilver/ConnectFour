namespace ConnectFour {
    internal class Board {
        private static Board? board;
        public Slot[,] slots = new Slot[7, 6];
        private Board() {
            for (int i = 0; i < slots.GetLength(0); i++) {
                for (int j = 0; j < slots.GetLength(1); j++) {
                    slots[i, j] = new(i, j);
                }
            }
        }
        public static Board GetBoard() {
            board ??= new Board();
            return board;
        }
        public void DisplayBoard() {
            Console.WriteLine("+----+----+----+----+----+----+----+");
            for (int i = 0; i < slots.GetLength(1); i++) {
                for (int j = 0; j < slots.GetLength(0); j++) {
                    Console.Write($"| {(slots[j, i].color != null ? slots[j, i].color : "  ")} ");
                }
                Console.WriteLine($"|");
                Console.WriteLine("+----+----+----+----+----+----+----+");
            }
            Console.WriteLine("   1    2    3    4    5    6    7");
        }
    }
}
