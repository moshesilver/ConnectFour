using System.Drawing;

namespace ConnectFour {
    internal class Player {
        public string name;
        public Color color;
        public string colorName;
        public string colorIcon;
        public Player(string name, Color color, string colorName, string colorIcon) {
            this.name = name;
            this.colorName = colorName;
            this.color = color;
            this.colorIcon = colorIcon;
        }
    }
}
