namespace TerritoryWars.Factions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using Rage;

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
        [Description("National Security Enforcement")]
        NationalSecurityEnforcement = 16,
        [Description("Sheriff")]
        Sheriff = 17,
        [Description("Forrest Rangers")]
        ForestRangers = 18,
        [Description("Penitentiary Guards")]
        PenitentiaryGuards = 19,
    }

    /// <summary>
    /// enum <c>FactionTypes</c> are used for things like allies and enemies.
    /// </summary>
    public enum FactionTypes
    {
        LawEnforcement,
        Gang,
        Mob,
        Cartel,
        Hillbilly,
        MotorCycleClub,
    }

    /// <summary>
    /// stuct <c>FactionData</c> is a container used for storing faction data.
    /// </summary>
    public struct FactionData
    {
        /// <summary>
        /// method <c>FactionData</c> constructor.
        /// </summary>
        /// <param name="NewFaction"></param>
        public FactionData(Factions NewFaction)
        {
            Faction = NewFaction;
            Territories = new List<Territories.TerritoryData>();
            Influence = 1.0f;
            AlliedFactions = new List<FactionTypes>();

            // I use this switch statement as a means to set up factions. It's ugly and I don't care right now.
            switch (Faction)
            {
                case Factions.ArmenianMob:
                    FactionType = FactionTypes.Mob;
                    TerritoryColor = Color.Yellow;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.Ballas:
                    FactionType = FactionTypes.Gang;
                    TerritoryColor = Color.Purple;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.FIB:
                    FactionType = FactionTypes.LawEnforcement;
                    AlliedFactions.Add(FactionTypes.LawEnforcement);
                    TerritoryColor = Color.Brown;
                    Influence = 3.0f;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(-429.2342f, 1109.349f, 327.682f), TerritoryColor, Influence);
                    Territories.Add(Headquarters);
                    break;
                case Factions.GambettiCrimeFamily:
                    FactionType = FactionTypes.Mob;
                    TerritoryColor = Color.Maroon;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.Hippies:
                    FactionType = FactionTypes.Hillbilly;
                    TerritoryColor = Color.Green;
                    Influence = 1.0f;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(2546.8f, 2610.598f, 37.94484f), TerritoryColor, Influence);
                    Territories.Add(Headquarters);
                    break;
                case Factions.Kkangpae:
                    FactionType = FactionTypes.Gang;
                    TerritoryColor = Color.Red;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.LosSantosTriads:
                    FactionType = FactionTypes.Gang;
                    TerritoryColor = Color.DarkRed;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.LosSantosVagos:
                    FactionType = FactionTypes.Gang;
                    TerritoryColor = Color.Orange;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.MadrazoCartel:
                    FactionType = FactionTypes.Cartel;
                    TerritoryColor = Color.PaleGreen;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.MarabuntaGrande:
                    FactionType = FactionTypes.Gang;
                    TerritoryColor = Color.Blue;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.Military:
                    FactionType = FactionTypes.LawEnforcement;
                    AlliedFactions.Add(FactionTypes.LawEnforcement);
                    TerritoryColor = Color.Olive;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.ONeilBrothers:
                    FactionType = FactionTypes.Mob;
                    TerritoryColor = Color.CadetBlue;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.Police:
                    FactionType = FactionTypes.LawEnforcement;
                    AlliedFactions.Add(FactionTypes.LawEnforcement);
                    TerritoryColor = Color.DodgerBlue;
                    Influence = 10.0f;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(451.7062f, -993.2839f, 30.6896f), TerritoryColor, Influence);
                    Territories.Add(Headquarters);
                    // Other stations
                    Territories.Add(new Territories.TerritoryData(Faction, new Vector3(649.8077f, -8.154874f, 82.40269f), TerritoryColor, Influence));
                    Territories.Add(new Territories.TerritoryData(Faction, new Vector3(-1108.172f, -844.1479f, 19.31697f), TerritoryColor, Influence));
                    Territories.Add(new Territories.TerritoryData(Faction, new Vector3(825.3053f, -1290.263f, 28.24065f), TerritoryColor, Influence));
                    Territories.Add(new Territories.TerritoryData(Faction, new Vector3(-561.687f, -130.9729f, 38.43186f), TerritoryColor, Influence));
                    break;
                case Factions.Rednecks:
                    FactionType = FactionTypes.Hillbilly;
                    TerritoryColor = Color.IndianRed;
                    Influence = 3.0f;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(1224.049f, 2728.68f, 38.00505f), TerritoryColor, Influence);
                    Territories.Add(Headquarters);
                    break;
                case Factions.TheLostMC:
                    FactionType = FactionTypes.MotorCycleClub;
                    TerritoryColor = Color.Black;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.VarriosLosAztecas:
                    FactionType = FactionTypes.Gang;
                    TerritoryColor = Color.SeaGreen;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    //Territories.Add(Headquarters);
                    break;
                case Factions.NationalSecurityEnforcement:
                    FactionType = FactionTypes.LawEnforcement;
                    AlliedFactions.Add(FactionTypes.LawEnforcement);
                    TerritoryColor = Color.SkyBlue;
                    Influence = 10.0f;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(-863.4155f, -2409.932f, 14.02572f), TerritoryColor, Influence);
                    Territories.Add(Headquarters);
                    break;
                case Factions.Sheriff:
                    FactionType = FactionTypes.LawEnforcement;
                    AlliedFactions.Add(FactionTypes.LawEnforcement);
                    TerritoryColor = Color.LimeGreen;
                    Influence = 10.0f;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(360.7052f, -1583.961f, 29.29195f), TerritoryColor, Influence);
                    Territories.Add(Headquarters);
                    // Other stations
                    Territories.Add(new Territories.TerritoryData(Faction, new Vector3(-448.1817f, 6007.835f, 31.71638f), TerritoryColor, Influence));
                    Territories.Add(new Territories.TerritoryData(Faction, new Vector3(1848.665f, 3690.305f, 34.26707f), TerritoryColor, Influence));
                    break;
                case Factions.ForestRangers:
                    FactionType = FactionTypes.LawEnforcement;
                    AlliedFactions.Add(FactionTypes.LawEnforcement);
                    TerritoryColor = Color.ForestGreen;
                    Influence = 10.0f;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(378.9325f, 792.2542f, 190.407f), TerritoryColor, Influence);
                    Territories.Add(Headquarters);
                    break;
                case Factions.PenitentiaryGuards:
                    FactionType = FactionTypes.LawEnforcement;
                    AlliedFactions.Add(FactionTypes.LawEnforcement);
                    TerritoryColor = Color.RosyBrown;
                    Influence = 10.0f;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(1845.719f, 2586.033f, 45.67205f), TerritoryColor, Influence);
                    Territories.Add(Headquarters);
                    break; 
                default:
                    FactionType = FactionTypes.Hillbilly;
                    TerritoryColor = Color.White;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    break;
            }
        }

        // Properties

        /// <summary>
        /// property <c>Faction</c> stores the Faction enum type
        /// </summary>
        public Factions Faction { get; }
        
        /// <summary>
        /// property <c>Territories</c> is a list that holds all the territories owned by this faction.
        /// </summary>
        public List<Territories.TerritoryData> Territories;

        /// <summary>
        /// property <c>TerritoryColor</c> is the color to be used when creating territories.
        /// </summary>
        public Color TerritoryColor { get; }

        /// <summary>
        /// property <c>Headquarters</c> stores a territory data object for the main base of the faction.
        /// </summary>
        public Territories.TerritoryData Headquarters;

        /// <summary>
        /// property <c>Influence</c> is used to determine the strength of a faction. Used in things like creating territories.
        /// </summary>
        public float Influence { get; }

        /// <summary>
        /// property <c>FactionType</c> is used to distinquish a type for things like allies and enemies.
        /// </summary>
        public FactionTypes FactionType { get; }

        /// <summary>
        /// property <c>AlliedFactions</c> is a list that contains the factions this faction is allined with.
        ///     Anyone not allied is an enemy.
        /// </summary>
        public List<FactionTypes> AlliedFactions { get; }

        // Methods

        /// <summary>
        /// method <c>ToString</c> returns a stringified version of the struct data.
        /// </summary>
        /// <returns>a stringified version of the struct data.</returns>
        public override string ToString() => $"({Faction}, {Territories})";
    }

    /// <summary>
    /// class <c>FactionsManager</c> is a singleton class used for managing the active factions for the plugin.
    /// </summary>
    sealed class FactionsManager : Manager
    {
        /// <summary>
        /// method <c>FactionsManager</c> constructor.
        /// </summary>
        public FactionsManager() : base()
        {
            InitializeFactionsContainer();
            FactionsFactory = new FactionsFactory();
            StartNewFiber(100, Tick);
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

        // Properties

        /// <summary>
        /// property <c>Factions</c> is a dictionary that contains all the current loaded factions.
        /// </summary>
        private IDictionary<Factions, Faction> ActiveFactions;

        /// <summary>
        /// property <c>FactionsFactory</c> is the container for the managers contructed Factions Factory.
        /// </summary>
        private static FactionsFactory FactionsFactory;

        // Methods

        /// <summary>
        /// method <c>InitializeFactionsContainer</c> initializes the ActiveFactions dictionary as an empty dictionary.
        /// </summary>
        public void InitializeFactionsContainer()
        {
            ActiveFactions = new Dictionary<Factions, Faction>();
        }

        /// <summary>
        /// method <c>CreateFactions</c>  calls to the factory to create the factions. Then iterates them and adds them to the factions dictionary.
        /// </summary>
        public void CreateFactions()
        {
            List<FactionData> FactionsData = FactionsFactory.CreateFactions();
            for (int i = 0; i < FactionsData.Count; i++)
            {
                Faction NewFaction = new Faction(FactionsData[i]);
                for (var ii = 0; ii < FactionsData[i].Territories.Count; ii++)
                {
                    NewFaction.ClaimTerritory(FactionsData[i].Territories[ii].Location);
                }
                ActiveFactions.Add(FactionsData[i].Faction, NewFaction);
            }
        }
    }

    /// <summary>
    /// class <c>FactionFactory</c> is used for creating factions.
    /// </summary>
    class FactionsFactory : Factory
    {
        /// <summary>
        /// method <c>FactionFactory</c> constructor.
        /// </summary>
        public FactionsFactory() : base()
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

        /// <summary>
        /// method <c>CreateFactions</c> will create all the factions listed in the Factions enum.
        /// </summary>
        /// <returns></returns>
        public List<FactionData> CreateFactions()
        {
            List<FactionData> Factions = new List<FactionData>();
            foreach (Factions Faction in Enum.GetValues(typeof(Factions)))
            {
                Factions.Add(new FactionData(Faction));
            }
            return Factions;
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

        /// <summary>
        /// proeprty <c>Influence</c> is used as a measure of the factions strength.
        /// </summary>
        private float Influence;

        // Methods

        /// <summary>
        /// method <c>GetData</c> returns the faction data for the faction object.
        /// </summary>
        /// <returns>Faction data for the faction object.</returns>
        public FactionData GetData()
        {
            return Data;
        }

        /// <summary>
        /// method <c>GetInfluence</c> returns the faction's influence.
        /// </summary>
        /// <returns>The faction's influence.</returns>
        public float GetInfluence()
        {
            return Influence;
        }

        /// <summary>
        /// method <c>ClaimTerritory</c> will claim territory for a faction, creating the territories in game.
        /// </summary>
        /// <param name="ClaimedLocation"></param>
        public void ClaimTerritory(Vector3 ClaimedLocation)
        {
            ((Territories.TerritoriesManager)Plugin.GetTerritoryManager()).ClaimTerritoryForFaction(ClaimedLocation, Data);
        }
    }
}
