public class PlanteComestible : Plante
{
    private double attiranceNuisible;
    public double AttiranceNuisible
    {
        get
        {
            return !estMalade ? attiranceNuisible : 0; //si la plante est malade elle n'attirera pas les nuisible
        }
    }
    private bool comestibleT = false;// est-ce que la plante est commestible à l'instant T et au début elle ne l'ai pas
    public PlanteComestible(string Nom) : base(Nom)
    {
        (
            espece, mauvaiseHerbe, saisonSemis, terrainPref, espacementMin, vitesseCroissanceBase, besoinEau, zoneEau, besoinLumi,
            zoneLumi, besoinNutritif, zoneNutritif, besoinTemp, zoneTemp, esperenceVie, nbPousse, etapeDeVieMax, matutité, attiranceNuisible
        ) = dictAutoAssignement[base.Nom];

    }
    public void Tours(float Temp, float Luminosite, float Eau, float Nutrition, int Espacement, string TypeTerrain, //ligne avec les paramètres obligatoires
    Maladie MaladieChoppe = null, bool Traitement = false, string NomTraitement = "")
    {
        ToursGeneral(Temp, Luminosite, Eau, Nutrition, Espacement, TypeTerrain, MaladieChoppe, Traitement, NomTraitement);
        if (estVivante)
        {
            comestibleT = etapeDeVie <= etapeDeVieMax && matutité <= etapeDeVie;
        }

    }
    //dictionnaire qui, pour un string contenant le nom de la plante est capable de lui donner tout les attributs de celle ci
    private static Dictionary<string, (string, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, int, int, double)> dictAutoAssignement
    = new Dictionary<string, (string, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, int, int, double)>
    {
        { "batavia", ("batavius", false, "printemp", "sec", 1, 1.85f, 1f, 0f, 3f, 1f, 2f, 1f, 25f, 5f, 4.5f, 2f,8,5,0.75) }
    };
}