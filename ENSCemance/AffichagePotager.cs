public class AffichagePotager
{
    public int taillePotager; //récupérer les valeur dans Terrain
    public List<Plante> potager;//récupérer les valeur dans Terrain
    public int positionCurseur;//récupérer les valeur dans jeu/Terrain
    public List<Dictionary<int, List<string>>> emplacement = new List<Dictionary<int, List<string>>>();

    public Dictionary<int, List<string>> tomate = new Dictionary<int, List<string>>()
    {
        {9,["tomate"]},
        {0,["                     ",
        "    ║          ║     ",
        "    ║          ║     ",
        "    ║          ║     ",
        "    ║          ║     ",
        "   ░║          ║     ",
        "   ▒║       ░ ▒║     ",
        "  ▒ ║        ▒ ║     "
        ]},
       {1,["                     ",
        "    ║          ║     ",
        "    ║          ║     ",
        "    ║          ║     ",
        "   ░║▒         ║▒    ",
        "   ░▒ ░       ░▒ ░   ",
        "   ▒║       ░ ▒║     ",
        "  ▒ ║        ▒ ║     "
        ]},
        {2,["                     ",
        "    ║          ║     ",
        "    ║▒ ░       ║▒    ",
        "    ║ ▒        ║ ▒   ",
        "   ░║▒         ║▒    ",
        "   ░▒ ░       ░▒ ░   ",
        "   ▒║       ░ ▒║     ",
        "  ▒ ║        ▒ ║     "
        ]},
        {3,[" ▄░          ░       ",
        "  ▀▒║        ▀▒║     ",
        "    ║▒ ░▄      ║▒ ░  ",
        "    ║ ▒        ║ ▒▄  ",
        "  ▄░║▒        ░║▒    ",
        "   ░▒ ░       ░▒ ░▀  ",
        " ░ ▒║         ▒║     ",
        " ▀▒ ║       ▀▒ ║     "
        ]},
        {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},

    };
    public Dictionary<int, List<string>> pimentEspelette = new Dictionary<int, List<string>>()
{
    {9,["pimentEspelette"]},
    {3,[
        "                     ",
        "  ─────      ─────   ",
        " ░▒▒▒▒▒░    ░▒▒▒▒▒░  ",
        " ░▀▄▀░▄║░  ░░▄║▀▄▀░  ",
        " ║ █║█  ║   ║ █║█ ║  ",
        "   ░█          █░    ",
        "     █░      ░█      ",
        "    █          █     "
    ]},
    {2,[
        "                     ",
        "  ─────      ─────   ",
        "  ░░░░░      ░░░░░   ",
        " ░▀▄▀░▄     ░▄░▀▄▀░  ",
        "   █ █        █ █    ",
        "   ░█          █░    ",
        "     █░      ░█      ",
        "    █          █     "
    ]},
    {1,[
        "                     ",
        "                     ",
        "     ░░       ░░░    ",
        "   ░░█░░     ░▀▄▀░   ",
        "   █ █        █ █    ",
        "   ░█          █░    ",
        "     █░      ░█      ",
        "    █          █     "
    ]},
    {0,[
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "   ░█          █░    ",
        "     █░       █      ",
        "    █          █     "
    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> pimentFoudre = new Dictionary<int, List<string>>()
{
    {9,["pimentFoudre"]},
    {3,[
        "                     ",
        "  ─────      ─────   ",
        " ░▒▒▒▒▒░    ░▒▒▒▒▒░  ",
        " ░▀▄▀░▄║░  ░░▄║▀▄▀░  ",
        " ║ █║█  ║   ║ █║█ ║  ",
        "   ░█          █░    ",
        "     █░      ░█      ",
        "    █          █     "
    ]},
    {2,[
        "                     ",
        "  ─────      ─────   ",
        "  ░░░░░      ░░░░░   ",
        " ░▀▄▀░▄     ░▄░▀▄▀░  ",
        "   █ █        █ █    ",
        "   ░█          █░    ",
        "     █░      ░█      ",
        "    █          █     "
    ]},
    {1,[
        "                     ",
        "                     ",
        "     ░░       ░░░    ",
        "   ░░█░░     ░▀▄▀░   ",
        "   █ █        █ █    ",
        "   ░█          █░    ",
        "     █░      ░█      ",
        "    █          █     "
    ]},
    {0,[
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "   ░█          █░    ",
        "     █░       █      ",
        "    █          █     "
    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> chouGeant = new Dictionary<int, List<string>>()
{
    {9,["chouGeant"]},
    {3,[
        "                     ",
        "    ░    ░░░    ░    ",
        " ▒░░  ▒░░░▒░░░▒  ░░▒ ",
        "▒██▒ ▒██▒▒█▒▒██▒ ▒██▒",
        "▒█▒██ ▒█▒███▒█▒ ██▒█▒",
        " ▒▒██ ▒▒█████▒▒ ██▒▒ ",
        "  ▒███ ▒█████▒ ███▒  ",
        "   ▒▒███████████▒▒   "
    ]},
    {2,[
        "                     ",
        "    ░    ░░░         ",
        " ▒░░  ▒░░░▒░░░▒      ",
        "▒██▒ ▒██▒▒█▒▒██▒     ",
        "▒█▒██ ▒█▒███▒█▒      ",
        " ▒▒██ ▒▒█████▒▒      ",
        "  ▒███ ▒█████▒       ",
        "   ▒▒██████████      "
    ]},
    {1,[
        "                     ",
        "         ░░░         ",
        "      ▒░░░▒░░░▒      ",
        "     ▒██▒▒█▒▒██▒     ",
        "      ▒█▒███▒█▒      ",
        "      ▒▒█████▒▒      ",
        "       ▒█████▒       ",
        "      █████████      "
    ]},
    {0,[
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "         ░░░         ",
        "      ▒░░░▒░░░▒      ",
        "     ▒██▒▒█▒▒██▒     ",
        "      █████████      "
    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> goyave = new Dictionary<int, List<string>>()
{
    {9,["goyave"]},
    {3,[
        "                     ",
        "  ░░░░░░░     ░░░░░░ ",
        " ░▒▒▒▒o▒▒░   ░▒▒▒▒o▒░",
        "░▒o▀▄▒█▀o▒░ ░▒o▀▄▒█▀░",
        "     █▀          █▀  ",
        "     █           █   ",
        "     █           █   ",
        "    ▄█          ▄█▄▄ "
    ]},
    {2,[
        "                     ",
        "                     ",
        "  ░░░░░░░     ░░░░░░ ",
        " ░░▀▄▒█▀░░   ░░▀▄▒█░░",
        "     █▀          █▀  ",
        "     █           █   ",
        "     █           █   ",
        "    ▄█          ▄█▄▄ "
    ]},
    {1,[
        "                     ",
        "                     ",
        "                     ",
        "    ░░░░       ░░░░  ",
        "   ░░█▀░░     ░░▄░█░ ",
        "     █           █   ",
        "     █           █   ",
        "    ▄█          ▄█▄  "
    ]},
    {0,[
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "     ░░         ░░   ",
        "   ░░█░░       ░░█░  ",
        "     █           █   ",
        "     █          ▄█   "
    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> pasteque = new Dictionary<int, List<string>>()
{
    {9,["pasteque"]},
    {3,[
        "                     ",
        "        ______       ",
        "       ║      ║ ▒    ",
        " ▄█▒██▒██▒█▄   ║     ",
        "██▒███▒███▒█▄  ║     ",
        "██▒███▒███▒██ ▒║ ▒   ",
        "██▒███▒███▒██   ║    ",
        " ▀█▒██▒██▒█▀    ║    "

    ]},
    {2,[
        "                     ",
        "        ______       ",
        "              ║ ▒    ",
        "               ║     ",
        "               ║     ",
        "              ▒║ ▒   ",
        "                ║    ",
        "                ║    "
    ]},
    {1,[
        "                     ",
        "                     ",
        "                ▒    ",
        "               ║     ",
        "               ║     ",
        "              ▒║ ▒   ",
        "                ║    ",
        "                ║    "

    ]},
    {0,[
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "              ▒║ ▒   ",
        "                ║    ",
        "                ║    "
    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> citrouille = new Dictionary<int, List<string>>()
{
    {9,["citrouille"]},
    {3,[
        "                     ",
        "        ______       ",
        "       ║      ║ ▒    ",
        " ▄█████████▄   ║     ",
        "███ ▀███ ▀██▄  ║     ",
        "█████████████ ▒║ ▒   ",
        "████▄▀▄▀▄▀███   ║    ",
        " ▀█████████▀    ║    "


    ]},
    {2,[
        "                     ",
        "        ______       ",
        "              ║ ▒    ",
        "               ║     ",
        "               ║     ",
        "              ▒║ ▒   ",
        "                ║    ",
        "                ║    "
    ]},
    {1,[
        "                     ",
        "                     ",
        "                ▒    ",
        "               ║     ",
        "               ║     ",
        "              ▒║ ▒   ",
        "                ║    ",
        "                ║    "

    ]},
    {0,[
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "              ▒║ ▒   ",
        "                ║    ",
        "                ║    "
    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> lumombre = new Dictionary<int, List<string>>()
{
    {9,["lumombre"]},
    {3,[
"                     ",
" ▒████▒ ▒████▒ ▒████▒",
"  ██▒█▄  ██▒█▄  ▄█▒██",
"   ║██║   ║██║  ║██║ ",
"     ║█║  ║█║    ║█║ ",
"      ║    ║      ║  ",
"       ║  ║       ║  ",
"       ~  ~        ~ "



    ]},
    {2,[
"                     ",
"                     ",
"  ██▒█▄  ██▒█▄  ▄█▒██",
"   ║██║   ║██║  ║██║ ",
"     ║█║  ║█║    ║█║ ",
"      ║    ║      ║  ",
"       ║  ║       ║  ",
"       ~  ~        ~ "

    ]},
    {1,[
"                     ",
"                     ",
"                     ",
"   ║██║   ║██║  ║██║ ",
"     ║█║  ║█║    ║█║ ",
"      ║    ║      ║  ",
"       ║  ║       ║  ",
"       ~  ~        ~ "


    ]},
    {0,[
"                     ",
"                     ",
"                     ",
"                     ",
"     ║█║  ║█║    ║█║ ",
"      ║    ║      ║  ",
"       ║  ║       ║  ",
"       ~  ~        ~ "

    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> pimentGivreux = new Dictionary<int, List<string>>()
{
    {9,["pimentGivreux"]},
    {3,[
        "                     ",
        "  ─────      ─────   ",
        " ░▒▒▒▒▒░    ░▒▒▒▒▒░  ",
        " ░▀▄▀░▄║░  ░░▄║▀▄▀░  ",
        " ║ █║█  ║   ║ █║█ ║  ",
        "   ░█          █░    ",
        "     █░      ░█      ",
        "    █          █     "
    ]},
    {2,[
        "                     ",
        "  ─────      ─────   ",
        "  ░░░░░      ░░░░░   ",
        " ░▀▄▀░▄     ░▄░▀▄▀░  ",
        "   █ █        █ █    ",
        "   ░█          █░    ",
        "     █░      ░█      ",
        "    █          █     "
    ]},
    {1,[
        "                     ",
        "                     ",
        "     ░░       ░░░    ",
        "   ░░█░░     ░▀▄▀░   ",
        "   █ █        █ █    ",
        "   ░█          █░    ",
        "     █░      ░█      ",
        "    █          █     "
    ]},
    {0,[
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "                     ",
        "   ░█          █░    ",
        "     █░       █      ",
        "    █          █     "
    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> calyxia = new Dictionary<int, List<string>>()
{
    {9,["calyxia"]},
    {3,[
        "                     ",
"   ░▒▒▒▒▒▒▒▒▒▒▒▒▒▒░  ",
"  ░▒0▒▒█▒█0▒▒0▒▄▀▒▒░ ",
"   ░▒0▀▄█ ██▒▄▀▒0▒░  ",
"     ░░░ ███  ░░░░   ",
"        ███▄         ",
"        ████         ",
"     ▄▄█████▄▄       "

    ]},
    {2,[
        "                     ",
"      ░░░░░  ░░░░    ",
"   ░░▒▒█▒█░░░░▒▄░░░░ ",
"     ░▀▄█ ██▒▀▒░▒░   ",
"         ███         ",
"        ███▄         ",
"        ████         ",
"     ▄▄█████▄▄       "

    ]},
    {1,[
        "                     ",
"                     ",
"        ░░░░░░░      ",
"     ░░░█ ██▒▄▀░░░   ",
"     ░░░ ███  ░░░░   ",
"         ██▄         ",
"        ███          ",
"      ▄█████▄▄       "

    ]},
    {0,[
        "                     ",
"                     ",
"                     ",
"                     ",
"       ░░░░░░        ",
"     ░░░██▄░░░       ",
"         ██          ",
"       ▄███▄▄        "

    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> racineDeFer = new Dictionary<int, List<string>>()
{
    {9,["racineDeFer"]},
    {3,[
"                     ",
"       ~  ~        ~ ",
"       ║  ║       ║  ",
"      ║    ║      ║  ",
"     ║█║  ║█║    ║█║ ",
"   ║██║   ║██║  ║██║ ",
"  ██▒█▄  ██▒█▄  ▄█▒██",
" ▒████▒ ▒████▒ ▒████▒"

    ]},
    {2,[
"                     ",
"                     ",
"                     ",
"                     ",
"     ║█║  ║█║    ║█║ ",
"   ║██║   ║██    ██║ ",
"  ██░█▄  ██░█▄  ▄█░██",
" ▒████▒ ▒████▒ ▒████▒"

    ]},
    {1,[
"                     ",
"                     ",
"                     ",
"                     ",
"                     ",
"   ║██    ║██    ██║ ",
"  ██░█▄   █░█▄  ▄█░██",
" ▒████▒  ▒███▒  ▒███▒"


    ]},
    {0,[
"                     ",
"                     ",
"                     ",
"                     ",
"                     ",
"                     ",
"  █░█     █░█▄  ▄█░█ ",
" ▒███▒   ▒███▒  ▒███▒"


    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> mauvaiseHerbe1 = new Dictionary<int, List<string>>()
{
    {9,["mauvaiseHerbe1"]},
    {0,[
"                     ",
"                     ",
"   ░          ░      ",
"  ▒  ░     ▒  ░   ▒  ",
"  ▒ ▒  ▒  ▒    ▒ ▒   ",
"   █  █  ██   ░██    ",
"    ███░ ██   ██     ",
"   ░█████████████░   "


    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};
    public Dictionary<int, List<string>> mauvaiseHerbe2 = new Dictionary<int, List<string>>()
{
    {9,["mauvaiseHerbe2"]},
    {0,[
"   ░▒▒        ░░░    ",
"      ▒▒    ▒▒       ",
"        ▒███     ░░  ",
"   ▒░▒▒█░█▒█▒▒░▒▒    ",
" ░░    ▒█████        ",
"     ▒▒ █▒██ ▒▒      ",
"      ▒       ░      ",
"    ░░▒        ▒▒░   "



    ]},
    {4,["        ░▒░░▒▒       ",
        "      ▒░      ▒░     ",
        "    ▒▒   ████▄  ▒▒   ",
        "   ▒▒   █    █   ▒░  ",
        "  ░▒▒   █ █  ░░  ░░░ ",
        "   ▒▒    ██  ▄█   ░░░",
        "    ▒▒▄▄▄  ▄░█   ░░░ ",
        "      ███░░█    ░░░  "
        ]},
};

    public Dictionary<string, ConsoleColor> couleurApproprie = new Dictionary<string, ConsoleColor>()
    {
        {"tomate",ConsoleColor.Red},
        {"pimentEspelette",ConsoleColor.DarkRed},
        {"chouGeant",ConsoleColor.DarkGreen},
        {"pimentFoudre",ConsoleColor.Yellow},
        {"goyabe",ConsoleColor.Red},
        {"pasteque",ConsoleColor.Green},
        {"citrouille",ConsoleColor.DarkYellow},
        {"lumombre",ConsoleColor.DarkGray},
        {"pimentGivreux",ConsoleColor.Blue},
        {"calyxia",ConsoleColor.DarkGreen},
        {"racineDeFer",ConsoleColor.DarkGray},
        {"mauvaiseHerbe1",ConsoleColor.DarkGreen},
        {"mauvaiseHerbe2",ConsoleColor.DarkYellow}
    };
    public Dictionary<string, Dictionary<int, List<string>>> dictionnaire;

    public AffichagePotager()
    {
        dictionnaire = new Dictionary<string, Dictionary<int, List<string>>>()
        {
            { "tomate", tomate }, // a compléter avec le reste des trucs
            { "pimentEspelette", pimentEspelette },
            { "chouGeant", chouGeant },
            { "pimentFoudre", pimentFoudre },
            { "goyave", goyave },
            { "pasteque", pasteque },
            { "citrouille", citrouille },
            { "lumombre", lumombre },
            { "pimentGivreux", pimentGivreux },
            { "calyxia", calyxia },
            { "racineDeFer", racineDeFer },
            { "mauvaiseHerbe1", mauvaiseHerbe1 },
            { "mauvaiseHerbe2", mauvaiseHerbe2 }
        };


        for (int i = 0; i < this.potager.Count(); i++)
        {
            emplacement.Add(dictionnaire[this.potager[i].Nom]);//permet d'ajouter la liste/image correspondante
        }
    }
    public void AffichageComplet()
    {
        bool curseur = false;
        for (int i = 0; i < this.taillePotager; i++)
        {
            for (int entier = 0; entier < 9; entier++)
            {
                for (int j = 0; j < this.taillePotager; j++)
                {
                    if (positionCurseur == j + i * this.taillePotager)
                    {
                        curseur = true;
                    }
                    else
                    {
                        curseur = false;
                    }
                    Dictionary<int, List<string>> planteActuel = emplacement[j + i * this.taillePotager];
                    List<string> etatDeViePlante = planteActuel[this.potager[j + i * this.taillePotager].etapeDeVie];
                    plante(entier, curseur, etatDeViePlante, couleurApproprie[etatDeViePlante[0]], this.potager[j + i * this.taillePotager].Maladies);
                    Console.WriteLine();
                }
            }
        }
        Console.Write("Plante : " + this.potager[positionCurseur].Nom);

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(" Besoin température : " + this.potager[positionCurseur].besoinTemp);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(" Besoin humidité : " + this.potager[positionCurseur].besoinEau);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" Besoin luminosité : " + this.potager[positionCurseur].besoinLumi);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" Besoin nutrition : " + this.potager[positionCurseur].besoinNutritif);

        Console.WriteLine();
    }
    public void plante(int ligne, bool curseur, List<string> terrain, ConsoleColor couleur, List<Maladie> maladie)
    {
        if (ligne == 0)
        {
            if (curseur)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (maladie.Count() != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.Write("┼────────────────────┼");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (ligne == 9)
        {
            if (curseur)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (maladie.Count() != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.Write("┼────────────────────┼");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            if (curseur)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (maladie.Count() != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.Write("|");
            Console.ForegroundColor = couleur; // différent pour chaque terrain
            Console.Write(terrain[ligne]);
            if (curseur)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (maladie.Count() != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
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

