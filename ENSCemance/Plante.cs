public class Plante{
    protected  string nom;
    protected string espece
    protected bool comestible; 
    protected  bool mauvaiseHerbe;
    protected string saisonSemis;
    protected string terrainPref;
    protected int espacement;
    protected float vitesseCroissance;
    protected float besoinEau;
     protected float zoneEau;
    protected float besoinLumi;
    protected float zoneLumi;
    protected float besoinNutritif;
    protected float zoneNutritif;
    protected float besoinTemp;
    protected float zoneTemp;
    protected List<(Maladie, double)>  maladies;
    protected float esperenceVie;
    protected float nbPousse;
    protected bool estVivante;
    protected int CompteurDecomposition;
    protected bool estEnvahissante;
    protected int etapeDeVie;
    protected List<(x,y,taille)> OrientationTaillepousse;  //Faire x*t puis y*t
    protected bool estMalade;
    protected List<Maladie> maladie;
}