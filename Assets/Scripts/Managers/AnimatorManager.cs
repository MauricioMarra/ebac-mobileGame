using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator _animator;
    public List<AnimationSetup> animationSetups;
    public string teste;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation(AnimationType animationType, float speed = 1)
    {
        foreach (var element in animationSetups)
        {
            if (element.type == animationType)
            {
                _animator.SetTrigger(element.trigger);
                _animator.speed = speed / element.speed;
            }
        }
    }

    public enum AnimationType
    {
        Death,
        Run,
        Idle
    }
}



[System.Serializable]
public class AnimationSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
    public float speed;
}


