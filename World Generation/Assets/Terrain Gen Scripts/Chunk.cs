using UnityEngine;
using System.Collections;


//Chunk's tasks are to store the data of their contents and create a mesh of the contained voxels for rendering and collisions.
//This is attached to the chunk object


//Forces whatever it is attached to to have these components. In this case, it is the chunk object which spawns a bunch of voxels. All these voxels will now have these three components!
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]



public class Chunk : MonoBehaviour
{
    //OMFG I spent an hour and a half trying to figure out what the hell was wrong because this was set to private!!! 
   //  "blocks" is a three dimensional array of Block classes, this way the Block class can store all the information we need about block type, meta data, etc. in the Block class.
    public Block[, ,] blocks = new Block[chunkSize, chunkSize, chunkSize];
    
    //chunks are 16x16 cubes
    public static int chunkSize = 16;
    
   // flag that this chunk has been changed and will need to be updated at the end of the frame. 
    public bool update = true;
    
    //reference to other scripts
    public World world;
    public WorldPos pos;

    //The visible part and collider for the voxels
    MeshFilter filter;
    MeshCollider coll;

    // Use this for initialization
    void Start()
    {
       //Lets us work with two of the components we added
        filter = gameObject.GetComponent<MeshFilter>();
        coll = gameObject.GetComponent<MeshCollider>();

        
    }

    //Update is called once per frame
    void Update()
    {
        if (update)
        {
            update = false;
            UpdateChunk();
        }
    }

    public Block GetBlock(int x, int y, int z)
    {
        if (InRange(x) && InRange(y) && InRange(z))
            return blocks[x, y, z];
        return world.GetBlock(pos.x + x, pos.y + y, pos.z + z);
    }

    public static bool InRange(int index)
    {
        if (index < 0 || index >= chunkSize)
            return false;

        return true;
    }

    //sets the block in the position described to the block provided and if it's not in range sends it to the world script.
    public void SetBlock(int x, int y, int z, Block block)
    {
        if (InRange(x) && InRange(y) && InRange(z))
        {
            blocks[x, y, z] = block;
        }
        else
        {
            world.SetBlock(pos.x + x, pos.y + y, pos.z + z, block);
        }
    }

    // Updates the chunk based on its contents
    // loops through all it's blocks building a 3d mesh based on their presence and types and then sends it to RenderMesh (next function down) which will send all our mesh data into the unity components.
    void UpdateChunk()
    {

        MeshData meshData = new MeshData();

        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                for (int z = 0; z < chunkSize; z++)
                {
                    meshData = blocks[x, y, z].Blockdata(this, x, y, z, meshData);
                }
            }
        }

        RenderMesh(meshData);
    }

    // Sends the calculated mesh information
    // to the mesh and collision components
    void RenderMesh(MeshData meshData)
    {
        filter.mesh.Clear();
        filter.mesh.vertices = meshData.vertices.ToArray();
        filter.mesh.triangles = meshData.triangles.ToArray();
        filter.mesh.uv = meshData.uv.ToArray();
        filter.mesh.RecalculateNormals();

        coll.sharedMesh = null;
        Mesh mesh = new Mesh();
        mesh.vertices = meshData.colVertices.ToArray();
        mesh.triangles = meshData.colTriangles.ToArray();
        mesh.RecalculateNormals();

        coll.sharedMesh = mesh;
    }

}