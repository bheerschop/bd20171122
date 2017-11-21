//Phone.cs
using Apps.AppDrawerNS;
using Phone.Services;
using PhoneNS.BusinessLogic;
using PhoneNS.UserInterface;

namespace PhoneNS
{
    /// <summary>
    /// A Phone
    /// </summary>
    public class Phone
    {
        private PhoneBL logic;
        private PhoneUI ui;
        /// <summary>
        /// The Brand of the Phone
        /// </summary>
        public string Brand {
            get { return logic.Brand; }
            set{ logic.Brand = value; }
        }
        /// <summary>
        /// The Phone Model
        /// </summary>
        public string Model {
            get { return logic.Model; }
            set { logic.Model = value; }
        }

        public NetworkService NetworkService => logic.NetworkService;

        /// <summary>
        /// Direct reference to the AppDrawer App
        /// </summary>
        public AppDrawer AppDrawer => logic.AppDrawer;

        /// <summary>
        /// Initializes a new Phone with its logic and ui
        /// </summary>
        public Phone()
        {
            logic = new PhoneBL();
            ui = new PhoneUI(logic);
        }

        /// <summary>
        /// It shows the MainScreen of the UI
        /// </summary>
        public void Start() {
            ui.MainScreen();
        }
    }
}
