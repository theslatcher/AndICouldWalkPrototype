using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FloorType
{
    Grass,
    Concrete,
    Count
}

public class FloorDetector : MonoBehaviour
{
    public AudioClip myGrassClip;
    public AudioClip myConcreteClip;

    private TerrainDetector myTerrainDetector;

    void Start()
    {
        enabled = false;
    }

    public FloorType DetectFloorType(Vector3 aPosition)
    {
        //Make use of myTerrainDetector if terrain.

        return FloorType.Grass;
    }

    public AudioClip GetAudio(FloorType aFloor)
    {
        switch (aFloor)
        {
            case FloorType.Grass:
                return myGrassClip;
            case FloorType.Concrete:
                return myConcreteClip;
            default:
                return null;
        }
    }

}
