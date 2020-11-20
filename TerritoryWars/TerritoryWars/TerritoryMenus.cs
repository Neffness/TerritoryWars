namespace TerritoryWars.Menus
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Rage;
    using RAGENativeUI;
    using RAGENativeUI.Elements;

    // Delegates
    public delegate void Delegate_NoParams();
    public delegate void Delegate_OneStrParam(string String);

    /// <summary>
    /// class <c>MenuManager</c> singleton class to manage Territory Wars menus.
    /// </summary>
    sealed class MenuManager : Manager
    {
        /// <summary>
        /// method <c>MenuManager</c> constructor.
        /// </summary>
        public MenuManager() : base()
        {
            MenuFactory = new Menus.MenuFactory();
            MenuFactory.CreateMenus();
            MainMenu = (Menus.TerritoryWarsMainMenu)Menus[MenuFactory.MainMenuName];
        }

        // --> Singleton
        public static MenuManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MenuManager();
                    }
                    return instance;
                }
            }
        }
        private static MenuManager instance = null;
        private static readonly object padlock = new object();
        // <-- Singleton

        // Properties

        /// <summary>
        /// property <c>MenuFactor</c> stores the constructed menu factory.
        /// </summary>
        private static MenuFactory MenuFactory;

        /// <summary>
        /// property <c>Menus</c> stores the created menus
        /// </summary>
        public static Dictionary<string, UIMenu> Menus = new Dictionary<string, UIMenu>();

        /// <summary>
        /// property <c>MainMenu</c> stores the constructed Main Menu for Territory Wars.
        /// </summary>
        public Menus.TerritoryWarsMainMenu MainMenu;

        // Methods

        /// <summary>
        /// override method <c>Tick</c>.
        /// </summary>
        public override void Tick()
        {
            base.Tick();
            CheckKeyBinds();
            Plugin.PluginMenuPool.ProcessMenus();
        }

        /// <summary>
        /// method <c>CheckKeyBinds</c> checks for key presses.
        /// </summary>
        private void CheckKeyBinds()
        {
            if (Game.IsKeyDown(Keys.F7))
            {
                if (MainMenu != null)
                {
                    if (MainMenu.Visible)
                    {
                        MainMenu.Visible = false;
                    }
                    else
                    {
                        MainMenu.Visible = true;
                    }
                }
            }
        }
    }

    /// <summary>
    /// class <c>MenuFactor</c> extends Factory. Creates menus.
    /// </summary>
    class MenuFactory : Factory
    {
        /// <summary>
        ///  method <c>MenuFactor</c> constuctor.
        /// </summary>
        public MenuFactory() : base()
        {
        }

        // Properties

        /// <summary>
        /// property <c>MainMenuName</c> stores a string for menu creation.
        /// </summary>
        public readonly string MainMenuName = "Main";

        // Methods

        /// <summary>
        /// method <c>CreateMenus</c> is a place to create standalone menus.
        /// </summary>
        public void CreateMenus()
        {
            MenuManager.Menus.Add(MainMenuName, new Menus.TerritoryWarsMainMenu());
        }
    }

    /// <summary>
    /// class <c>TerritoryWarsMainMenu</c> is the main menu for the Territory Wars plugin
    /// </summary>
    class TerritoryWarsMainMenu : BaseMenu
    {
        /// <summary>
        /// method <c>TerritoryWarsMainMenu</c> constructor.
        /// </summary>
        public TerritoryWarsMainMenu() : base(SubMenuTitle("Main"))
        {
            Territories.TerritoriesManager TerritoryManager = (Territories.TerritoriesManager)Plugin.GetTerritoryManager();
            NewChoice(ShowBlipsName, null, TerritoryManager.ShowAllTerritoryBlips);
            NewChoice(ClearBlipsName, null, TerritoryManager.RemoveAllTerritoryBlips);
            NewChoice(TerritoriesName, TerritoryMenu, TerritoryMenu.LoadTerritories);
        }

        // Properties

        /// <summary>
        /// property <c>ShowBlipNames</c> is a button text property.
        /// </summary>
        public const string ShowBlipsName = "Show Territory Blips";

        /// <summary>
        /// property <c>ClearBlipsName</c> is a button text property.
        /// </summary>
        public const string ClearBlipsName = "Clear Territory Blips";

        /// <summary>
        /// property <c>TerritoriesName</c> is a button text property.
        /// </summary>
        public const string TerritoriesName = "Territories";

        /// <summary>
        /// property <c>TerritoryMenu</c> is a menu for button binding.
        /// </summary>
        private Menus.TerritoriesMenu TerritoryMenu = new Menus.TerritoriesMenu();

    }

    /// <summary>
    /// class <c>TerritoriesMenu</c> is a Main Menu menu
    /// </summary>
    class TerritoriesMenu : BaseMenu
    {
        /// <summary>
        /// method <c>TerritoriesMenu</c> constructor.
        /// </summary>
        public TerritoriesMenu() : base(SubMenuTitle("Territories"))
        {
        }

        // Methods

        /// <summary>
        /// method <c>LoadTerritories</c> can be called to load all created territories to the menu for selection. Clears previous selections.
        /// </summary>
        /// <param name="EventText"></param>
        public void LoadTerritories(string EventText)
        {
            if (string.IsNullOrEmpty(EventText))
            {
                throw new System.ArgumentException("message", nameof(EventText));
            }

            Clear();
            Territories.TerritoriesManager TerritoryManager = (Territories.TerritoriesManager)Plugin.GetTerritoryManager();
            foreach(DictionaryEntry Enumerator in TerritoryManager.Territories)
            {
                string Name = (string)Enumerator.Key;
                UIMenuItem Choice = NewChoice(Name, null, TerritoryManager.BlipTerritory);
            }
        }
    }

    /// <summary>
    /// class <c>BaseMenu</c> is the base menu class for the Territory Wars plugin and extends the UIMenu.
    /// </summary>
    class BaseMenu : UIMenu
    {
        /// <summary>
        /// method <c>BaseMenu</c> constructor.
        /// </summary>
        /// <param name="title"></param>
        public BaseMenu(string title) : base(Plugin.Name, title)
        {
            Plugin.PluginMenuPool.Add(this);
        }

        // Methods

        /// <summary>
        /// method <c>SubMenuTitle</c> formats a string used in menu titles.
        /// </summary>
        /// <param name="title"></param>
        /// <returns>A formated string used in menu titles</returns>
        public static string SubMenuTitle(string title) => $"{"Menu"}: {title}";

        /// <summary>
        /// method <c>NewChoice</c> creates a standardized menu button for menus.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="MenuContext"></param>
        /// <param name="OnActivated"></param>
        /// <returns>A new menu button</returns>
        public UIMenuItem NewChoice(string Text, UIMenu MenuContext = null, Delegate_OneStrParam OnActivated = null)
        {
            if (string.IsNullOrEmpty(Text))
            {
                throw new System.ArgumentException("message", nameof(Text));
            }

            var NewItem = new UIMenuItem(Text);
            AddItem(NewItem);
            if (MenuContext != null)
            {
                BindMenuToItem(MenuContext, NewItem);
            }
            if (OnActivated != null)
            {
                NewItem.Activated += (menu, item) =>
                {
                    OnActivated(item.Text);
                };
            }
            return NewItem;
        }
    }
}
