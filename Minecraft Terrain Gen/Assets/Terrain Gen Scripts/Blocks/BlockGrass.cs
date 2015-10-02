using UnityEngine;
using System.Collections;

public class BlockGrass : Block
{
    //A block of Grass
    public BlockGrass()
        : base()
    {

    }

    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();

        switch (direction)
        {
            case Direction.up:
                tile.x = 2;
                tile.y = 0;
                return tile;
            case Direction.down:
                tile.x = 1;
                tile.y = 0;
                return tile;
        }

        // textures the blocks using the grid numbers on the texture. 3,0 is grass. Up and down ^^ gets the top and bottom texture, respectively.
        tile.x = 3;
        tile.y = 0;

        return tile;
    }
}
