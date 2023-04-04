using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    [SerializeField] private bool _disableOnCollect = false;

    [Header("Sounds")]
    public AudioSource audioSource;

    private string playerTag = "Player";
    [SerializeField]  private float _destroyDelay = 5.0f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(playerTag)) OnCollect();
    }

    protected void Collect()
    {
        var collider = this.GetComponent<Collider>();

        if (collider != null) 
            collider.enabled = false;

        VFXManager.instance?.PlayVfx(VfxType.Collect, this.transform.position);

        if (audioSource != null)
            audioSource.Play();

        if (_disableOnCollect)
            this.gameObject.SetActive(false);

        Destroy(gameObject, _destroyDelay);
    }

    protected virtual void OnCollect()
    {
        Collect();
    }
}
