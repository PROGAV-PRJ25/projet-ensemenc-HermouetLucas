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

    private List<Plante> potager;

    private Random rd = new Random();

    private int posY = 0;

    public Intru(string Nom, List<Plante> Potager)
    {
        nom = Nom;
        (ProbabiliteDApparaitre, Benefique) = dictAutoAssignement[nom];
        this.potager = Potager;
    }

    public void Effet()
    {
        switch (nom)
        {
            //Mange juste une case
            case "Lapin":
                int posLapin = 0;
                do
                {
                    posLapin = rd.Next(0, potager.Count);
                } while (!object.Equals(potager[posLapin], null));
                potager[posLapin].EstVivante = false;
                potager[posLapin].CompteurDecomposition = 0;
                break;
            //Remet en vie toutes les plantes
            case "Fée":
                foreach (var plante in potager)
                {
                    if (!object.Equals(plante, null))
                    {
                        plante.CompteurDecomposition = 5;
                        plante.EstVivante = true;
                    }
                }
                break;
            //Detruit une ligne de plante
            case "Ratons Laveur":
                int nbCarre = (int)Math.Sqrt(Convert.ToDouble(potager.Count));
                for (int i = 0; i < nbCarre; i++)
                {
                    int posRatLaveur = nbCarre * posY + i;
                    if (!object.Equals(potager[posRatLaveur], null))
                    {
                        potager[posRatLaveur].EstVivante = false;
                        potager[posRatLaveur].CompteurDecomposition = 5;
                    }
                }
                posY++;
                break;
            //Detruit toutes les plantes
            case "Fée Maléfique":
                foreach (var plante in potager)
                {
                    if (!object.Equals(plante, null))
                    {
                        plante.CompteurDecomposition = 5;
                        plante.EstVivante = false;
                    }
                }
                posY++;
                break;


        }
    }

    public static Dictionary<string, (float, bool)> dictAutoAssignement
    = new Dictionary<string, (float, bool)>
    {
        { "Lapin", (0.5f, false) },
        { "Fée", (0.2f, true) },
        { "Ratons Laveur", (0.3f, false) },
        { "Fée Maléfique", (0.05f, true) }
    };
}