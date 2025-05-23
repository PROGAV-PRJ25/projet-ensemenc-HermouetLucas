using System;
using System.Collections.Generic;


/// Classe abstraite représentant les caractéristiques communes d'un terrain.

public abstract class Terrain
{
    // États du terrain
    protected float temperature;
    protected float humidite;
    protected float luminosite;
    protected float nutrition;

    // Indices d'influence
    protected float indiceTemp;
    protected float indiceHum;
    protected float indiceLum;
    protected float indiceNutrition;

    // Type de terrain (ex: "Forestier", "Désertique", ...)
    public string terrainType;

    // Listes des intrus et maladies possibles sur ce terrain
    protected List<Intru> intruPossible;
    protected List<Maladie> maladiePossible;

    // Taille du potager (côté d'un carré) et liste aplatie de plantes
    public int taillePotager;
    protected List<Plante> potager;

    #region Propriétés

    public float Temperature
    {
        get { return temperature; }
        set { temperature = value; }
    }

    public float Humidite
    {
        get { return humidite; }
        set { humidite = value; }
    }

    public float Luminosite
    {
        get { return luminosite; }
        set { luminosite = value; }
    }

    public float Nutrition
    {
        get { return nutrition; }
        set { nutrition = value; }
    }

    public float IndiceTemp
    {
        get { return indiceTemp; }
        set { indiceTemp = value; }
    }

    public float IndiceHum
    {
        get { return indiceHum; }
        set { indiceHum = value; }
    }

    public float IndiceLum
    {
        get { return indiceLum; }
        set { indiceLum = value; }
    }

    public float IndiceNutrition
    {
        get { return indiceNutrition; }
        set { indiceNutrition = value; }
    }


    /// Type de ce terrain (ex: "Forestier", "Désertique").

    public string TerrainType
    {
        get { return terrainType; }
    }

    public List<Intru> IntruPossible
    {
        get { return intruPossible; }
    }

    public List<Maladie> MaladiePossible
    {
        get { return maladiePossible; }
    }

    public int NombreCasesPotager
    {
        get { return potager.Count; }
    }

    public int DimensionPotager
    {
        get { return taillePotager; }
    }

    public List<Plante> Potager
    {
        get { return potager; }
    }

    #endregion


