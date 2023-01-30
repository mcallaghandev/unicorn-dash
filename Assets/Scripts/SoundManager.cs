
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip playerJump;

    [SerializeField] private AudioClip flowerCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            audioSource.PlayOneShot(flowerCollected);
        }
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(playerJump);
    }
}
