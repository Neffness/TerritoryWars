﻿namespace TerritoryWars.Territories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using Rage;

    /// <summary>
    /// struct <c>TerritoryData</c> used for containing territory data.
    /// </summary>
    public struct TerritoryData
    {
        /// <summary>
        /// method <c>TerritoryData</c> constructory.
        /// </summary>
        /// <param name="FactionOwner"></param>
        /// <param name="TerritoryLocation"></param>
        /// <param name="TerritoryColor"></param>
        /// <param name="Influence"></param>
        public TerritoryData(Factions.Factions FactionOwner, Vector3 TerritoryLocation, Color TerritoryColor, float Influence = 1.0f)
        {
            Faction = FactionOwner;
            Location = TerritoryLocation;
            Color = TerritoryColor;
            InitialInfluence = Influence;
        }

        // Properties

        /// <summary>
        /// property <c>Name</c> is used to store the name of a territory.
        /// </summary>
        public Factions.Factions Faction { get; }

        /// <summary>
        /// property <c>Location</c> is used to store the world vector3 location of a territory.
        /// </summary>
        public Vector3 Location { get; }

        /// <summary>
        /// property <c>Color</c> is used to store the Rage.Color of a territory.
        /// </summary>
        public Color Color { get; }

        /// <summary>
        /// property <c_>InitialInfluence</c_> is the float that will be used when creating a territory for the first time.
        /// </summary>
        public float InitialInfluence { get; }

        // Methods

        /// <summary>
        /// method <c>ToString</c> is used to generate a string repersentation of the struct.
        /// </summary>
        /// <returns>string repersentation of the struct</returns>
        public override string ToString() => $"({Faction}, {Location}, {Color})";
    }

    /// <summary>
    /// class <c>TerritoriesManager</c> is the singleton manager for territories for the plugin.
    /// </summary>
    sealed class TerritoriesManager : Manager
    {
        /// <summary>
        /// method <c>TerritoriesManager</c> constructor.
        /// </summary>
        public TerritoriesManager() : base()
        {
            InitializeTerritoriesContainer();
            TerritoriesFactory = new TerritoryFactory();
            StartNewFiber(100, Tick);
        }

        // --> Singleton
        public static TerritoriesManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TerritoriesManager();
                    }
                    return instance;
                }
            }
        }

        private static TerritoriesManager instance = null;
        private static readonly object padlock = new object();
        // <-- Singleton

        // Properties

        /// <summary>
        /// property <c>Territories</c> is the managers container for created Territories.
        /// </summary>
        public IDictionary Territories;

        /// <summary>
        /// property <c>TerritoriesFactory</c> is the container for the managers contructed Territory Factory.
        /// </summary>
        private static TerritoryFactory TerritoriesFactory;

        // Methods

        /// <summary>
        /// method <c>GetTerritoriesFactory</c> returns the managers Territory Factory.
        /// </summary>
        /// <returns>The managers Territory Factory</returns>
        public TerritoryFactory GetTerritoriesFactory()
        {
            return TerritoriesFactory;
        }

        /// <summary>
        /// method <c>InitializeTerritoriesContainer</c> initializes the Territories dictionary as an empty dictionary.
        /// </summary>
        private void InitializeTerritoriesContainer()
        {
            Territories = new Dictionary<string, List<Territory>>();
        }

        /// <summary>
        /// method <c>DestroyTerritories</c> will destroy all the current territory objects by re-initializing their container.
        /// </summary>
        public void DestroyTerritories()
        {
            InitializeTerritoriesContainer();
        }

        /// <summary>
        /// method <c>Tick</c> overrides the base tick method.
        /// </summary>
        public override void Tick()
        {
            base.Tick();
        }

        /// <summary>
        /// method <c>ToggleTerritoryBlip</c> will toggle the blip for a specific territory.
        /// </summary>
        /// <param name="TerritoryName"></param>
        public void ToggleTerritoryBlip(string TerritoryName)
        {
            if (string.IsNullOrEmpty(TerritoryName))
            {
                throw new System.ArgumentException("message", nameof(TerritoryName));
            }

            foreach (DictionaryEntry Enumerator in Territories)
            {
                string Name = (string)Enumerator.Key;
                if (Name == TerritoryName)
                {
                    List<Territory> TerritoryObjs = (List<Territory>)Enumerator.Value;
                    for (var i = 0; i < TerritoryObjs.Count; i++)
                    {
                        TerritoryObjs[i].ToggleBlip();
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// method <c>BlipTerritory</c> will place a blip on a territory. Removes any existing blips, and creates a new one based on current info.
        /// </summary>
        /// <param name="TerritoryName"></param>
        public void BlipTerritory(string TerritoryName)
        {
            if (string.IsNullOrEmpty(TerritoryName))
            {
                throw new System.ArgumentException("message", nameof(TerritoryName));
            }

            foreach (DictionaryEntry Enumerator in Territories)
            {
                if ((string)Enumerator.Key == TerritoryName)
                {
                    List<Territory> TerritoryObjs = (List<Territory>)Enumerator.Value;
                    foreach (Territory T in TerritoryObjs)
                    {
                        T.DeactivateBlip();
                        T.ActivateBlip();
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// method <c>RemoveTerritoryBlip</c> removes a blip for a specific territory.
        /// </summary>
        /// <param name="TerritoryName"></param>
        public void RemoveTerritoryBlip(string TerritoryName)
        {
            if (string.IsNullOrEmpty(TerritoryName))
            {
                throw new System.ArgumentException("message", nameof(TerritoryName));
            }

            foreach (DictionaryEntry Enumerator in Territories)
            {
                if ((string)Enumerator.Key == TerritoryName)
                {
                    List<Territory> TerritoryObjs = (List<Territory>)Enumerator.Value;
                    foreach (Territory T in TerritoryObjs)
                    {
                        T.DeactivateBlip();
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// method <c>ShowAllTerritoryBlips</c> will show all the territory blips.
        /// </summary>
        /// <param name="EventText"></param>
        public void ShowAllTerritoryBlips(string EventText)
        {
            foreach (DictionaryEntry Enumerator in Territories)
            {
                List<Territory> TerritoryObjs = (List<Territory>)Enumerator.Value;
                foreach (Territory T in TerritoryObjs)
                {
                    T.ActivateBlip();
                }
            }
        }

        /// <summary>
        /// method <c>RemoveAllTerritoryBlips</c> will remove all territory blips.
        /// </summary>
        /// <param name="EventText"></param>
        public void RemoveAllTerritoryBlips(string EventText)
        {
            foreach (DictionaryEntry Enumerator in Territories)
            {
                List<Territory> TerritoryObjs = (List<Territory>)Enumerator.Value;
                foreach (Territory T in TerritoryObjs)
                {
                    T.DeactivateBlip();
                }
            }
        }

        /// <summary>
        /// method <c>CreateFactionTerritory</c> is used by ClaimTerritoryForFaction so that the actual teritory can be created.
        /// </summary>
        /// <param name="FactionName"></param>
        /// <param name="NewTerritoryData"></param>
        private void CreateFactionTerritory(string FactionName, TerritoryData NewTerritoryData)
        {
            Territory NewTerritory = GetTerritoriesFactory().CreateTerritory(NewTerritoryData);
            if (!Territories.Contains(FactionName))
            {
                List<Territory> NewTerritories = new List<Territory>();
                NewTerritories.Add(NewTerritory);
                Territories.Add(FactionName, NewTerritories);
            }
            else
            {
                ((List<Territory>)Territories[FactionName]).Add(NewTerritory);
            }
        }

        /// <summary>
        /// method <c>ClaimTerritoryForFaction</c> claims territory for a faction. This is how a territory gets added to the territory manager.
        ///     First it looks up all territories owned by the faction. If the locations match exactly, the TerritoryData reference from the FactionData is used.
        ///     If no such location is found, the territory will be created for the faction at the location.
        ///     WIP - The idea for the dynamic creation of non owned territories is so the game state can allow for the creation of territories.
        ///         This feature is a wip and commented out.
        /// </summary>
        /// <param name="ClaimedLocation"></param>
        /// <param name="ClaimingFactionData"></param>
        public void ClaimTerritoryForFaction(Vector3 ClaimedLocation, Factions.FactionData ClaimingFactionData)
        {
            string FactionName = ClaimingFactionData.Faction.ToString();
            List<TerritoryData> FactionTerritories = ClaimingFactionData.Territories;
            for (var i = 0; i < FactionTerritories.Count; i++)
            {
                TerritoryData FactionsTerritoryData = FactionTerritories[i];
                if (FactionsTerritoryData.Location == ClaimedLocation)
                {
                    CreateFactionTerritory(FactionName, FactionsTerritoryData);
                    return;
                }
            }
            //CreateFactionTerritory(FactionName, new TerritoryData(ClaimingFactionData.Faction, ClaimedLocation, ClaimingFactionData.TerritoryColor));
        }
    }

    /// <summary>
    /// class <c>TerritoryFactory</c> is used for creating territory objects.
    /// </summary>
    class TerritoryFactory : Factory
    {
        /// <summary>
        /// method <c>TerritoryFactory</c> constructor.
        /// </summary>
        public TerritoryFactory() : base()
        {

        }

        // Properties

        /// <summary>
        /// property <c>TerritoriesToCreate</c> is a list used to store the territories to create by the factory.
        /// </summary>
        public List<TerritoryData> TerritoriesToCreate = new List<TerritoryData>();

        // Methods
        
        /// <summary>
        /// method <c>CreateTerritory</c> creates a territory object.
        /// </summary>
        /// <param name="NewTerritoryData"></param>
        /// <returns>A territory object</returns>
        public Territory CreateTerritory(TerritoryData NewTerritoryData)
        {
            Territory NewTerritory = new Territory(NewTerritoryData);
            NewTerritory.IncreaseInfluence(NewTerritoryData.InitialInfluence);
            return NewTerritory;
        }
    }

    /// <summary>
    /// class <c>Territory</c> is the base class for a territory object.
    /// </summary>
    class Territory : TWClass
    {
        /// <summary>
        /// method <c>Territory</c> constructor.
        /// </summary>
        /// <param name="NewTerritoryData"></param>
        public Territory(TerritoryData NewTerritoryData) : base()
        {
            Data = NewTerritoryData;
            StartNewFiber(1000, Tick);
        }

        // Properties

        /// <summary>
        /// property <c>Data</c> stores the TerritoryData for the territory object.
        /// </summary>
        public TerritoryData Data;

        /// <summary>
        /// property <c>Influence</c> is the current influnce of the territory. This is a value used to determine the strength of the territory over the area of the world it covers.
        /// </summary>
        private float Influence = 0.0f; // 1.0f is roughly the size of a city block.

        /// <summary>
        /// method <c>ActiveBlip</c> holds a reference to the territory blip, should it have one.
        /// </summary>
        private Blip ActiveBlip;

        // Methods

        /// <summary>
        /// method <c>IncreaseInfluence</c> will increase the influence of the territory. Requiers a postive number. Protects against negative influence.
        /// </summary>
        /// <param name="byAmount"></param>
        public void IncreaseInfluence(float byAmount)
        {
            if (byAmount > 0.0f)
            {
                float Potential = Influence + byAmount;
                if (Potential > 0.0f)
                {
                    Influence = Potential;
                }
            }
        }

        /// <summary>
        /// method <c>DecreaseInfluence</c> will decrease the influence of the territory. Requiers a postive number. Protects against negative influence.
        /// </summary>
        /// <param name="byAmount"></param>
        public void DecreaseInfluence(float byAmount)
        {
            if (byAmount > 0.0f)
            {
                float Potential = Influence - byAmount;
                if (Potential >= 0.0f)
                {
                    Influence = Potential;
                }
                else
                {
                    Influence = 0.0f;
                }
            }
        }

        /// <summary>
        /// method <c>GetInfluence</c> will return the current influence for the territory
        /// </summary>
        /// <returns>The current territory influence</returns>
        public float GetInfluence()
        {
            return Influence;
        }

        /// <summary>
        /// method <c>ActivateBlip</c> will activate a map blip for this territory. This gives the player a visual repersentation of the territory and its influence.
        /// </summary>
        public void ActivateBlip()
        {
            if (ActiveBlip != null)
            {
                if (ActiveBlip.IsValid())
                {
                    ActiveBlip.Delete();
                }
            }
            Blip NewBlip = new Blip(Data.Location);
            NewBlip.Name = Data.Faction.ToString() + " Territory";
            NewBlip.Order = 0;
            NewBlip.Color = Data.Color;
            NewBlip.Scale = GetInfluence();
            NewBlip.Alpha = 0.2f;
            ActiveBlip = NewBlip;
        }

        /// <summary>
        /// method <c>DeactivateBlip</c> will deactivate the active blip for the territory object.
        /// </summary>
        public void DeactivateBlip()
        {
            if (ActiveBlip != null)
            {
                if (ActiveBlip.IsValid())
                {
                    ActiveBlip.Delete();
                }
                ActiveBlip = null;
            }
        }

        /// <summary>
        /// method <c>ToggleBlip</c> will toggle the territory blip on or off.
        /// </summary>
        public void ToggleBlip()
        {
            if (ActiveBlip != null)
            {
                DeactivateBlip();
            }
            else
            {
                ActivateBlip();
            }
        }

        /// <summary>
        /// method <c>Tick</c> overrides base tick method.
        /// </summary>
        public override void Tick()
        {
            base.Tick();

        }
    }
}
