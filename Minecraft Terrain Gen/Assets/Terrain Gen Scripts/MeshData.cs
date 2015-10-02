using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//MeshData will provide us with an easy way to store mesh data. (which isn't the best of descriptions but whatever)

public class MeshData
{
    public List<Vector3> vertices = new List<Vector3>();
    public List<int> triangles = new List<int>();
    public List<Vector2> uv = new List<Vector2>();

    public List<Vector3> colVertices = new List<Vector3>();
    public List<int> colTriangles = new List<int>();

    public bool useRenderDataForCol;

    public MeshData() { }

    //Ok, so basicly voxels are made up of six squares forming a cube, and those squares are made up of two triangles. This sets up those triangles for each square.
    public void AddQuadTriangles()
    {
        // sets up the first triangle
        triangles.Add(vertices.Count - 4);
        triangles.Add(vertices.Count - 3);
        triangles.Add(vertices.Count - 2);

        //sets up the second triangle
        triangles.Add(vertices.Count - 4);
        triangles.Add(vertices.Count - 2);
        triangles.Add(vertices.Count - 1);

        if (useRenderDataForCol)
        {
            //The above set up the triangles for the collider. This does it for the renderer.
            colTriangles.Add(colVertices.Count - 4);
            colTriangles.Add(colVertices.Count - 3);
            colTriangles.Add(colVertices.Count - 2);
           
            colTriangles.Add(colVertices.Count - 4);
            colTriangles.Add(colVertices.Count - 2);
            colTriangles.Add(colVertices.Count - 1);
        }
    }
    
    public void AddVertex(Vector3 vertex)
    {
        vertices.Add(vertex);

        if (useRenderDataForCol)
        {
            colVertices.Add(vertex);
        }

    }
   
    public void AddTriangle(int tri)
    {
        triangles.Add(tri);

        if (useRenderDataForCol)
        {
            colTriangles.Add(tri - (vertices.Count - colVertices.Count));
        }
    }
}