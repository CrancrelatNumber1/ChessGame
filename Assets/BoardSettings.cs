using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BoardSettings : ScriptableObject
{
    public float squareSize = 1f;
    public Color lightColor = Color.white;
    public Color darkColor = Color.black;
}
