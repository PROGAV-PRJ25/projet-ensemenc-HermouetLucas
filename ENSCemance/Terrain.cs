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
    protected string typeTerrain;

    // Listes des intrus et maladies possibles sur ce terrain
    protected List<Intrus> intruPossible;
    protected List<Maladie> maladiePossible;

    // Taille du potager (côté d'un carré) et matrice de plantes
    protected int taillePotager;
    protected List<List<Plante>> potager;

    #region Propriétés

  
    /// Température actuelle du terrain.
    
    public float Temperature { get => temperature; set => temperature = value; }

  
    /// Humidité actuelle du terrain.
    
    public float Humidite { get => humidite; set => humidite = value; }

  
    /// Luminosité actuelle du terrain.
    
    public float Luminosite { get => luminosite; set => luminosite = value; }

  
    /// Nutrition actuelle du terrain.
    
    public float Nutrition { get => nutrition; set => nutrition = value; }

  
    /// Indice d'influence saisonnière sur la température.
    
    public float IndiceTemp { get => indiceTemp; set => indiceTemp = value; }

  
    /// Indice d'influence saisonnière sur l'humidité.
    
    public float IndiceHum { get => indiceHum; set => indiceHum = value; }

  
    /// Indice d'influence saisonnière sur la luminosité.
    
    public float IndiceLum { get => indiceLum; set => indiceLum = value; }

  
    /// Indice d'influence des plantes sur la nutrition.
    
    public float IndiceNutrition { get => indiceNutrition; set => indiceNutrition = value; }

  
    /// Type de ce terrain (ex: "Forestier", "Désertique").
    
    public string TypeTerrain => typeTerrain;

  
    /// Liste des intrus pouvant apparaître sur ce terrain.
    
    public List<Intru> IntruPossible => intruPossible;

  
    /// Liste des maladies pouvant affecter ce terrain.
    
    public List<Maladie> MaladiePossible => maladiePossible;

  
    /// Taille initiale du potager (côté du carré).
    
    public int TaillePotager => taillePotager;

  
    /// Matrice des plantes plantées sur ce terrain.
    
    public List<List<Plante>> Potager => potager;

  
    /// Dimension dynamique (côté) de la matrice de potager.
    /// Calculée à partir du nombre de lignes dans la liste.
    
    public int DimensionPotager => Math.Sqrt(potager?.Count) ?? 0;

    #endregion

  
    /// Constructeur protégé de la classe abstraite Terrain.
    
    protected Terrain(
        string typeTerrain,
        float indiceTemp,
        float indiceHum,
        float indiceLum,
        float indiceNutrition,
        int taillePotager)
    {
        this.typeTerrain = typeTerrain;
        this.indiceTemp = indiceTemp;
        this.indiceHum = indiceHum;
        this.indiceLum = indiceLum;
        this.indiceNutrition = indiceNutrition;
        this.taillePotager = taillePotager;

        intruPossible = new List<Intru>();
        maladiePossible = new List<Maladie>();

        // Initialisation de la matrice du potager avec des null (pas de plante)
        potager = new List<List<Plante>>();
        for (int i = 0; i < taillePotager; i++)
        {
            var ligne = new List<Plante>();
            for (int j = 0; j < taillePotager; j++)
            {
                ligne.Add(null);
            }
            potager.Add(ligne);
        }

        // Appel pour initialiser intrus et maladies selon le type de terrain
        InitialiserEvenements();
    }

    /// Calcule la distance minimale entre une plante donnée et son voisin le plus proche
    /// ou le bord du potager.

    /// <param name="posPlante">Position linéaire de la plante dans la liste aplatie.</param>
    /// <param name="tailleTerrain">Dimension (côté) du potager (carré).</param>
    /// <returns>Distance minimale (en cases) au voisin ou au bord.</returns>
    public int CalculeEspacement(int posPlante, int tailleTerrain)
    {
        int distance = 0;
        bool voisin = false;

        // Aplatir la matrice pour simplifier les calculs d'index
        var flat = new List<Plante>();
        foreach (var ligne in potager)
            flat.AddRange(ligne);
        int maxIndex = flat.Count;

        while (!voisin)
        {
            distance++;
            int col = posPlante % tailleTerrain;

            // Si on atteint un bord du potager, on stoppe
            if (col - distance < 0 || col + distance >= tailleTerrain ||
                posPlante - (tailleTerrain * distance) < 0 || posPlante + (tailleTerrain * distance) >= maxIndex)
            {
                voisin = true;
            }

            int j = -1;
            // Parcours de la "couronne" à la distance actuelle
            for (int k = 1; k <= distance && !voisin; k++)
            {
                for (int i = -distance; i <= distance; i++)
                {
                    j = posPlante - (tailleTerrain * k) + i;
                    if (j >= 0 && j < maxIndex && flat[j] != null)
                    {
                        voisin = true;
                        ;
                    }

                    j = posPlante + (tailleTerrain * k) + i;
                    if (j >= 0 && j < maxIndex && flat[j] != null)
                    {
                        voisin = true;
                    }
                }
            }
        }

        return distance;
    }

  
    /// Met à jour les états du terrain en fonction de la saison et des plantes.
    
    public abstract void MettreAJourEtat();

  
    /// Initialise les listes d'intrus et de maladies possibles pour ce terrain.
    
    protected abstract void InitialiserEvenements();
}
