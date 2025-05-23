public class PlanteNonComestible : Plante
{
    public bool EstEnvahissante;
    public PlanteNonComestible(string Nom) : base(Nom)
    {
        (
                    Espece, mauvaiseHerbe, saisonSemis, terrainPref, espacementMin, vitesseCroissanceBase, besoinEau, zoneEau, besoinLumi,
                    zoneLumi, besoinNutritif, zoneNutritif, besoinTemp, zoneTemp, esperenceVie, nbPousse, etapeDeVieMax, maturité, EstEnvahissante
                ) = dictAutoAssignement[base.Nom];
    }

    private static Dictionary<string, (string, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, int, int, bool)> dictAutoAssignement
    = new Dictionary<string, (string, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, int, int, bool)>
    {
        { "Chienli", ("chiantos", false, "printemp", "sec", 1, 1.85f, 1f, 0f, 3f, 1f, 2f, 1f, 25f, 5f, 4.5f, 2f,8,5,true) }
    };
}