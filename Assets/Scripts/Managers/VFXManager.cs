using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    public List<VisualEffect> vfxList = new List<VisualEffect>();

    private float _lifetime = 3f;

    public void PlayVfx(VfxType vfxType, Vector3 position)
    {
        foreach(var effect in vfxList)
        {
            if (effect.vfxType == vfxType)
            {
                var x = Instantiate(effect.particleSystem, position, Quaternion.identity);
                x.Play();
                Destroy(x.gameObject, _lifetime);
                break;
            }
        }
    }
}

public enum VfxType
{
    Jump,
    Collect
}

[System.Serializable]
public class VisualEffect
{
    public VfxType vfxType;
    public ParticleSystem particleSystem;
}