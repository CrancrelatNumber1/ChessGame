using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Range(1,10)]
    public float size = 1f;
    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    Square[] squares;

    public Color lightColor = Color.white;
    public Color darkColor = Color.black;

    string[] squareNames = {
        "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1",
        "A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2",
        "A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3",
        "A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4",
        "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5",
        "A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6",
        "A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7",
        "A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8"
    };

    public BoardSettings boardSettings;

    void OnValidate()
    {
        CreateGraphicalBoard();
        DrawGraphicalBoard();
        UpdateColours();
    }

    void CreateGraphicalBoard()
    {
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[64];
        }
        squares = new Square[64];

        for (int file=0; file < 8; file++)
        {
            for (int rank=0; rank < 8; rank++)
            {
                int i = rank + 8 * file;

                bool isLightSquare = (file + rank) % 2 == 0;
                
                Color squareColour = (isLightSquare) ? lightColor : darkColor;
                if (meshFilters[i] == null) {
                    GameObject squareObj = new GameObject(squareNames[i]);
                    squareObj.transform.parent = transform;

                    squareObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                    squareObj.GetComponent<MeshRenderer>().sharedMaterial.color = squareColour;

                    meshFilters[i] = squareObj.AddComponent<MeshFilter>();
                    meshFilters[i].sharedMesh = new Mesh();
                }    

                squares[i] = new Square(GetSquarePositionFromIndex(i), meshFilters[i].sharedMesh, size);
            }        
        }
    }

    void DrawGraphicalBoard() 
    {
        foreach (Square square in squares)
        {
            square.ConstructMesh();
        }
    }

    void UpdateColours()
    {
        int i = 0;
        foreach (MeshFilter m in meshFilters)
        {
            bool isLightSquare = (i % 8 + i / 8) % 2 == 0;
            m.GetComponent<MeshRenderer>().sharedMaterial.color = (isLightSquare) ? lightColor : darkColor;
            i++;
        }
    }

    Vector3 GetSquarePositionFromIndex(int index)
    {
        int file = index % 8;
        int rank = index / 8;

        return new Vector3((-3.5f + file) * size, (-3.5f + rank) * size, 0);
    }
}
