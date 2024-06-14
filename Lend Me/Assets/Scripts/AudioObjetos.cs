using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obt�n el componente AudioSource adjunto a este objeto
        audioSource = GetComponent<AudioSource>();

        // Verifica si el AudioSource est� presente
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this object.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Objeto"))
        {
            audioSource.Play();
        }
    }
}
