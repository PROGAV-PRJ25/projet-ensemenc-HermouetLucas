public class Plante
{
    private Random rd = new Random();
    private string nom;
    private string espece;
    private bool comestible;
    private bool mauvaiseHerbe;
    private string saisonSemis;
    private string terrainPref;
    private int espacementMin;
    private float vitesseCroissance;
    private float besoinEau;
    private float zoneEau;
    private float besoinLumi;
    private float zoneLumi;
    private float besoinNutritif;
    private float zoneNutritif;
    private float besoinTemp;
    private float zoneTemp;
    private float esperenceVie;
    //en float car on veut pouvoir facilement multiplier par des décimaux
    private float nbPousse;
    private bool estVivante;
    private int CompteurDecomposition;
    private bool estEnvahissante;
    private int etapeDeVie;
    private List<(int, int, int)> OrientationTaillepousse;  //Faire x*t puis y*t
    private bool estMalade;
    private List<Maladie> maladies = new List<Maladie>();
    public List<Maladie> Maladies
    {
        get
        {
            return maladies;
        }
    }
    private bool aRamasse = false;
    private bool estRecolte = false;
    //private List<Maladie> maladie;

    public Plante(string Nom)
    {
        nom = Nom;
        (
            espece, comestible, mauvaiseHerbe, saisonSemis, terrainPref, espacementMin, vitesseCroissance, besoinEau, zoneEau, besoinLumi,
            zoneLumi, besoinNutritif, zoneNutritif, besoinTemp, zoneTemp, esperenceVie, nbPousse, estEnvahissante
        ) = dictAutoAssignement[Nom];

    }
    public void Tours(float Temp, float Luminosite, float Eau, float Nutrition, int espacement, Maladie maladieChoppe = null, bool traitement = false, string NomTraitement = "")
    {
        if (estVivante)
        {//vérification de condition
            //on applique d'abbord les effet des maladie déjà attrapé
            if (estMalade)
            {
                foreach (Maladie maladie in maladies)
                {
                    maladie.Effet(BesoinEau: ref besoinEau, BesoinLuminosite: ref besoinLumi, BesoinTemp: ref besoinTemp, BesoinNutrition: ref besoinNutritif, EsperenceVie: ref esperenceVie);
                    if (traitement)
                    {
                        estMalade = maladie.Traiter(NomTraitement);
                    }
                }
            }

            bool respectTemp = besoinTemp - zoneTemp <= Temp && Temp <= besoinTemp + zoneTemp;
            bool respectLumi = besoinLumi - zoneLumi <= Luminosite && Luminosite <= besoinLumi + zoneLumi;
            bool respectEau = besoinEau - zoneEau <= Eau && Eau <= besoinEau + zoneEau;
            bool respectNutrition = besoinNutritif - zoneNutritif <= Nutrition && Nutrition <= besoinNutritif + zoneNutritif;
            bool respectEspacement = espacement < espacementMin;

            if (!Object.Equals(maladieChoppe, null))
            {
                estMalade = IntrusionMaladie(maladieChoppe);
            }//on utilise ce tableau pour compter le nombre de condition respecté. Içi on utilise pas la maladie. Ces calculs là seront fait à la fin
            bool[] tabConds = { respectTemp, respectEau, respectLumi, respectNutrition, respectEspacement };
            int nbCondRespecter = 0;
            foreach (bool cond in tabConds)
            {
                nbCondRespecter += cond ? 1 : 0;
            }
            if (nbCondRespecter < 3)
            {
                estVivante = false;
                CompteurDecomposition = 5;
            }
            else
            {
                int temp = nbCondRespecter - (tabConds.Length / 2) + 1;
                float vitesseCroissanceBis = vitesseCroissance * (1 + (1 / temp));
                if (!Object.Equals(maladieChoppe, null))
                {
                    estMalade = estMalade || IntrusionMaladie(maladieChoppe);
                }

            }
        }
    }
    private bool IntrusionMaladie(Maladie maladieChoppe)
    {
        double prob = rd.NextDouble();
        bool testMaladie = (prob <= maladieChoppe.ProbabiliteDLAttraper);
        if (testMaladie)
        {
            maladies.Add(maladieChoppe);
        }
        return testMaladie;

    }
    public void ModifEsperanceVie() { return; }


    //dictionnaire qui, pour un string contenant le nom de la plante est capable de lui donner tout les attributs de celle ci
    private static Dictionary<string, (string, bool, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, bool)> dictAutoAssignement
    = new Dictionary<string, (string, bool, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, bool)>
    {
        { "batavia", ("batavius", true, false, "printemp", "sec", 1, 1.85f, 1f, 0f, 3f, 1f, 2f, 1f, 25f, 5f, 4.5f, 2f, false) }
    };
}