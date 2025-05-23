public abstract class Plante
{
    protected Random rd = new Random(); //m'évitera de devoir
    public string Nom { get; set; }
    public string Espece { get; set; }
    protected bool mauvaiseHerbe;
    protected string saisonSemis;
    protected string terrainPref;
    protected int espacementMin;
    protected float vitesseCroissanceBase;
    protected float vitesseCroissance;
    protected float besoinEau;
    protected float zoneEau;
    protected float besoinLumi;
    protected float zoneLumi;
    protected float besoinNutritif;
    protected float zoneNutritif;
    protected float besoinTemp;
    protected float zoneTemp;
    protected float esperenceVie;
    //en float car on veut pouvoir facilement multiplier par des décimaux
    protected float nbPousse;
    public bool EstVivante { get; set; }
    protected int compteurDecomposition;
    public int CompteurDecomposition
    {
        get
        {
            return compteurDecomposition < 0 ? 0 : compteurDecomposition;
        }
        set
        {
            compteurDecomposition = value;
        }
    }
    public int etapeDeVie = 0;
    public int EtapeDeVie
    {
        get
        {
            return etapeDeVie;
        }
    }

    protected int maturité;
    public int Maturité
    {
        get
        {
            return maturité;
        }
    }
    protected int etapeDeVieMax;
    protected bool estMalade;
    protected List<Maladie> maladies = new List<Maladie>();
    public List<Maladie> Maladies
    {
        get
        {
            return maladies;
        }
    }
    protected bool aRamasse = false;
    protected bool estRecolte = false;
    //protected List<Maladie> maladie;

    public Plante(string Nom)
    {
        this.Nom = Nom;


    }
    protected void ToursGeneral(float Temp, float Luminosite, float Eau, float Nutrition, int Espacement, string TypeTerrain, //ligne avec les paramètres obligatoires
    Maladie MaladieChoppe = null, bool Traitement = false, string NomTraitement = "")// ligne avec les paramètres optionnels
    {
        if (EstVivante)
        {//vérification de condition
            //on applique d'abbord les effet des maladie déjà attrapé
            if (estMalade)
            {
                foreach (Maladie maladie in maladies)
                {
                    maladie.Effet(BesoinEau: ref besoinEau, BesoinLuminosite: ref besoinLumi, BesoinTemp: ref besoinTemp, BesoinNutrition: ref besoinNutritif, EsperenceVie: ref esperenceVie);
                    if (Traitement)
                    {
                        estMalade = maladie.Traiter(NomTraitement);
                    }
                }
            }

            bool respectTemp = besoinTemp - zoneTemp <= Temp && Temp <= besoinTemp + zoneTemp;
            bool respectLumi = besoinLumi - zoneLumi <= Luminosite && Luminosite <= besoinLumi + zoneLumi;
            bool respectEau = besoinEau - zoneEau <= Eau && Eau <= besoinEau + zoneEau;
            bool respectNutrition = besoinNutritif - zoneNutritif <= Nutrition && Nutrition <= besoinNutritif + zoneNutritif;
            bool respectEspacement = espacementMin < Espacement;
            bool respectTypeTerrain = TypeTerrain == terrainPref;

            //on utilise ce tableau pour compter le nombre de condition respecté. Içi on utilise pas la maladie. Ces calculs là seront fait à la fin
            bool[] tabConds = { respectTemp, respectEau, respectLumi, respectNutrition, respectEspacement, respectTypeTerrain, estMalade };
            ModifVitesseCroissance(tabConds, MaladieChoppe);
            //si la vitesse de croissance est < 1 elle ne grandit pas si elle est inférieur à 0.5:
            //on augmente de autant que la vitesse de croissance est
            etapeDeVie += (int)(vitesseCroissance < 1 ? (1 < vitesseCroissance ? Math.Round(vitesseCroissance) : 1) : (vitesseCroissance <= 0.5 ? 0 : 1));
            //second calcul de mort de la plate: espèrence vie
            EstVivante = !(etapeDeVieMax < etapeDeVie);
            compteurDecomposition = !EstVivante ? 5 : 0;

        }
        else
        {
            compteurDecomposition--;
        }

    }
    private bool IntrusionMaladie(Maladie MaladieChoppe)
    {
        double prob = rd.NextDouble();
        bool testMaladie = (prob <= MaladieChoppe.ProbabiliteDLAttraper);
        if (testMaladie)
        {
            maladies.Add(MaladieChoppe);
        }
        return testMaladie;

    }
    private void ModifVitesseCroissance(bool[] TabConds, Maladie MaladieChoppe)
    {
        int nbCondRespecter = 0;
        foreach (bool cond in TabConds)
        {
            nbCondRespecter += cond ? 1 : 0;
        }
        if (nbCondRespecter < 3)
        {
            EstVivante = false;
            compteurDecomposition = 5;
        }
        else
        {
            int temp = nbCondRespecter - (TabConds.Length / 2) + 1;
            vitesseCroissance = vitesseCroissanceBase * (1 + (1 / temp));
            if (!Object.Equals(MaladieChoppe, null))
            {
                estMalade = estMalade || IntrusionMaladie(MaladieChoppe);
            }

        }
    }
}