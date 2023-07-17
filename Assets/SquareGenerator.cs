using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{
    Mesh mesh;
    int squareNumber;
    public Color squareColor;
    Vector3 position;
    int row;
    int col;

    public Square(int squareNumber, Mesh mesh)
    {
        this.squareNumber = squareNumber;
        this.mesh = mesh;
        squareColor = (squareNumber / 8 + squareNumber % 8) % 2 == 0 ? Color.black : Color.white;
        row = squareNumber / 8;
        col = squareNumber % 8;
        position = new Vector3(col - 4.5f, row - 4.5f, 0f);
    }

    public void ConstrucMesh() 
    {
        Vector3[] vertices = new Vector3[4];
        
        vertices[0] = position + Vector3.up;
        vertices[1] = position + Vector3.right + Vector3.up;
        vertices[2] = position;
        vertices[3] = position + Vector3.right;

        int[] triangles = new int[] { 0, 3, 2, 0, 1, 3};

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
