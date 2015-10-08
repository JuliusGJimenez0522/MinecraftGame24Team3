using UnityEngine;
using System.Collections;
using System;
//Makes leaves for the trees
[Serializable]
public class BlockLeaves : Block
{

    public BlockLeaves()
        : base()
    {

    }

    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();

        tile.x = 0;
        tile.y = 1;

        return tile;
    }

    public override bool IsSolid(Direction direction)
    {
        return false;
    }
}

