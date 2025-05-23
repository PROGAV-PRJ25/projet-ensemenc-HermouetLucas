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
    private Terrain terrainActuel;

    public bool mode;


    private int DimensionJardin
    {
        get { return (int)Math.Sqrt(jardin.Count); }
    }
    public Jeu()
    {
        List<string> differentsTerrainType = new List<string>() { "Jungle", "Marecageux", "Steppe", "Montagneux", "Glaciaire", "Forestier", "Urbain", "Plaine", "Savane", "Desertique", "Oceanique", "Volcanique" };
        Random random = new Random();
        string terrainType = differentsTerrainType[random.Next(12)];
        for (int i = 0; i < 9; i++)
        {
            jardin.Add(new Terrain(terrainType, 9));
        }
    }

    public void UpdateNouvelleSaison(float indice)
    {
        for (int i = 0; i < jardin.Count(); i++)
        {
            terrainActuel = jardin[i];
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
            terrainActuel = jardin[i];
            terrainActuel.Nutrition += terrainActuel.IndiceNutrition * 2;
        }
    }

    //Permet de déplacer le curseur dans le jardin et de sélectionner un terrain.
    public void SelectionnerAction()
    { //ajouter une boucle while
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

            // Mode potager : déplacement dans la liste aplatie de plantes
            bool selectionPotager = false;
            terrainActuel = jardin[positionTerrainSelectionner];
            int dimensionPotager = terrainActuel.DimensionPotager;

            while (!selectionPotager)
            {
                Console.Clear();
                // Affichage du potager (utiliser AffichagePotager)
                var affichagePotager = new AffichagePotager();
                affichagePotager.potager = terrainActuel.Potager;
                affichagePotager.taillePotager = dimensionPotager;
                affichagePotager.positionCurseur = positionCurseurTerrain;
                affichagePotager.AffichageComplet();

                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (positionCurseurTerrain - dimensionPotager >= 0)
                            positionCurseurTerrain -= dimensionPotager;
                        break;
                    case ConsoleKey.DownArrow:
                        if (positionCurseurTerrain + dimensionPotager < terrainActuel.Potager.Count)
                            positionCurseurTerrain += dimensionPotager;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (positionCurseurTerrain % dimensionPotager > 0)
                            positionCurseurTerrain -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (positionCurseurTerrain % dimensionPotager < dimensionPotager - 1)
                            positionCurseurTerrain += 1;
                        break;
                    case ConsoleKey.Enter:
                        // ouvrir menu d'actions sur la case sélectionnée
                        selectionPotager = true;
                        break;
                    case ConsoleKey.R:
                        // revenir au jardin
                        dansJardin = true;
                        selectionPotager = true;
                        break;
                }
            }

            bool selectionTerminer = true;
            while (selectionTerminer)
            {
                Console.Clear();
                Terrain terrainActuel = jardin[positionTerrainSelectionner];
                // Affichage du potager (utiliser AffichagePotager)
                var affichage = new AffichagePotager();
                affichage.potager = terrainActuel1.Potager;
                affichage.taillePotager = terrainActuel1.taillePotager;
                affichage.positionCurseur = positionCurseurTerrain;
                affichage.AffichageComplet();

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
                        Deserber();
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
        terrainActuel = jardin[positionTerrainSelectionner];
        terrainActuel.Potager[positionCurseurTerrain] = null; //plante vide
    }
    private void Pailler()
    {
        terrainActuel = jardin[positionTerrainSelectionner];
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
        terrainActuel = jardin[positionTerrainSelectionner];
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
        terrainActuel = jardin[positionTerrainSelectionner];
        terrainActuel.Potager[positionCurseurTerrain].Maladies = [];
    }
    private void Semer()
    {
        Console.WriteLine("Choisisser une plante à planter : ");
        Console.WriteLine(" 1 pour planter une tomate");
        Console.WriteLine(" 2 pour planter un pimment d'espelette");
        Console.WriteLine(" 3 pour planter un pimment de foudre");
        Console.WriteLine(" 4 pour planter un choux géant");
        Console.WriteLine(" 5 pour planter une goyave");
        Console.WriteLine(" 6 pour planter une pasteque");
        Console.WriteLine(" 7 pour planter une citrouille");
        Console.WriteLine(" 8 pour planter une lumombre");
        Console.WriteLine(" 9 pour planter un piment givreux");
        Console.WriteLine(" d pour planter une calyxia");
        Console.WriteLine(" o pour planter une racine de fer");
        Console.WriteLine(" t pour revenir en arrière");

        bool selectionTerminer = true;
        terrainActuel = jardin[positionTerrainSelectionner];
        while (selectionTerminer)
        {
            string input = Convert.ToString(Console.ReadKey());
            switch (input)
            {
                case "1":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("tomate");
                    selectionTerminer = false;
                    break;

                case "2":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("pimentEspelette");
                    selectionTerminer = false;
                    break;

                case "3":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("pimentFoudre");
                    selectionTerminer = false;

                    break;

                case "4":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("chouGeant");

                    selectionTerminer = false;
                    break;

                case "5":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("goyave");

                    selectionTerminer = false;
                    break;

                case "6":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("pasteque");

                    selectionTerminer = false;

                    break;

                case "7":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("citrouille");

                    selectionTerminer = false;
                    break;
                case "8":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("lumombre");

                    selectionTerminer = false;
                    break;
                case "9":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("pimentGivreux");

                    selectionTerminer = false;
                    break;
                case "d":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("calyxia");

                    selectionTerminer = false;
                    break;
                case "o":
                    terrainActuel.Potager[positionCurseurTerrain] = new PlanteComestible("racineDeFer");

                    selectionTerminer = false;
                    break;
                case "t":
                    selectionTerminer = false;
                    break;

                default:
                    Console.WriteLine("Mauvais input");
                    break;
            }
        }
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
    public void PlanteQuiPousse()
    {
        jardin[positionTerrainSelectionner].MettreAJourEtat();

    }
}
