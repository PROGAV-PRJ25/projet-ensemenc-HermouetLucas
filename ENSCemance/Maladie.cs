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

    public void Effet() { }
}