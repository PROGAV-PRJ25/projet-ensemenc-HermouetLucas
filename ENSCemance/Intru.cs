using System.Runtime.Intrinsics.Arm;

public class Intru
{

    private string nom;
    public string Nom
    {
        get
        {
            return nom;
        }
    }

    public bool Benefique { get; set; }

    public float ProbabiliteDApparaitre { get; set; }

    private List<Plante> jardin;

    private Random rd = new Random();

    private int tailleCarre;
    public Intru(string Nom, List<Plante> Jardin, int TailleCarre)
    {
        nom = Nom;
        (ProbabiliteDApparaitre, Benefique) = dictAutoAssignement[nom];
        jardin = Jardin;
        tailleCarre = TailleCarre;
    }

    public void Effet()
    {
        switch (nom)
        {
            //il mange juste une case
            case "Lapin":
                int xTest = rd.Next(0, tailleCarre);
                int yTest = rd.Next(0, tailleCarre);
                int posLapin = yTest * (tailleCarre-1)+xTest;
                jardin[posLapin].EstVivante = false;
                
                break;
        }
    }

    private static Dictionary<string, (float, bool)> dictAutoAssignement
    = new Dictionary<string, (float, bool)>
    {
        { "Lapin", (0.5f, false) },
        { "Fée", (0.1f, true) },
        { "Ratons Laveur", (0.3f, false) },
        { "Fée Maléfique", (0.1f, true) }
    };
}