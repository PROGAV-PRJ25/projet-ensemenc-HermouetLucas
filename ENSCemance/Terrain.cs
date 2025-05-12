public class Terrain
{
    public float temperature;
    public float humidite;
    public float luminosite;
    public float nutrition;
    private List<Intru> intruPossible;
    private List<Maladie> maladiePossible;
    private string typeTerrain;
    public float indiceTemp;
    public float indiceHum;
    public float indiceLum;
    public float indiceNutrition;
    private int taillePotager;
    private List<List<Plante>> potager;
}