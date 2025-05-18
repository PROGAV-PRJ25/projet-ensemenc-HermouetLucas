public class PlanteNonComestible : Plante
{
    public bool estEnvahissante;
    public PlanteNonComestible(string Nom) : base(Nom)
    {
        (
                    espece, mauvaiseHerbe, saisonSemis, terrainPref, espacementMin, vitesseCroissanceBase, besoinEau, zoneEau, besoinLumi,
                    zoneLumi, besoinNutritif, zoneNutritif, besoinTemp, zoneTemp, esperenceVie, nbPousse, etapeDeVieMax, maturité, estEnvahissante
                ) = dictAutoAssignement[base.Nom];
    }

    private static Dictionary<string, (string, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, int, int, bool)> dictAutoAssignement
    = new Dictionary<string, (string, bool, string, string, int, float, float, float, float, float, float, float, float, float, float, float, int, int, bool)>
    {
        { "Chienli", ("batavius", false, "printemp", "sec", 1, 1.85f, 1f, 0f, 3f, 1f, 2f, 1f, 25f, 5f, 4.5f, 2f,8,5,true) }
    };
}