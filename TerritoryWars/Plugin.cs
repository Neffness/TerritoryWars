[assembly: Rage.Attributes.Plugin("TerritoryWars", Description = "WIP", Author = "Joshua Neffness Neff")]

namespace TerritoryWars
{
    using Rage;
    using RAGENativeUI;

    // Delegates
    public delegate void FiberDelegate_NoParams();

    /// <summary>
    /// class <c>Plugin</c> is the root class for the Territory Wars plugin. Conatins Main().
    /// </summary>
    public class Plugin
    {
        // Properties

        /// <summary>
        /// property <c>Name</c> is the name of the Plugin.
        /// </summary>
        public const string Name = "Territory Wars";

        /// <summary>
        /// method <c>PluginMenuPool</c> is the pool used for menu threading.
        /// </summary>
        public static MenuPool PluginMenuPool { get; } = new RAGENativeUI.MenuPool();

        /// <summary>
        /// property <c>MenuManager</c> is the private storage for a constructed MenuManager
        /// </summary>
        private static Manager MenuManager;

        /// <summary>
        /// property <c>TerritoryManager</c> is the private storage for a constructed TerritoryManager
        /// </summary>
        private static Manager TerritoryManager;

        // Methods

        /// <summary>
        /// method <c>GetMenuManager</c> returns the property MenuManager.
        /// </summary>
        /// <returns>The MenuManager property</returns>
        public static Manager GetMenuManager()
        {
            return MenuManager;
        }

        /// <summary>
        /// method <c>GetMenuManager</c> returns the property MenuManager.
        /// </summary>
        /// <returns>The MenuManager property</returns>
        public static Manager GetTerritoryManager()
        {
            return TerritoryManager;
        }

        /// <summary>
        /// method <c>InitializeTerritoriesManager</c> will construct a new territory manager then handle all its start up requirements.
        /// </summary>
        public static void InitializeTerritoriesManager()
        {
            TerritoryManager = new Territories.TerritoriesManager();
            Territories.TerritoriesManager TerritoriesManager = (Territories.TerritoriesManager)TerritoryManager;
            TerritoriesManager.CreateTerritories();
        }

        /// <summary>
        /// method <c>InitializeMenuManager</c> will construct a new menu manager then handle all its start up requirements.
        /// </summary>
        public static void InitializeMenuManager()
        {
            MenuManager = new Menus.MenuManager();
        }

        /// <summary>
        /// method <c>Main</c> is the Main method for the Territory Wars plugin.
        /// </summary>
        public static void Main()
        {
            InitializeTerritoriesManager();
            InitializeMenuManager();

            while (true)
            {
                Rage.GameFiber.Yield();
                if (MenuManager != null)
                {
                    MenuManager.Tick();
                }
                if (TerritoryManager != null)
                {
                    TerritoryManager.Tick();
                }
            }
        }
    }

    /// <summary>
    /// class <c>Manager</c> is the base class for Managers.
    /// </summary>
    public class Manager : TWClass
    {
        /// <summary>
        /// method <c>Manager</c> constructor.
        /// </summary>
        public Manager() : base()
        {

        }
    }

    /// <summary>
    /// class <c>Factory</c> is the base class for Factorys.
    /// </summary>
    public class Factory : TWClass
    {
        /// <summary>
        /// method <c>Factory</c> constructor.
        /// </summary>
        public Factory() : base()
        {

        }
    }

    /// <summary>
    /// class <c>TWClass</c> is the base class for TerritoryWars classes.
    /// </summary>
    public class TWClass
    {
        /// <summary>
        /// method <c>TWClass</c> constructor.
        /// </summary>
        public TWClass()
        {

        }

        /// <summary>
        /// method <c>Tick</c> is a virtual function for Ticking objects.
        /// </summary>
        public virtual void Tick()
        {
        }

        /// <summary>
        /// method <c>StartNewFiber</c> allows extended classes to start a fiber.
        /// </summary>
        /// <param name="Delay"></param>
        /// <param name="FiberDelegate"></param>
        /// <returns></returns>
        public GameFiber StartNewFiber(int Delay, FiberDelegate_NoParams FiberDelegate)
        {
            GameFiber NewFiber = GameFiber.StartNew(delegate
            {
                while (true)
                {
                    GameFiber.Wait(Delay);
                    FiberDelegate();
                }
            });
            return NewFiber;
        }
    }
}
