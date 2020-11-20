namespace TerritoryWars.Menus
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Rage;
    using RAGENativeUI;
    using RAGENativeUI.Elements;

    public delegate void Delegate_NoParams();
    public delegate void Delegate_OneStrParam(string String);

    sealed class MenuManager : Manager
    {
        private static MenuManager instance = null;
        private static readonly object padlock = new object();

        private static MenuFactory MenuFactory;

        public Menus.TerritoryWarsMainMenu MainMenu;

        public MenuManager() : base()
        {
            MenuFactory = new Menus.MenuFactory();
            MainMenu = (Menus.TerritoryWarsMainMenu)MenuFactory.Menus["Main"];
        }

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

        // Tick
        public override void Tick()
        {
            base.Tick();
            CheckKeyBinds();
            Plugin.PluginMenuPool.ProcessMenus();
        }

        private void CheckKeyBinds()
        {
            if (Game.IsKeyDown(Keys.F5))
            {
                if (MainMenu != null)
                {
                    MainMenu.Visible = true;
                }
            }
        }
    }

    class MenuFactory : Factory
    {
        public static Dictionary<string, UIMenu> Menus = new Dictionary<string, UIMenu>();

        private static Menus.TerritoryWarsMainMenu MainMenu = new Menus.TerritoryWarsMainMenu();

        public MenuFactory() : base()
        {
            CreateMenus();
        }

        public void CreateMenus()
        {
            Menus.Add("Main", MainMenu);
        }
    }

    class TerritoryWarsMainMenu : BaseMenu
    {
        public const string ShowBlipsName = "Show Territory Blips";
        public const string ClearBlipsName = "Clear Territory Blips";
        public const string TerritoriesName = "Territories";

        private Menus.TerritoriesMenu TerritoryMenu = new Menus.TerritoriesMenu();

        public TerritoryWarsMainMenu() : base(SubMenuTitle("Main"))
        {
            Manager PluginTerritoryManager = Plugin.TerritoryManager;
            Territories.TerritoriesManager TerritoryManager = (Territories.TerritoriesManager)PluginTerritoryManager;
            NewChoice(ShowBlipsName, null, TerritoryManager.ShowAllTerritoryBlips);
            NewChoice(ClearBlipsName, null, TerritoryManager.RemoveAllTerritoryBlips);
            NewChoice(TerritoriesName, TerritoryMenu, TerritoryMenu.LoadTerritories);
        }
    }

    class TerritoriesMenu : BaseMenu
    {
        public TerritoriesMenu() : base(SubMenuTitle("Territories"))
        {
        }

        public void LoadTerritories(string EventText)
        {
            if (string.IsNullOrEmpty(EventText))
            {
                throw new System.ArgumentException("message", nameof(EventText));
            }

            Clear();
            Manager PluginManager = Plugin.TerritoryManager;
            Territories.TerritoriesManager TerritoryManager = (Territories.TerritoriesManager)PluginManager;
            foreach(DictionaryEntry Enumerator in TerritoryManager.Territories)
            {
                string Name = (string)Enumerator.Key;
                UIMenuItem Choice = NewChoice(Name, null, TerritoryManager.BlipTerritory);
            }
        }
    }

    class BaseMenu : UIMenu
    {
        public static string SubMenuTitle(string title) => $"{"Menu"}: {title}";

        public BaseMenu(string title) : base(Plugin.Name, title)
        {
            Plugin.PluginMenuPool.Add(this);
        }

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
