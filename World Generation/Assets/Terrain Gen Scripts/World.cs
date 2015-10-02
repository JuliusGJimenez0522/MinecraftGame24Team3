using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class World : MonoBehaviour {

    // Basically this and the WorldPos script stores the chunks in a dictionary for loading and reloading, if we were doing infinite world generation...
    // for now this just controls the spawning of our world.

    //defines a dictionary with WorldPos as the key and Chunk as the value. 
    //We can use this to store as many chunks as we want in any position and out methods will look them up based on their positions.
    public Dictionary<WorldPos, Chunk> chunks = new Dictionary<WorldPos, Chunk>();

    //Our one and only world generation game object, an empty game object with the chunk script attached to it.
    public GameObject chunkPrefab;


	// Use this for initialization
	void Start () 
    {
        //This is what generates the world. Do not set the values greater than 8 because while it generates huge worlds the computer will likely throw a fit...

        for (int x = -6; x < 6; x++)
        {
            for (int y = -1; y < 3; y++)
            {
                for (int z = -6; z < 6; z++)
                {
                    CreateChunk(x * 16, y * 16, z * 16);
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void CreateChunk(int x, int y, int z)
    {
        //the coordinates of this chunk in the world
        WorldPos worldPos = new WorldPos(x, y, z);

        //Instantiate the chunk at the coordinates using the chunk prefab
        GameObject newChunkObject = Instantiate(
                        chunkPrefab, new Vector3(worldPos.x, worldPos.y, worldPos.z),
                        Quaternion.Euler(Vector3.zero)
                    ) as GameObject;

        //Get the object's chunk component
        Chunk newChunk = newChunkObject.GetComponent<Chunk>();

        //Assign its values
        newChunk.pos = worldPos;
        newChunk.world = this;

        //Add it to the chunks dictionary with the position as the key
        chunks.Add(worldPos, newChunk);

        //now spawn me some test chunks!
        var terrainGen = new TerrainGen();
        newChunk = terrainGen.ChunkGen(newChunk);

       // newChunk.SetBlocksUnmodified();

        //bool loaded = Serialization.Load(newChunk);
    }
    // I *think* this is unused as well, it seems to be related to the storing of unused chunks...
    public Chunk GetChunk(int x, int y, int z)
    {
        WorldPos pos = new WorldPos();
        float multiple = Chunk.chunkSize;
        pos.x = Mathf.FloorToInt(x / multiple) * Chunk.chunkSize;
        pos.y = Mathf.FloorToInt(y / multiple) * Chunk.chunkSize;
        pos.z = Mathf.FloorToInt(z / multiple) * Chunk.chunkSize;

        Chunk containerChunk = null;

        chunks.TryGetValue(pos, out containerChunk);

        return containerChunk;
    }
    //If its not any other block, it must be not so empty air!
    public Block GetBlock(int x, int y, int z)
    {
        Chunk containerChunk = GetChunk(x, y, z);

        if (containerChunk != null)
        {
            Block block = containerChunk.GetBlock(
                x - containerChunk.pos.x,
                y - containerChunk.pos.y,
                z - containerChunk.pos.z);

            return block;
        }
        else
        {
            return new BlockAir();
        }

    }

    public void SetBlock(int x, int y, int z, Block block)
    {
        Chunk chunk = GetChunk(x, y, z);

        if (chunk != null)
        {
            chunk.SetBlock(x - chunk.pos.x, y - chunk.pos.y, z - chunk.pos.z, block);
            chunk.update = true;

           
            //What this does is check if value1 and value 2 are equal and if so update the chunk containing the position.
            
            UpdateIfEqual(x - chunk.pos.x, 0, new WorldPos(x - 1, y, z));
            UpdateIfEqual(x - chunk.pos.x, Chunk.chunkSize - 1, new WorldPos(x + 1, y, z));
            UpdateIfEqual(y - chunk.pos.y, 0, new WorldPos(x, y - 1, z));
            UpdateIfEqual(y - chunk.pos.y, Chunk.chunkSize - 1, new WorldPos(x, y + 1, z));
            UpdateIfEqual(z - chunk.pos.z, 0, new WorldPos(x, y, z - 1));
            UpdateIfEqual(z - chunk.pos.z, Chunk.chunkSize - 1, new WorldPos(x, y, z + 1));
        }
    }

    //What this does is check if value1 and value 2 are equal and if so update the chunk containing the position.
   
    void UpdateIfEqual(int value1, int value2, WorldPos pos)
    {
        if (value1 == value2)
        {
            Chunk chunk = GetChunk(pos.x, pos.y, pos.z);
            if (chunk != null)
                chunk.update = true;
        }
    }
    //Unused
    public void DestroyChunk(int x, int y, int z)
    {
        Chunk chunk = null;
        if (chunks.TryGetValue(new WorldPos(x, y, z), out chunk))
        {
            Object.Destroy(chunk.gameObject);
            chunks.Remove(new WorldPos(x, y, z));
        }
    }




}
