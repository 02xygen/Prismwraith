using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMaterialManager : MonoBehaviour
{
    public Material[] colors;
    public int Colorindexer(Material mat)
    {
        for (int i = 1; i < colors.Length; i++)
        {
            if (mat.color == colors[i].color)
                return i;
        }
        return 0;
    }

    public int ColorComparer(int color1, int color2)
    {
        switch (color1)
        {
            case 1:
                return color1;
            case 2:
                if (color2 == 1)
                    return color1;
                if (color2 != 5 && color2 != 6)
                    return color1 + color2;
                break;
            case 3:
                if (color2 == 1)
                    return color1;
                if (color2 != 5 && color2 != 7)
                    return color1 + color2;
                break;
            case 4:
                if (color2 == 1)
                    return color1;
                if (color2 != 6 && color2 != 7)
                    return color1 + color2;
                break;
            case 5:
                if (color2 == 1)
                    return color1;
                if (color2 != 2 && color2 != 3 && color2 != 6 && color2 != 7)
                    return color1 + color2;
                break;
            case 6:
                if (color2 == 1)
                    return color1;
                if (color2 != 2 && color2 != 4 && color2 != 5 && color2 != 7)
                    return color1 + color2;
                break;
            case 7:
                if (color2 == 1)
                    return color1;
                if (color2 != 3 && color2 != 4 && color2 != 5 && color2 != 6)
                    return color1 + color2;
                break;

        }
        return 0;
    }
}
