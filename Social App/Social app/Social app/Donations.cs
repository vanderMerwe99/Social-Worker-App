using System.Windows.Forms;

namespace Social_app
{
    public partial class Donations : UserControl
    {
        private static Donations _instance;

        public static Donations Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Donations();
                return _instance;
            }
        }
        public Donations()
        {
            InitializeComponent();
        }
    }
}
