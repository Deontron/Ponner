using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPositionY : MonoBehaviour
{
    private float positionY;
    public float SetYPosition(GameObject sphere)
    {
        switch (gameObject.tag)
        {
            case "WhitePlatform":
                positionY = sphere.transform.position.y + 3.5f;
                break;

            case "BlackPlatform":
                positionY = sphere.transform.position.y + 3f;
                break;
        }
        return positionY;
    }
}
