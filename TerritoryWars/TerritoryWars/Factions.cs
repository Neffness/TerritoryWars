namespace TerritoryWars.Factions
{
    using System.ComponentModel;

    public enum Factions
    {
        [Description("Police")]
        Police = 0,
        [Description("FIB")]
        FIB = 1,
        [Description("Military")]
        Military = 2,
        [Description("Armenian Mob")]
        ArmenianMob =3,
        [Description("Ballas")]
        Ballas = 4,
        [Description("Gambetti Crime Family")]
        GambettiCrimeFamily = 5,
        [Description("Hippies")]
        Hippies = 6,
        [Description("Kkangpae")]
        Kkangpae = 7,
        [Description("Los Santos Triads")]
        LosSantosTriads = 8,
        [Description("Los Santos Vagos")]
        LosSantosVagos = 9,
        [Description("Madrazo Cartel")]
        MadrazoCartel = 10,
        [Description("Marabunta Grande")]
        MarabuntaGrande = 11,
        [Description("O'Neil Brothers")]
        ONeilBrothers = 12,
        [Description("Rednecks")]
        Rednecks = 13,
        [Description("The Lost MC")]
        TheLostMC = 14,
        [Description("Varrios Los Aztecas")]
        VarriosLosAztecas = 15,
    }

    public struct FactionData
    {
        // Constructor
        public FactionData(Factions NewFaction)
        {
            Faction = NewFaction;
        }

        public Factions Faction { get; }

        public override string ToString() => $"({Faction})";
    }

    sealed class FactionsManager
    {
        // Constructor
        public FactionsManager() : base()
        {
        }

        // Singleton
        public static FactionsManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FactionsManager();
                    }
                    return instance;
                }
            }
        }

        private static FactionsManager instance = null;
        private static readonly object padlock = new object();
    }

    class FactionFactory : Factory
    {
        // Constructor
        public FactionFactory() : base()
        {

        }

        public Faction CreateFaction(FactionData NewFactionData)
        {
            Faction NewFaction = new Faction(NewFactionData);
            return NewFaction;
        }
    }

    class Faction : TWClass
    {
        // Constructor
        public Faction(FactionData FactionData) : base()
        {
            Data = FactionData;
        }

        private static FactionData Data;

        public FactionData GetData()
        {
            return Data;
        }
    }
}
