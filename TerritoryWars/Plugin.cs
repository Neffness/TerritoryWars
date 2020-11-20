[assembly: Rage.Attributes.Plugin("TerritoryWars", Description = "WIP", Author = "Joshua Neffness Neff")]

namespace TerritoryWars
{
    using Rage;
    using RAGENativeUI;

    public delegate void FiberDelegate_NoParams();

    public class Plugin
    {
        // String Properties
            // Plugin Name
        public const string Name = "Territory Wars";
            // Menus
        public const string MenuTitleSuffix = "Menu";
        public const string MainMenuName = "Main";
        public const string LocationDetailsMenuName = "Location Details";

        // Menu Threading
        private static MenuPool _PluginMenuPool { get; } = new MenuPool();
        public static MenuPool PluginMenuPool
        {
            get { return _PluginMenuPool; }
        }

        // Managers
            // Menu Manager
        private static Manager _MenuManager;
        public static Manager MenuManager
        {
            get { return _MenuManager; }
        }

            // Territory Manager
        private static Manager _TerritoryManager;
        public static Manager TerritoryManager
        {
            get { return _TerritoryManager; }
        }

        // Main
        public static void Main()
        {
            _TerritoryManager = new Territories.TerritoriesManager();
            _MenuManager = new Menus.MenuManager();

            while (true)
            {
                GameFiber.Yield();
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

    public class Manager : TWClass
    {
        public Manager() : base()
        {

        }
    }

    public class Factory : TWClass
    {
        public Factory() : base()
        {

        }
    }

    public class TWClass
    {
        public TWClass()
        {

        }

        public virtual void Tick()
        {
        }

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
