﻿using UnityEngine;
using System.Collections;

public class DestroyThisTimed : MonoBehaviour {
	[Range(0f, 100f)] public float TimeRemove = 5f;
    float TimeStart = 0f;
    bool IsParticleStop = true;
    XKParticleCtrl ParticleManage;
    void Update()
    {
        if (Time.time - TimeStart < TimeRemove || IsParticleStop)
        {
            return;
        }
        StopGameParticle();
    }
	// Use this for initialization
	public void Init()
	{
        ParticleManage = gameObject.AddComponent<XKParticleCtrl>();
        ParticleManage.InitParticleInfo();
        TimeStart = Time.time;
    }
    public void PlayGamePartidle()
    {
        if (!IsParticleStop)
        {
            return;
        }
        IsParticleStop = false;
        TimeStart = Time.time;
        ParticleManage.SetActiveObject(true);
    }
    void StopGameParticle()
    {
        IsParticleStop = true;
        ParticleManage.SetActiveObject(false);
    }
}