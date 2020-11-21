namespace TerritoryWars.States
{
    /// <summary>
    /// class <c>TerritoryWar</c> extends GameState and controls the territory war.
    /// </summary>
    class TerritoryWar : GameState
    {
        /// <summary>
        /// method <c>TerritoryWar</c> constructor.
        /// </summary>
        public TerritoryWar() : base()
        {

        }

        // --> Singleton
        public static GameState Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameState();
                    }
                    return instance;
                }
            }
        }

        private static GameState instance = null;
        private static readonly object padlock = new object();
        // <-- Singleton

        // Methods

        /// <summary>
        /// property <c>InitializeGame</c> overrides base class function.
        /// </summary>
        public override void InitializeGame()
        {
            base.InitializeGame();
            InitializeFactionsManager();
        }

        /// <summary>
        /// method <c>InitializeFactionsManager</c> initializes the plugins FactionsManager.
        /// </summary>
        private void InitializeFactionsManager()
        {
            ((Factions.FactionsManager)Plugin.GetFactionsManager()).CreateFactions();
        }

    }
}
