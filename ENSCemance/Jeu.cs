using System;
using System.Collections.Generic;
public class Jeu
{
    private int semaine = 1;
    private int mois = 4;
    private int annee = 2025;
    private string saison = "hiver";
    private List<Terrain> jardin = [];
    private bool dansJardin = true;
    public int positionTerrainSelectionner;
    public int positionCurseurTerrain = 0;


    // A mettre dans le terrain plutôt ? 
    // Calcule la dimension (côté) du jardin (carré)
    private int DimensionJardin
    {
        get { return (int)Math.Sqrt(jardin.Count); }
    }


    public void UpdateNouvelleSaison(float indice)
    {
        for (int i = 0; i < jardin.Count(); i++)
        {
            Terrain terrainActuel = jardin[i];
            //terrainActuel.temperature = terrainActuel.indiceTemp * indice;
        }
    }
    public void UpdateTemps()
    {
        semaine++;
        if (semaine > 4)
        {
            semaine = 1;
            mois++;
            if (mois > 12)
            {
                mois = 1;
                annee++;
            }
        }

        if (mois <= 3)
        {
            saison = "hiver";
            UpdateNouvelleSaison(1);
        }
        else if (mois <= 6)
        {
            saison = "printemps";
            UpdateNouvelleSaison(1.7f);
        }
        else if (mois <= 9)
        {
            saison = "ete";
            UpdateNouvelleSaison(2);
        }
        else
        {
            saison = "automne";
            UpdateNouvelleSaison(1.2f);
        }
    }
    public void AugmenterNutrition()
    {
        for (int i = 0; i < jardin.Count(); i++)
        {
            Terrain terrainActuel = jardin[i];
            terrainActuel.Nutrition += terrainActuel.IndiceNutrition * 2;
        }
    }

    public void SelectionnerAction()
    {
        if (dansJardin)
        {
            bool selectionTerrain = false;
            int dimension = DimensionJardin;

            while (!selectionTerrain)
            {
                Console.Clear();
                // Affichage du jardin (utiliser AffichageTerrain)
                var affichage = new AffichageTerrain();
                affichage.jardin = jardin;
                affichage.tailleJardin = dimension;
                affichage.positionCurseur = positionCurseurTerrain;
                affichage.annee = annee;
                affichage.mois = mois;
                affichage.semaine = semaine;
                affichage.AffichageComplet();

                // Lecture de la touche
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (positionCurseurTerrain - dimension >= 0)
                            positionCurseurTerrain -= dimension;
                        break;
                    case ConsoleKey.DownArrow:
                        if (positionCurseurTerrain + dimension < jardin.Count)
                            positionCurseurTerrain += dimension;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (positionCurseurTerrain % dimension > 0)
                            positionCurseurTerrain -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (positionCurseurTerrain % dimension < dimension - 1)
                            positionCurseurTerrain += 1;
                        break;
                    case ConsoleKey.Enter:
                        // sélectionner le terrain courant
                        positionTerrainSelectionner = positionCurseurTerrain;
                        dansJardin = false;
                        selectionTerrain = true;
                        break;
                    case ConsoleKey.V:
                        // passer la semaine sans sortir
                        PasserSemaine();
                        break;
                        // ajouter autres raccourcis si besoin
                }
            }

        }
        else
        {
            bool selectionTerminer = true;
            while (selectionTerminer)
            {
                Console.WriteLine();
                Console.WriteLine("Sélectionner une action à faire : ");
                Console.WriteLine(" - Désherber : appuyer sur d");
                Console.WriteLine(" - Pailler : appuyer sur p");
                Console.WriteLine(" - Traiter : appuyer sur t");
                Console.WriteLine(" - Semer : appuyer sur s");
                Console.WriteLine(" - Arroser : appuyer sur a");
                Console.WriteLine(" - Pour revenir au jardin : r");
                Console.WriteLine(" - Pour terminer la semaine : v");

                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D:
                        Desherber();
                        selectionTerminer = false;
                        break;
                    case ConsoleKey.P:
                        Pailler();
                        selectionTerminer = false;
                        break;
                    case ConsoleKey.T:
                        Traiter();
                        selectionTerminer = false;
                        break;
                    case ConsoleKey.S:
                        Semer();
                        selectionTerminer = false;
                        break;
                    case ConsoleKey.A:
                        Arroser();
                        selectionTerminer = false;
                        break;
                    case ConsoleKey.R:
                        // revenir au jardin
                        dansJardin = true;
                        selectionTerminer = false;
                        break;
                    case ConsoleKey.V:
                        PasserSemaine();
                        selectionTerminer = false;
                        break;
                    default:
                        Console.WriteLine("Mauvais input");
                        break;
                }

            }
        }

    }
    public void Deserber()
    {
        Terrain terrainActuel = jardin[positionTerrainSelectionner];
        terrainActuel.Potager[positionCurseurTerrain] = null; //plante vide
    }
    private void Pailler()
    {
        Terrain terrainActuel = jardin[positionTerrainSelectionner];
        if (terrainActuel.Potager[positionCurseurTerrain].besoinTemp > 0.2)
        {
            terrainActuel.Potager[positionCurseurTerrain].besoinTemp -= 0.2f;
        }
        else
        {
            terrainActuel.Potager[positionCurseurTerrain].besoinTemp -= 0f;
        }

    }
    private void Arroser()
    {
        Terrain terrainActuel = jardin[positionTerrainSelectionner];
        if (terrainActuel.Potager[positionCurseurTerrain].besoinEau > 0.2)
        {
            terrainActuel.Potager[positionCurseurTerrain].besoinEau -= 0.2f;
        }
        else
        {
            terrainActuel.Potager[positionCurseurTerrain].besoinEau -= 0f;
        }
    }
    private void Traiter()
    {
        Terrain terrainActuel = jardin[positionTerrainSelectionner];
        terrainActuel.Potager[positionCurseurTerrain].Maladies = [];
    }
    private void Semer()
    {
        Console.WriteLine("Choisisser une plante à planter : ");
        Console.WriteLine(""); // mettre liste des plantes ainsi que leurs caractéristiques/besoin
        bool selectionTerminer = true;
        while (selectionTerminer)
            string input = Convert.ToString(Console.ReadKey());
        switch (input)
        {
            case "1":

                selectionTerminer = false;
                break;

            case "2":

                selectionTerminer = false;

                break;

            case "3":

                selectionTerminer = false;

                break;

            case "4":

                selectionTerminer = false;
                break;

            case "5":

                selectionTerminer = false;
                break;

            case "6":

                selectionTerminer = false;

                break;

            case "7":

                selectionTerminer = false;
                break;
            case "8":

                selectionTerminer = false;
                break;
            case "9":

                selectionTerminer = false;
                break;
            case "10":

                selectionTerminer = false;
                break;
            case "11":

                selectionTerminer = false;
                break;
            case "12":
                selectionTerminer = false;
                break;

            default:
                Console.WriteLine("Mauvais input");
                break;
        }
    // private void Recolter() { } pas besoin puisque la récolte est automatique
        /*
        private void InstallerSerre() { }
        private void MettreBarriere() { }
        private void MettrePareSoleil() { }   On les met ceux là ? Peut-être pas.
        */
    public void PasserSemaine()
    {
        AugmenterNutrition();
        UpdateTemps(); // il faut faire pousser les plantes ici et faire en sorte qu'elles ai + soif
    }
}
}