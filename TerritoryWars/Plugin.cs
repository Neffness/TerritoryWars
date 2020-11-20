[assembly: Rage.Attributes.Plugin("TerritoryWars", Description = "WIP", Author = "Joshua Neffness Neff")]

namespace TerritoryWars
{
    public delegate void FiberDelegate_NoParams();

    public class Plugin
    {
        // Plugin Name
        public const string Name = "Territory Wars";

        // Menu Threading
        private static RAGENativeUI.MenuPool _PluginMenuPool { get; } = new RAGENativeUI.MenuPool();
        public static RAGENativeUI.MenuPool PluginMenuPool
        {
            get { return _PluginMenuPool; }
        }

        private static Manager _MenuManager;
        public static Manager MenuManager
        {
            get { return _MenuManager; }
        }

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

        public Rage.GameFiber StartNewFiber(int Delay, FiberDelegate_NoParams FiberDelegate)
        {
            Rage.GameFiber NewFiber = Rage.GameFiber.StartNew(delegate
            {
                while (true)
                {
                    Rage.GameFiber.Wait(Delay);
                    FiberDelegate();
                }
            });
            return NewFiber;
        }
    }
}
