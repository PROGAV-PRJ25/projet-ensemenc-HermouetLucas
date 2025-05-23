using System.Runtime.CompilerServices;

public class Maladie
{
    private float probabiliteDLAttraper;
    public float ProbabiliteDLAttraper
    {
        get
        {
            return probabiliteDLAttraper;
        }
    }
    private string nom;
    public string Nom
    {
        get
        {
            return nom;
        }
        set
        {
            nom = value;
        }
    }
    private List<string> traitements;

    public Maladie(string Nom)
    {
        nom = Nom;
        ( probabiliteDLAttraper, traitements) = dictAutoAssignement[nom];
    }
    //**Rapport on passe par des références pour toucher directement aux variables et éviter de retourner des variable de la fonction
    public void Effet(ref float BesoinTemp, ref float BesoinLuminosite, ref float BesoinEau, ref float BesoinNutrition, ref float EsperenceVie)
    {
        switch (nom)
        {
            case "Oïdium":
                BesoinTemp *= 0.95f;
                BesoinLuminosite *= 1.1f;
                BesoinEau *= 1.1f;
                BesoinNutrition *= 1.2f;
                EsperenceVie *= 0.775f;
                break;
            case "Mildiou":
                BesoinTemp *= 0.95f;
                BesoinLuminosite *= 1.15f;
                BesoinEau *= 1.1f;
                BesoinNutrition *= 1.25f;
                EsperenceVie *= 0.7f;
                break;
            case "Fusariose":
                BesoinTemp *= 0.95f;
                BesoinLuminosite *= 1.1f;
                BesoinEau *= 1.3f;
                BesoinNutrition *= 1.35f;
                EsperenceVie *= 0.45f;
                break;
            case "Bactériose":
                BesoinTemp *= 1.05f;
                BesoinLuminosite *= 1.1f;
                BesoinEau *= 1.15f;
                BesoinNutrition *= 1.2f;
                EsperenceVie *= 0.65f;
                break;
            case "Botrytis":
                BesoinTemp *= 1.05f;
                BesoinLuminosite *= 1.1f;
                BesoinEau *= 1.2f;
                BesoinNutrition *= 1.25f;
                EsperenceVie *= 0.775f;
                break;
        }


    }
    public bool Traiter(string NomTraitement)
    {
        foreach (string traitement in traitements)
        {
            return traitement == NomTraitement;
        }
        return false;
    } 

    public static Dictionary<string, (float, List<string>)> dictAutoAssignement =
    new Dictionary<string, (float, List<string>)>{
        {"Oïdium",(0.15f,new List<string>(){"Round-Up"})},
        {"Mildiou",(0.20f,new List<string>(){"Antibiotique"})},
        {"Fusariose",(0.95f,new List<string>(){"Round-Up"})},
        {"Bactériose",(0.20f,new List<string>(){"Antibiotique"})},
        {"Botrytis",(0.10f,new List<string>(){"Round-Up","Antibiotique"})}
    };
}