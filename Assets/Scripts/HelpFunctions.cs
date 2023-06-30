using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelpFunctions 
{
    public static Vector3 GetMousePosWorld(float z)
    {
        Vector3 tmpVec = MainCamera.cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        return new Vector3(tmpVec.x, tmpVec.y, z);
    }
}
