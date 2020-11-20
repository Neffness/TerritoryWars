namespace TerritoryWars.ConsoleCommands
{
    using Rage;
    public static class ConsoleCommands
    {
        [Rage.Attributes.ConsoleCommand]
        public static void Command_Location()
        {
            Vector3 PlayerPosition = Game.LocalPlayer.Character.Position;
            Game.DisplayNotification(PlayerPosition.ToString());
        }

        [Rage.Attributes.ConsoleCommand]
        public static void Command_ClearAllTerritories()
        {
            Manager PluginTerritoryManager = Plugin.TerritoryManager;
            Territories.TerritoriesManager TerritoryManager = (Territories.TerritoriesManager)PluginTerritoryManager;
            TerritoryManager.DestroyTerritories();
        }

        [Rage.Attributes.ConsoleCommand]
        public static void Command_ShowMenu()
        {
            Manager PluginManager = Plugin.MenuManager;
            Menus.MenuManager MenuManager = (Menus.MenuManager)PluginManager;
            MenuManager.MainMenu.Visible = true;
        }
    }
}
