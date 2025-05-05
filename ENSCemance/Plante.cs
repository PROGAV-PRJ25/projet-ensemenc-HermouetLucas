public class Plante{
    private  string nom;
    private string espece;
    private bool comestible; 
    private  bool mauvaiseHerbe;
    private string saisonSemis;
    private string terrainPref;
    private int espacement;
    private float vitesseCroissance;
    private float besoinEau;
    private float zoneEau;
    private float besoinLumi;
    private float zoneLumi;
    private float besoinNutritif;
    private float zoneNutritif;
    private float besoinTemp;
    private float zoneTemp;
    //private List<(Maladie, double)>  maladies;
    private float esperenceVie;
    //en float car on veut pouvoir facilement multiplier par des décimaux
    private float nbPousse;
    private bool estVivante;
    private int CompteurDecomposition;
    private bool estEnvahissante;
    private int etapeDeVie;
    private List<(int,int,int)> OrientationTaillepousse;  //Faire x*t puis y*t
    private bool estMalade;
    //private List<Maladie> maladie;

    //dictionnaire qui, pour un string contenant le nom de la plante est capable de lui donner tout les attributs de celle ci
    public static Dictionary<string, (string, bool, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, bool)> dictAutoAssignement
    = new Dictionary<string, (string, bool, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, bool)>
    {
        { "batavia", ("batavius", true, false, "printemp", "sec", 1, 1.85f, 1f, 0f, 3f, 1f, 2f, 1f, 25f, 5f, 4.5f, 2f, false) }
    };
}