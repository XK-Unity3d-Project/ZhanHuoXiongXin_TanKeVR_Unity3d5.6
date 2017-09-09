using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class XKSpawnParticle : MonoBehaviour
{
    class ParticleDt
    {
        public GameObject ParticleObject;
        public DestroyThisTimed DestroyThisCom;
    }
    List<ParticleDt> ParticleDtList = new List<ParticleDt>();
    DestroyThisTimed FindeParticleManageFromList(GameObject particleObj)
    {
        try
        {
            ParticleDt particleDt = ParticleDtList.Find(
                delegate (ParticleDt objTmp)
                {
                    return objTmp.ParticleObject.name == particleObj.name;
                });
            if (particleDt != null)
            {
                return particleDt.DestroyThisCom;
            }
            else
            {
                return null;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Unity: -> " + ex);
            throw;
        }
    }
    public GameObject SpawnParticleObject(GameObject particleObj, Vector3 pos, Quaternion rot)
    {
        DestroyThisTimed destroyThisCom = FindeParticleManageFromList(particleObj);
        if (destroyThisCom == null)
        {
            ParticleDt particleDt = new ParticleDt();
            GameObject obj = (GameObject)Instantiate(particleObj, pos, rot);
            destroyThisCom = obj.GetComponent<DestroyThisTimed>();
            obj.name = particleObj.name;
            particleDt.ParticleObject = obj;
            particleDt.DestroyThisCom = destroyThisCom;
            ParticleDtList.Add(particleDt);
            destroyThisCom.Init();
        }
        else
        {
            destroyThisCom.transform.position = pos;
            destroyThisCom.transform.rotation = rot;
        }
        destroyThisCom.PlayGamePartidle();
        return destroyThisCom.gameObject;
    }
}