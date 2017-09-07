using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XKCalculateGunPosCtrl : MonoBehaviour
{
    public Vector2 WidthVec = new Vector2(-10f, 10f);
    public Vector2 HeightVec = new Vector2(-10f, 10f); //x -> min, y -> max.
    float DisVal = 10f;
    /// <summary>
    /// 计算枪的正朝向.
    /// </summary>
    public Vector3 CalculateGunForwardVec(PlayerEnum playerSt)
    {
        Vector3 screenPos = pcvr.GetPlayerMousePos(playerSt);
        Vector3 forwardVec = Vector3.forward * DisVal;
        //forwardVec.x -> width, forwardVec.y -> height.
        forwardVec.x = (screenPos.x / XkGameCtrl.ScreenWidth) * (WidthVec.y - WidthVec.x) + WidthVec.x;
        forwardVec.y = (screenPos.y / XkGameCtrl.ScreenHeight) * (HeightVec.y - HeightVec.x) + HeightVec.x;
        return forwardVec.normalized;
    }
}