using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxAudiosource;

    public void playVFX(Vector3 spawnposition)
    {
        GameObject.Instantiate(vfxAudiosource, spawnposition, Quaternion.identity);
    }
}
