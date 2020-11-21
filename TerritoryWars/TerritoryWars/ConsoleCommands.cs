namespace TerritoryWars.ConsoleCommands
{
    using Rage;
    public static class ConsoleCommands
    {
        [Rage.Attributes.ConsoleCommand]
        public static void Command_Location()
        {
            Vector3 PlayerPosition = Game.LocalPlayer.Character.Position;
            string Location = PlayerPosition.ToString();
            Game.DisplayNotification(Location);
            Game.LogTrivial(Location);
        }

        [Rage.Attributes.ConsoleCommand]
        public static void Command_ClearAllTerritories()
        {
            Territories.TerritoriesManager TerritoryManager = (Territories.TerritoriesManager)Plugin.GetTerritoryManager();
            TerritoryManager.DestroyTerritories();
        }

        [Rage.Attributes.ConsoleCommand]
        public static void Command_ShowMenu()
        {
            Menus.MenuManager MenuManager = (Menus.MenuManager)Plugin.GetMenuManager();
            MenuManager.MainMenu.Visible = true;
        }
    }
}
