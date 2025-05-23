public class Jeu
{
    private int semaine = 1;
    private int mois = 4;
    private int annee = 2025;
    private string saison = "hiver";
    private List<Terrain> jardin = [];
    private bool dansJardin = true;
    public int positionTerrainSelectionner;
    public int positionCurseurTerrain;

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
    { //ajouter une boucle while
        if (dansJardin)
        {
            // possibilité de bouger le curseur et de séléctionner un terrain
        }
        else
        {
            bool selectionTerminer = true;
            while (selectionTerminer)
            { //ajouter la possiblilité de déplacement ici aussi
                Console.WriteLine();
                Console.WriteLine("Selectionner une action à faire : ");
                Console.WriteLine(" - Déserber : retire la plante selectionner | appuyer sur d");
                Console.WriteLine(" - Pailler : augmente légèrement la chaleur de la plante selectionner| appuyer sur p");
                Console.WriteLine(" - Traiter : retire la maladie de la plante selectionner | appuyer sur t");
                Console.WriteLine(" - Semer : plante une plante à l'endrois selectionner | appuyer sur s");
                Console.WriteLine(" - Arroser : arrose la plante à l'endrois selectionner | appuyer sur a");
                Console.WriteLine(" - Pour revenir sur la liste des terrains | appuyer sur r");
                Console.WriteLine(" - Pour terminer la semaine | appuyer sur v");
                string input = Convert.ToString(Console.ReadKey());
                switch (input)
                {
                    case "d":
                        Deserber();
                        selectionTerminer = false;
                        break;

                    case "p":
                        Pailler();
                        selectionTerminer = false;

                        break;

                    case "t":
                        Traiter();
                        selectionTerminer = false;

                        break;

                    case "s":
                        Terrain terrainActuel = jardin[positionTerrainSelectionner];
                        if (terrainActuel.Potager[positionCurseurTerrain] == null)
                            Semer();
                        else
                        {
                            Console.WriteLine("Il y a déjà une plante ici");
                        }
                        selectionTerminer = false;
                        break;

                    case "a":
                        Arroser();
                        selectionTerminer = false;
                        break;

                    case "r":
                        //pour revenir à liste des terrain
                        selectionTerminer = false;

                        break;

                    case "v":
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
        Terrain terrainActuel = jardin[positionTerrainSelectionner];
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
        // faire en sorte que les plantes poussent en fonction de leurs indice de croissance / il faut également que les niveaux de croissance augmente.
    }
}