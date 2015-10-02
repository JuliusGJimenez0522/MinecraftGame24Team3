using UnityEngine;
using System.Collections;

// Basically this and the World script stores the chunks in a dictionary for loading and reloading, if we were doing infinite world generation...

// Quote Wikipedia: "Struct: a complex data type declaration that defines a physically grouped list of variables to be placed under one name in a block of memory,
    //allowing the different variables to be accessed via a single pointer, or the struct declared name which returns the same address..."
public struct WorldPos
{
    public int x, y, z;

    public WorldPos(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

   // checks if the object being compared is a WorldPos and that x, y and z are equal to this one's x, y and z. This gives us a variable for positions that can quickly be compared.
    public override bool Equals(object obj)
    {
        if (!(obj is WorldPos))
            return false;

        WorldPos pos = (WorldPos)obj;
        if (pos.x != x || pos.y != y || pos.z != z)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}