    /// Constructeur protégé initialisant tous les attributs selon le type de terrain.
    // on a taille du potager correspond à la taille de la matrice 5*5 ou autres.
    protected Terrain(string terrainType, int taillePotager)
    {
        this.terrainType = terrainType;
        this.taillePotager = taillePotager;

        intruPossible = new List<Intru>();
        maladiePossible = new List<Maladie>();

        // Initialisation du potager (liste aplatie)
        potager = new List<Plante>(taillePotager * taillePotager);
        for (int i = 0; i < taillePotager * taillePotager; i++)
            potager.Add(null);

        // Affectation des états et indices suivant le type
        switch (terrainType)
        {
            case "Volcanique":
                indiceTemp = 0.9f; temperature = 0.8f;
                indiceHum = 0.2f; humidite = 0.1f;
                indiceLum = 0.2f; luminosite = 0.1f;
                indiceNutrition = 1.0f; nutrition = 0.9f;
                break;
            case "Oceanique":
                indiceTemp = 0.6f; temperature = 0.5f;
                indiceHum = 1.0f; humidite = 0.9f;
                indiceLum = 0.3f; luminosite = 0.2f;
                indiceNutrition = 0.5f; nutrition = 0.5f;
                break;
            case "Desertique":
                indiceTemp = 1.0f; temperature = 0.9f;
                indiceHum = 0.1f; humidite = 0.0f;
                indiceLum = 1.0f; luminosite = 0.9f;
                indiceNutrition = 0.1f; nutrition = 0.2f;
                break;
            case "Savane":
                indiceTemp = 0.8f; temperature = 0.7f;
                indiceHum = 0.2f; humidite = 0.1f;
                indiceLum = 1.0f; luminosite = 0.9f;
                indiceNutrition = 0.5f; nutrition = 0.6f;
                break;
            case "Plaine":
                indiceTemp = 0.5f; temperature = 0.5f;
                indiceHum = 0.5f; humidite = 0.5f;
                indiceLum = 0.8f; luminosite = 0.7f;
                indiceNutrition = 0.5f; nutrition = 0.5f;
                break;
            case "Urbain":
                indiceTemp = 0.8f; temperature = 0.7f;
                indiceHum = 0.2f; humidite = 0.2f;
                indiceLum = 0.5f; luminosite = 0.5f;
                indiceNutrition = 0.2f; nutrition = 0.3f;
                break;
            case "Forestier":
                indiceTemp = 0.5f; temperature = 0.5f;
                indiceHum = 0.5f; humidite = 0.5f;
                indiceLum = 0.5f; luminosite = 0.5f;
                indiceNutrition = 0.5f; nutrition = 0.5f;
                break;
            case "Glaciaire":
                indiceTemp = 0.2f; temperature = 0.1f;
                indiceHum = 0.2f; humidite = 0.2f;
                indiceLum = 0.5f; luminosite = 0.5f;
                indiceNutrition = 0.2f; nutrition = 0.2f;
                break;
            case "Montagneux":
                indiceTemp = 0.3f; temperature = 0.2f;
                indiceHum = 0.5f; humidite = 0.5f;
                indiceLum = 0.5f; luminosite = 0.5f;
                indiceNutrition = 0.2f; nutrition = 0.3f;
                break;
            case "Steppe":
                indiceTemp = 0.3f; temperature = 0.3f;
                indiceHum = 0.5f; humidite = 0.5f;
                indiceLum = 1.0f; luminosite = 0.9f;
                indiceNutrition = 0.5f; nutrition = 0.6f;
                break;
            case "Marecageux":
                indiceTemp = 0.5f; temperature = 0.5f;
                indiceHum = 1.0f; humidite = 0.9f;
                indiceLum = 0.2f; luminosite = 0.2f;
                indiceNutrition = 1.0f; nutrition = 0.9f;
                break;
            case "Jungle":
                indiceTemp = 0.9f; temperature = 0.8f;
                indiceHum = 1.0f; humidite = 0.9f;
                indiceLum = 1.0f; luminosite = 0.9f;
                indiceNutrition = 1.0f; nutrition = 0.9f;
                break;
            default:
                throw new ArgumentException("Type de terrain inconnu : " + terrainType);
        }

        // Initialisation spécifique aux intrus et maladies
        InitialiserEvenements();
    }


    /// Calcule la distance minimale entre une plante donnée et son voisin le plus proche
    /// ou le bord du potager.

    /// paramètre : name="posPlante">Position linéaire de la plante dans la liste aplatie.
    /// paramètre : name="tailleTerrain">Dimension (côté) du potager (carré).
    /// returns : Distance minimale (en cases) au voisin ou au bord.
    public int CalculeEspacement(int posPlante, int tailleTerrain)
    {
        int distance = 0;
        bool voisin = false;

        // Aplatir la matrice pour simplifier les calculs d'index
        var flat = new List<Plante>(potager);
        int maxIndex = flat.Count;

        while (!voisin)
        {
            distance++;
            int col = posPlante % tailleTerrain;

            // Si on atteint un bord du potager, on stoppe
            if ((col - distance) < 0 || (col + distance) >= tailleTerrain ||
                (posPlante - (tailleTerrain * distance)) < 0 || (posPlante + (tailleTerrain * distance)) >= maxIndex)
            {
                voisin = true;
            }

            int j = -1;
            // Parcours de la "couronne" à la distance actuelle
            for (int k = 1; k <= distance && !voisin; k++)
            {
                for (int i = -distance; i <= distance; i++)
                {
                    j = (posPlante - (tailleTerrain * k)) + i;
                    if (j >= 0 && j < maxIndex && flat[j] != null)
                    {
                        voisin = true;
                    }

                    j = (posPlante + (tailleTerrain * k)) + i;
                    if (j >= 0 && j < maxIndex && flat[j] != null)
                    {
                        voisin = true;
                    }
                }
            }
        }

        return distance;
    }


    public abstract void MettreAJourEtat();


    /// Initialise les listes d'intrus et de maladies possibles pour ce terrain.

    protected abstract void InitialiserEvenements();
}