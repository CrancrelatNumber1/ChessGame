using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    MeshFilter[] meshFilters;
    Square[] squares;

    void OnValidate()
    {
        Initialize();
        GenerateMesh();
        GenerateColours();
    }

    void Initialize() 
    {
        if (meshFilters == null || meshFilters.Length == 0) {
            meshFilters = new MeshFilter[64];
        }
        squares = new Square[64];

        for (int i = 0; i < 64; i++) {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;
                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            squares[i] = new Square(i, meshFilters[i].sharedMesh);
        }
    }

    void GenerateMesh() 
    {
        for (int i = 0; i < 64; i++) {
            squares[i].ConstrucMesh();
        }
    }

    void GenerateColours()
    {
        for (int i = 0; i < 64; i++) {
            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial.color = squares[i].squareColor;
        }
    }
}
