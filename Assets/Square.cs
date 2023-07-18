using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{
    Vector3 position;
    Mesh mesh;
    float size;

    public Square(Vector3 position, Mesh mesh, float size)
    {
        this.position = position;
        this.mesh = mesh;
        this.size = size;
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = {
            position,
            position + Vector3.right * size,
            position + (Vector3.right + Vector3.up) * size,
            position + Vector3.up * size
        };
        int[] triangles = { 0, 2, 1, 0, 3, 2 };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
