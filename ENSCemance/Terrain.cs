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
    protected List<Intru> intruPossible;
    protected List<Maladie> maladiePossible;

    // Taille du potager (côté d'un carré) et liste aplatie de plantes
    protected int taillePotager;
    protected List<Plante> potager;

    #region Propriétés

    
    /// Température actuelle du terrain.
    
    public float Temperature
    {
        get { return temperature; }
        set { temperature = value; }
    }

    
    /// Humidité actuelle du terrain.
    
    public float Humidite
    {
        get { return humidite; }
        set { humidite = value; }
    }

    
    /// Luminosité actuelle du terrain.
    
    public float Luminosite
    {
        get { return luminosite; }
        set { luminosite = value; }
    }

    
    /// Nutrition actuelle du terrain.
    
    public float Nutrition
    {
        get { return nutrition; }
        set { nutrition = value; }
    }

    
    /// Indice d'influence saisonnière sur la température.
    
    public float IndiceTemp
    {
        get { return indiceTemp; }
        set { indiceTemp = value; }
    }

    
    /// Indice d'influence saisonnière sur l'humidité.
    
    public float IndiceHum
    {
        get { return indiceHum; }
        set { indiceHum = value; }
    }

    
    /// Indice d'influence saisonnière sur la luminosité.
    
    public float IndiceLum
    {
        get { return indiceLum; }
        set { indiceLum = value; }
    }

    
    /// Indice d'influence des plantes sur la nutrition.
    
    public float IndiceNutrition
    {
        get { return indiceNutrition; }
        set { indiceNutrition = value; }
    }

    
    /// Type de ce terrain (ex: "Forestier", "Désertique").
    
    public string TypeTerrain
    {
        get { return typeTerrain; }
    }

    
    /// Liste des intrus pouvant apparaître sur ce terrain.
    
    public List<Intru> IntruPossible
    {
        get { return intruPossible; }
    }

    
    /// Liste des maladies pouvant affecter ce terrain.
    
    public List<Maladie> MaladiePossible
    {
        get { return maladiePossible; }
    }

    
    /// Nombre total de cases dans le potager (dimension^2).
    
    public int NombreCasesPotager
    {
        get { return potager.Count; }
    }

    
    /// Dimension (côté) du potager.
    
    public int DimensionPotager
    {
        get { return taillePotager; }
    }

    
    /// Liste aplatie des plantes dans le potager.
    
    public List<Plante> Potager
    {
        get { return potager; }
    }

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

        // Initialisation de la liste aplatie du potager avec null
        potager = new List<Plante>();
        int totalCases = taillePotager * taillePotager;
        for (int i = 0; i < totalCases; i++)
        {
            potager.Add(null);
        }

        // Initialisation des intrus et maladies selon le type de terrain
        InitialiserEvenements();
    }

    
    /// Calcule la distance minimale entre une plante donnée et son voisin le plus proche
    /// ou le bord du potager.
    
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

    
    /// Plante une nouvelle plante à la position (ligne, colonne) si la case est vide.
    
    public void Semer(Plante plante, int ligne, int colonne)
    {
        if (ligne < 0 || ligne >= DimensionPotager || colonne < 0 || colonne >= DimensionPotager)
            throw new ArgumentOutOfRangeException("Coordonnées hors potager");
        int idx = ligne * DimensionPotager + colonne;
        if (potager[idx] != null)
            throw new InvalidOperationException("La case n'est pas vide");
        potager[idx] = plante;
    }

    
    /// Récolte et retire la plante à la position (ligne, colonne).
    
    public Plante Recolter(int ligne, int colonne)
    {
        if (ligne < 0 || ligne >= DimensionPotager || colonne < 0 || colonne >= DimensionPotager)
            throw new ArgumentOutOfRangeException("Coordonnées hors potager");
        int idx = ligne * DimensionPotager + colonne;
        Plante plante = potager[idx];
        potager[idx] = null;
        return plante;
    }

    
    /// Désherbe le potager : retire toutes les mauvaises herbes.
    
    public void Desherber()
    {
        for (int i = 0; i < potager.Count; i++)
        {
            if (potager[i] != null && potager[i].MauvaiseHerbe)
            {
                potager[i] = null;
            }
        }
    }

    
    /// Compte le nombre de plantes actuellement dans le potager.
    
    public int CompterPlantes()
    {
        int count = 0;
        foreach (var p in potager)
        {
            if (p != null)
            {
                count++;
            }
        }
        return count;
    }

    
    /// Met à jour les états du terrain en fonction de la saison et des plantes.
    
    public abstract void MettreAJourEtat();

    
    /// Initialise les listes d'intrus et de maladies possibles pour ce terrain.
    
    protected abstract void InitialiserEvenements();
}