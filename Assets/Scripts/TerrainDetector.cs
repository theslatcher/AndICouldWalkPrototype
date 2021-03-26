using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDetector : MonoBehaviour
{
    void Start()
    {
        enabled = false;
    }

    public FloorType DetectFloorType(Vector3 aPosition)
    {
        return FloorType.Grass;
    }
}
