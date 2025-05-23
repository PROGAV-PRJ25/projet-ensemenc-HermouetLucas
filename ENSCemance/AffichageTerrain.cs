public class AffichageTerrain
{
    public int tailleJardin; //récupérer les valeur dans jeu
    public List<Terrain> jardin;//récupérer les valeur dans jeu
    public int positionCurseur;//récupérer les valeur dans jeu
    public int annee;
    public int mois;
    public int semaine;

    public List<List<string>> emplacement = new List<List<string>>();

    public List<string> volcanique = new List<string>()
    {
        "volcanique",
        "    ░░░░░░░░░░░░░    " ,
        "     ░░░░░░░░░░░     " ,
        "      ░░░░░░░░░      " ,
        "        ░░░░░        " ,
        "      ▄███████▄      " ,
        "    ▄███████████▄    " ,
        "  ▄███████████████▄  " ,
        "▄███████████████████▄"
    };
    public List<string> oceanique = new List<string>()
    {
        "oceanique",
        "     ~  /|    ~   ~  " ,
        " ~    _/./ ~    ~   ~" ,
        "   ,-'    `-:..-'/   " ,
        "  : o )      _  (    " ,
        "   `-....,--; `-.|   " ,
        " ~    `'  ~    ~     " ,
        " ><(((º>   ><((º>    " ,
        "   ~     ~      ~    "
    };
    public List<string> desertique = new List<string>()
    {
        "desertique",
        @"      _  _      \|/  " ,
         "     |█||█| _   -█-  " ,
        @"    -|█||█||█|  /|\  " ,
         "     |█||█||█|-      " ,
        @"      \█ █||█|       " ,
         "       -|█ █/        " ,
         "        |█|          " ,
         "▒▒▒▒▒▒▒▒|█|-▒▒▒▒▒▒▒▒▒"
    };
    public List<string> savane = new List<string>()
    {
        "savane",
        "   ▒▒▒▒▒▒▒▒▒▒▒▒      " ,
        "  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒  " ,
        "     ▒▀▄ ██▒▄▀▒      " ,
        "        ██           " ,
        "      ██             " ,
        "    ██               " ,
        "   ███  ▒    ▒▒   ▒  " ,
        "░░░░░░░░░░░░░░░░░░░░░"
    };
    public List<string> plaine = new List<string>()
    {
        "plaine",
         "  ▒▒            ▒▒▒▒ " ,
        @" ▒▒▒  \   |   /   ▒▒ " ,
        @"       \  |  /       " ,
         "     __  ███  __     " ,
         "  ▒     █████   ▒    " ,
         "░░░░░░░░░░░░░░░░░░░░░" ,
         "░░▒░░░░▒░░░░░░░░░░░░░" ,
         "░░░▒░░░░░░░▒░░░░░▒░░░"
    };
    public List<string> urbain = new List<string>()
    {
        "urbain",
        "                     " ,
        "    ▒▒▒       ▒▒▒    " ,
        "  ▒▒▒▒▒▒▒   ▒▒▒▒▒▒▒  " ,
        " ▒▒▒▒▒▒▒▒▒ ▒▒▒▒▒▒▒▒▒ " ,
        "▒█████████▒█████████▒" ,
        " █████████ █████████ " ,
        " █ .██  ██ █ .██  ██ " ,
        " █  ██████ █  ██████ "
    };
    public List<string> forestier = new List<string>()
    {
        "forestier",
        "                     " ,
        "                     " ,
        " ▒▒▒▒▒▒▒▒   ▒▒▒▒▒▒▒▒ " ,
        "▒▐▒▐▒▒▒▒▌▒ ▒▐▒▐▒▒▒▒▌▒" ,
        " ▒▀▄█▒▄▀▒   ▒▀▄█▒▄▀▒ " ,
        "    ██         ██    " ,
        "░░▄▄██▄░░░░░░▄▄██▄░░░" ,
        "░░░░░░░░░░░░░░░░░░░░░"
    };
    public List<string> glaciare = new List<string>()
    {
        "glaciare",
        "        ▒▒▒▒         " ,
        "       ▒████▒  ▒     " ,
        "   ▒  ▒██████▒▒█▒    " ,
        "  ▒█▒▒███████▒████▒  " ,
        " ▒██▒███████▒██████▒ " ,
        " ▒████████████████▒  " ,
        "~░░░░░░░░░░░░░░░░  ~ " ,
        "  ~░░░░░░░░░░░░ ~   ~"
    };
    public List<string> montagneux = new List<string>()
    {
        "montagneux",
        "                     " ,
        "         ▒▒          " ,
        "        ▒██▒         " ,
        "       ▒████▒  ▒▒    " ,
        "  ▒▒  ▒██████▒▒██▒   " ,
        " ▒██▒▒███████▒████▒  " ,
        "▒███▒███████▒██████▒ " ,
        "████████████████████▒"
    };
    public List<string> steppe = new List<string>()
    {
        "steppe",
         " ▒▒▒▒          ▒▒▒▒  " ,
         "    ▒▒▒         ▒▒▒▒ " ,
         "       ____          " ,
        @"  ____/████\  ____   " ,
        @" /████\█████\/████\ ▒" ,
         "░░░░░░░░░▒░░░░░░▒░░░░" ,
        @"░░▒░░▒░▒░░/████\░░░░░" ,
        @"░/████\▒░░░░░▒░░░▒░░░"
    };
    public List<string> marecageux = new List<string>()
    {
        "marecageux",
        "    ~            ~   " ,
        "  ~   ▒▒▒▒▒▒▒▒▒▒   ~ " ,
        "    ▒▒██████████▒    " ,
        "  ▒▒██████████████▒  " ,
        " ▒████████░████████▒ " ,
        "  ▒▒█████░ ░██████▒  " ,
        " ~  ▒████░ ░████▒   ~" ,
        "   ~  ▒▒░   ░▒▒    ~ "
    };
    public List<string> jungle = new List<string>()
    {
        "jungle",
        "     ▒▒▒▒▒▒▒▒▒▒▒▒    " ,
        "    ▒▀▄▒█▒█▒▒▒▒█▒▒   " ,
        "    ║▒▒▀▄ ██▒▄▀▒▒    " ,
        "    ║   ███ ║   ║    " ,
        "    ║  ███  ║   ║    " ,
        "    ║  ███      ║    " ,
        "▒▒▒▒   ▄███▄▒▒   ▒▒▒▒" ,
        "░░░░░░░░░░░░░░░░░░░░░"
    };

    public Dictionary<string, ConsoleColor> couleurApproprie = new Dictionary<string, ConsoleColor>()
    {
        {"volcanique",ConsoleColor.DarkRed}, // a compléter avec le reste des trucs
        {"oceanique",ConsoleColor.DarkBlue},
        {"desertique",ConsoleColor.Yellow},
        {"savane",ConsoleColor.DarkYellow},
        {"plaine",ConsoleColor.Green},
        {"urbain",ConsoleColor.Gray},
        {"forestier",ConsoleColor.DarkGreen},
        {"glaciare",ConsoleColor.DarkCyan},
        {"montagneux",ConsoleColor.DarkGray},
        {"steppe",ConsoleColor.Green},
        {"marecageux",ConsoleColor.DarkGreen},
        {"jungle",ConsoleColor.Green}
    };
    public Dictionary<string, List<string>> dictionnaire;

    public AffichageTerrain()
    {
        dictionnaire = new Dictionary<string, List<string>>()
        {
            { "volcanique", volcanique }, // a compléter avec le reste des trucs
            { "oceanique", oceanique },
            {"desertique",desertique},
            {"savane",savane},
            {"plaine",plaine},
            {"urbain",urbain},
            {"forestier",forestier},
            {"glaciare",glaciare},
            {"montagneux",montagneux},
            {"steppe",steppe},
            {"marecageux",marecageux},
            {"jungle",jungle}

        };


        for (int i = 0; i < this.jardin.Count(); i++)
        {
            emplacement.Add(dictionnaire[this.jardin[i].TypeTerrain]);//permet d'ajouter la liste/image correspondante
        }
    }
    public void AffichageComplet()
    {
        bool curseur = false;
        for (int i = 0; i < this.tailleJardin; i++)
        {
            for (int entier = 0; entier < 9; entier++)
            {
                for (int j = 0; j < this.tailleJardin; j++)
                {
                    if (positionCurseur == j + i * this.tailleJardin)
                    {
                        curseur = true;
                    }
                    else
                    {
                        curseur = false;
                    }
                    List<string> terrainActuel = emplacement[j + i * this.tailleJardin];
                    terrain(entier, curseur, terrainActuel, couleurApproprie[terrainActuel[0]]);
                    Console.WriteLine();
                }
            }
        }
        Console.Write("Terrain : " + this.jardin[positionCurseur].GetType());

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(" Indice température : " + this.jardin[positionCurseur].IndiceTemp);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(" Indice humidité : " + this.jardin[positionCurseur].IndiceTemp);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" Indice luminosité : " + this.jardin[positionCurseur].IndiceTemp);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" Indice nutrition : " + this.jardin[positionCurseur].IndiceTemp);

        Console.WriteLine();
        Console.Write("Année : " + this.annee + " Mois : " + this.mois + " Semaine : " + this.semaine);
    }
    public void terrain(int ligne, bool curseur, List<string> terrain, ConsoleColor couleur)
    {
        if (ligne == 0)
        {
            if (curseur)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            Console.Write("╭────────────────────╮");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (ligne == 9)
        {
            if (curseur)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            Console.Write("╰────────────────────╯");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            if (curseur)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            Console.Write("|");
            Console.ForegroundColor = couleur; // différent pour chaque terrain
            Console.Write(terrain[ligne]);
            if (curseur)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
