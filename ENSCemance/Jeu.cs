public class Jeu
{
    private int semaine = 1;
    private int mois = 4;
    private int annee = 2025;
    private string saison = "hiver";
    private List<List<Terrain>> jardin = [];

    public void UpdateNouvelleSaison(float indice)
    {
        for (int i = 0; i < jardin.Count(); i++)
        {
            for (int j = 0; j < jardin[0].Count(); j++)
            {
                Terrain terrainActuel = jardin[i][j];
                //terrainActuel.temperature = terrainActuel.indiceTemp * indice;
            }
        }
    }
    public void UpdateTemps()
    {
        semaine++;
        if (semaine > 4)
        {
            semaine = 1;
            mois++;
            if (mois > 12)
            {
                mois = 1;
                annee++;
            }
        }

        if (mois <= 3)
        {
            saison = "hiver";
            UpdateNouvelleSaison(1);
        }
        else if (mois <= 6)
        {
            saison = "printemps";
            UpdateNouvelleSaison(1.7f);
        }
        else if (mois <= 9)
        {
            saison = "ete";
            UpdateNouvelleSaison(2);
        }
        else
        {
            saison = "automne";
            UpdateNouvelleSaison(1.2f);
        }
    }
    public void AugmenterNutrition()
    {
        for (int i = 0; i < jardin.Count(); i++)
        {
            for (int j = 0; j < jardin[0].Count(); j++)
            {
                Terrain terrainActuel = jardin[i][j];
                //terrainActuel.nutrition += terrainActuel.indiceNutrition * 2;
            }
        }
    }
    public void Deserber() { }
    private void Pailler() { }
    private void Arroser() { }
    private void Traiter() { }
    private void Semer() { }
    private void Recolter() { }
    private void InstallerSerre() { }
    private void MettreBarriere() { }
    private void MettrePareSoleil() { }
    public void FaireAction()
    {
        AugmenterNutrition();
        UpdateTemps();
    }
}