using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XKParticleCtrl : MonoBehaviour
{
    GameObject RealParticle;
    public void InitParticleInfo()
    {
        try
        {
            RealParticle = transform.GetChild(0).gameObject;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Unity: -> " + name + ": " + ex);
            throw;
        }
    }
    public void SetActiveObject(bool isActive)
    {
        RealParticle.SetActive(isActive);
    }
}