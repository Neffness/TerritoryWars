namespace TerritoryWars.Factions
{
    using System.ComponentModel;

    /// <summary>
    /// enum <c>Factions</c> contains all the usable factions for the plugin.
    /// </summary>
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

    /// <summary>
    /// stuct <c>FactionData</c> is a container used for storing faction data.
    /// </summary>
    public struct FactionData
    {
        /// <summary>
        /// method <c>Factiondata</c> constructor.
        /// </summary>
        /// <param name="NewFaction"></param>
        public FactionData(Factions NewFaction)
        {
            Faction = NewFaction;
        }

        // Properties

        /// <summary>
        /// property <c>Faction</c> stores the faction type
        /// </summary>
        public Factions Faction { get; }

        // Methods

        /// <summary>
        /// method <c>ToString</c> returns a stringified version of the struct data.
        /// </summary>
        /// <returns>a stringified version of the struct data.</returns>
        public override string ToString() => $"({Faction})";
    }

    /// <summary>
    /// class <c>FactionsManager</c> is a singleton class used for managing the active factions for the plugin.
    /// </summary>
    sealed class FactionsManager
    {
        /// <summary>
        /// method <c>FactionsManager</c> constructor.
        /// </summary>
        public FactionsManager() : base()
        {
        }

        // --> Singleton
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
        // <-- Singleton
    }

    /// <summary>
    /// class <c>FactionFactory</c> is used for creating factions.
    /// </summary>
    class FactionFactory : Factory
    {
        /// <summary>
        /// method <c>FactionFactory</c> constructor.
        /// </summary>
        public FactionFactory() : base()
        {

        }

        // Methods

        /// <summary>
        /// method <c>CreateFaction</c> creates a new faction object.
        /// </summary>
        /// <param name="NewFactionData"></param>
        /// <returns>A new faction object</returns>
        public Faction CreateFaction(FactionData NewFactionData)
        {
            Faction NewFaction = new Faction(NewFactionData);
            return NewFaction;
        }
    }

    /// <summary>
    /// class <c>Faction</c> is the base class for a faction.
    /// </summary>
    class Faction : TWClass
    {
        /// <summary>
        /// method <c>Faction</c> constructor.
        /// </summary>
        /// <param name="FactionData"></param>
        public Faction(FactionData FactionData) : base()
        {
            Data = FactionData;
        }

        // Properties

        /// <summary>
        /// property <c>Data</c> stores the faction data for the faction object.
        /// </summary>
        private static FactionData Data;

        // Methods

        /// <summary>
        /// method <c>GetData</c> returns the faction data for the faction object.
        /// </summary>
        /// <returns>Faction data for the faction object.</returns>
        public FactionData GetData()
        {
            return Data;
        }
    }
}
