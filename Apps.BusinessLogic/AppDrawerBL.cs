//AppDrawerBL.cs
using Apps.Core;
using Apps.DataLayer;
using Phone.Services;

namespace Apps.AppDrawerNS.BusinessLogic
{
    /// <summary>
    /// The logic behind the AppDrawer
    /// </summary>
    internal class AppDrawerBL
    {
        private Container<App> apps;
        internal NetworkService NetworkService;
        /// <summary>
        /// Initializes an AppDrawer with room for 100 Apps
        /// </summary>
        internal AppDrawerBL(NetworkService networkService)
        {
            apps = new Container<App>();
            this.NetworkService = networkService;
        }

        /// <summary>
        /// The number of Apps currently in the AppDrawer
        /// </summary>
        internal int AppsCount => apps.Count;

        /// <summary>
        /// Gets an App from the AppDrawer
        /// </summary>
        /// <param name="index">The position of the App to retrieve</param>
        /// <returns></returns>
        internal App this[int index] {
            get {
                return apps[index];
            }
        }

        /// <summary>
        /// Adds an app in the correct position. 
        /// Eventually increases the size of the list of another 100 places if necessary.
        /// </summary>
        /// <param name="toAdd">The app to insert in the list</param>
        internal void AddApp(App toAdd) {
            apps.Add(toAdd);
            if (toAdd is INetworkClient) {
                ((INetworkClient)toAdd).ConnectToNetworkService(NetworkService);
            }
        }
        
        /// <summary>
        /// Finds the first occurrence of a specified Type of App 
        /// </summary>
        /// <typeparam name="TypeOfApp">The Type of the App to find</typeparam>
        /// <returns>The first occurrence of the App of the specified Type, null if not found.</returns>
        internal TypeOfApp FindApp<TypeOfApp>() where TypeOfApp : App {
            for (int i = 0; i < AppsCount; i++)
            {
                if (apps[i].GetType() == typeof(TypeOfApp)) {
                    return (TypeOfApp)apps[i];
                }
            }
            return null;
        }
    }
}
