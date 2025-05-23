/// paramètre : name="plante">Instance de Plante à semer.
/// paramètre : name="ligne">Coordonnée ligne dans le potager.
/// paramètre : name="colonne">Coordonnée colonne dans le potager.
public void Semer(Plante plante, int ligne, int colonne)
{
    if (ligne < 0 || ligne >= DimensionPotager || colonne < 0 || colonne >= DimensionPotager)
        throw new ArgumentOutOfRangeException("Coordonnées hors potager");
    int idx = ligne * DimensionPotager + colonne;
    if (potager[idx] != null)
        throw new InvalidOperationException("La case n'est pas vide");
    potager[idx] = plante;
}


/// Récolte et retire la plante à la position (ligne, colonne).

/// paramètre : name="ligne">Coordonnée ligne dans le potager.
/// paramètre : name="colonne">Coordonnée colonne dans le potager.
/// returns : La plante récoltée, ou null si case vide.
public Plante Recolter(int ligne, int colonne)
{
    if (ligne < 0 || ligne >= DimensionPotager || colonne < 0 || colonne >= DimensionPotager)
        throw new ArgumentOutOfRangeException("Coordonnées hors potager");
    int idx = ligne * DimensionPotager + colonne;
    Plante planteRetiree = potager[idx];
    potager[idx] = null;
    return planteRetiree;
}


/// Désherbe le potager : retire toutes les mauvaises herbes.

public void Desherber()
{
    for (int i = 0; i < potager.Count; i++)
    {
        if (potager[i] != null && potager[i].MauvaiseHerbe)
            potager[i] = null;
    }
}


/// Compte le nombre de plantes actuellement dans le potager.

/// returns : Le nombre de plantes non nulles.
public int CompterPlantes()
{
    int count = 0;
    foreach (var p in potager)
        if (p != null)
            count++;
    return count;
}
