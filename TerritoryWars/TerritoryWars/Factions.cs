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
            Territories = new List<Territories.TerritoryData>();

            // I use this switch statement as a means to set up factions. It's ugly and I don't care right now.
            switch (Faction)
            {
                case Factions.ArmenianMob:
                    TerritoryColor = Color.Yellow;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.Ballas:
                    TerritoryColor = Color.Purple;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.FIB:
                    TerritoryColor = Color.Brown;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.GambettiCrimeFamily:
                    TerritoryColor = Color.Maroon;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.Hippies:
                    TerritoryColor = Color.Green;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.Kkangpae:
                    TerritoryColor = Color.Red;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.LosSantosTriads:
                    TerritoryColor = Color.DarkRed;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.LosSantosVagos:
                    TerritoryColor = Color.Orange;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.MadrazoCartel:
                    TerritoryColor = Color.ForestGreen;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.MarabuntaGrande:
                    TerritoryColor = Color.Blue;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.Military:
                    TerritoryColor = Color.Olive;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.ONeilBrothers:
                    TerritoryColor = Color.CadetBlue;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.Police:
                    TerritoryColor = Color.DodgerBlue;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(451.7062f, -993.2839f, 30.6896f), TerritoryColor);
                    Territories.Add(Headquarters);
                    // Other stations
                    Territories.Add(new Territories.TerritoryData(Faction, new Vector3(649.8077f, -8.154874f, 82.40269f), TerritoryColor));
                    break;
                case Factions.Rednecks:
                    TerritoryColor = Color.IndianRed;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.TheLostMC:
                    TerritoryColor = Color.Black;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                case Factions.VarriosLosAztecas:
                    TerritoryColor = Color.SeaGreen;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    Territories.Add(Headquarters);
                    break;
                default:
                    TerritoryColor = Color.White;
                    Headquarters = new Territories.TerritoryData(Faction, new Vector3(), TerritoryColor);
                    break;
            }
        }

        // Properties

        /// <summary>
        /// property <c>Faction</c> stores the faction type
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
