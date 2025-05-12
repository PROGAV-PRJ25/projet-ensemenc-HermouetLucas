using System.Runtime.CompilerServices;

public class Maladie
{
    public float probabiliteDLAttraper;
    public string nom;
    public List<string> traitement;
    public static Dictionary<string, (float, List<string>)> dictAutoAssignement
    = new Dictionary<string, (float, List<string>)>
    {
        { "rhume", (0.1f,["doliprane",""]) }
    };

    public Maladie(string Nom)
    {
        nom = Nom;
    }

    public void Effet(ref float Temp, ref float Luminosite, ref float Eau, ref float Nutrition, ref float esperenceVie)
    {
        switch (nom)
        {
            case "Oïdium":
                break;
        }

    }
    private static Dictionary<string, (float, List<string>)> dictAutoAssignement =
    new Dictionary<string, (float, List<string>)>{
        {"Oïdium",(0.15f,new List<string>(){"Round-Up"})},
        {"Mildiou",(0.20f,new List<string>(){"Antibiotique"})},
        {"Fusariose",(0.95f,new List<string>(){"Round-Up"})},
        {"Bactériose",(0.20f,new List<string>(){"Antibiotique"})},
        {"Botrytis",(0.10f,new List<string>(){"Round-Up","Antibiotique"})}
    };
}