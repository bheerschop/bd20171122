//App.cs
namespace Apps.Core
{
    /// <summary>
    /// Base class for an App
    /// </summary>
    public abstract class App
    {
        /// <summary>
        /// The Name of the App
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// When overridden it starts the App
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Instances an App with a specific Name
        /// </summary>
        /// <param name="name"></param>
        public App(string name)
        {
            Name = name;
        }
    }
}
