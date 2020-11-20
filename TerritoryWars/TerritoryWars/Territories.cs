namespace TerritoryWars.Territories
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using Rage;

    class TerritoriesManager : Manager
    {
        // Public Properties
        public IDictionary Territories;

        private static TerritoryFactory _TerritoriesFactory;
        public TerritoryFactory TerritoriesFactory
        {
            get { return _TerritoriesFactory; }
        }

        public TerritoriesManager() : base()
        {
            InitializeTerritoriesContainer();
            _TerritoriesFactory = new TerritoryFactory();
            CreateTerritories();
        }

        private void InitializeTerritoriesContainer()
        {
            Territories = new Dictionary<string, Territory>();
        }

        public void CreateTerritories()
        {
            if (TerritoriesFactory != null)
            {
                for (int i = 0; i < TerritoriesFactory.TerritoriesToCreate.Count; i++)
                {
                    TerritoryData CurrentTerritoryData = TerritoriesFactory.TerritoriesToCreate[i];
                    Territory NewTerritory = TerritoriesFactory.CreateTerritory(CurrentTerritoryData);
                    Territories.Add(CurrentTerritoryData.Name, NewTerritory);
                }
            }
        }

        public void DestroyTerritories()
        {
            InitializeTerritoriesContainer();
        }

        public override void Tick()
        {
            base.Tick();
        }

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
                    Territory TerritoryObj = (Territory)Enumerator.Value;
                    TerritoryObj.ToggleBlip();
                    break;
                }
            }
        }

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
                    ((Territory)Enumerator.Value).DeactivateBlip();
                    ((Territory)Enumerator.Value).ActivateBlip();
                    break;
                }
            }
        }

        public void RemoveTerritoryBlip(string TerritoryName)
        {
            foreach (DictionaryEntry Enumerator in Territories)
            {
                if ((string)Enumerator.Key == TerritoryName)
                {
                    ((Territory)Enumerator.Value).DeactivateBlip();
                    break;
                }
            }
        }

        public void ShowAllTerritoryBlips(string EventText)
        {
            foreach (DictionaryEntry Enumerator in Territories)
            {
                Territory TerritoryObj = (Territory)Enumerator.Value;
                TerritoryObj.ActivateBlip();
            }
        }

        public void RemoveAllTerritoryBlips(string EventText)
        {
            foreach (DictionaryEntry Enumerator in Territories)
            {
                Territory TerritoryObj = (Territory)Enumerator.Value;
                TerritoryObj.DeactivateBlip();
            }
        }
    }

    public struct TerritoryData
    {
        public TerritoryData(string TerritoryName, Vector3 TerritoryLocation, Color TerritoryColor)
        {
            Name = TerritoryName;
            Location = TerritoryLocation;
            Color = TerritoryColor;
        }

        public string Name { get; }
        public Vector3 Location { get; }
        public Color Color { get; }

        public override string ToString() => $"({Name}, {Location}, {Color})";
    }

    class TerritoryFactory : Factory
    {
        // Public Properties
        public List<TerritoryData> TerritoriesToCreate = new List<TerritoryData>();

        public TerritoryFactory() : base()
        {
            TerritoriesToCreate.Add(new TerritoryData("Territory1", new Vector3(649.8077f, -8.154874f, 82.40269f), Color.Blue));
            TerritoriesToCreate.Add(new TerritoryData("Territory2", new Vector3(451.7062f, -993.2839f, 30.6896f), Color.Green));
        }

        public Territory CreateTerritory(TerritoryData NewTerritoryData)
        {
            Territory NewTerritory = new Territory(NewTerritoryData);
            return NewTerritory;
        }
    }

    class Territory : TWClass
    {
        // Public
        public TerritoryData Data;

        // Private
        private float Influence = 10.0f;

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

        public float GetInfluence()
        {
            return Influence;
        }

        private Blip ActiveBlip;

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
            NewBlip.Name = Data.Name;
            NewBlip.Order = 0;
            NewBlip.Color = Data.Color;
            NewBlip.Scale = 10.0f;
            NewBlip.Alpha = 0.2f;
            ActiveBlip = NewBlip;
        }

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

        // Constructor
        public Territory(TerritoryData NewTerritoryData) : base()
        {
            Data = NewTerritoryData;
            StartNewFiber(1000, Tick);
        }

        public override void Tick()
        {
            base.Tick();

        }
    }
}
