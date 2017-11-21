//AppDrawer.cs
using Apps.AppDrawerNS.BusinessLogic;
using Apps.AppDrawerNS.UserInterface;
using Apps.Core;
using Phone.Services;

namespace Apps.AppDrawerNS
{
    /// <summary>
    /// The AppDrawer App is responsible of managing all the Apps of a Phone
    /// </summary>
    public class AppDrawer : App
    {
        private AppDrawerBL logic;
        private AppDrawerUI ui;
        private NetworkService networkService;

        /// <summary>
        /// It initializes the App with a name of "App Drawer"
        /// </summary>
        public AppDrawer(NetworkService networkService) : base("App Drawer")
        {
            this.networkService = networkService;
            logic = new AppDrawerBL(networkService);
            ui = new AppDrawerUI(logic);
        }

        /// <summary>
        /// It starts the App Drawer, showing the Main Screen
        /// </summary>
        public override void Start()
        {
            ui.MainScreen();
        }

        /// <summary>
        /// The number of Apps currently in the AppDrawer
        /// </summary>
        public int AppsCount => logic.AppsCount;

        /// <summary>
        /// Gets an App from the App Drawer
        /// </summary>
        /// <param name="index">The position of the App to retrieve</param>
        /// <returns></returns>
        public App this[int index] { get { return logic[index]; } }

        /// <summary>
        /// Adds an App in the correct position. 
        /// Eventually increases the size of the list of another 100 places if necessary.
        /// </summary>
        /// <param name="toAdd">The App to insert in the list</param>
        public void AddApp(App toAdd) => logic.AddApp(toAdd);

        /// <summary>
        /// Finds the first occurrence of a specified Type of App 
        /// </summary>
        /// <typeparam name="TypeOfApp">The Type of the App to find</typeparam>
        /// <returns>The first occurrence of the App of the specified Type, null if not found.</returns>
        public TypeOfApp FindApp<TypeOfApp>() where TypeOfApp : App
        {
            return logic.FindApp<TypeOfApp>();
        }
    }
}
