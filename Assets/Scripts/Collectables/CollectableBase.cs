using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    [SerializeField] private bool _disableOnCollect = false;

    [Header("Sounds")]
    public AudioSource audioSource;

    [SerializeField] private string compareTag = "Player";
    [SerializeField] private float _destroyDelay = 5.0f;

    private bool _collect = false;

    private void Update()
    {
        if (_collect)
        {
            this.transform.position = Vector3.Lerp(transform.position, PlayerInput.instance.transform.position, .1f);
            if (Vector3.Distance(transform.position, PlayerInput.instance.transform.position) < 0.7f)
                HideObject();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(compareTag))
            OnCollect();
    }

    protected void Collect()
    {
        _collect = true;

        var collider = this.GetComponent<Collider>();

        if (collider != null) 
            collider.enabled = false;

        VFXManager.instance?.PlayVfx(VfxType.Collect, this.transform.position);

        if (audioSource != null)
            audioSource.Play();

        if (_disableOnCollect)
            HideObject();

        Destroy(gameObject, _destroyDelay);
    }

    protected virtual void OnCollect()
    {
        Collect();
    }

    private void HideObject()
    {
        this.gameObject.SetActive(false);
    }
}
