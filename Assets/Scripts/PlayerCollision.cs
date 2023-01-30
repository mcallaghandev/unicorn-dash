using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Jump playerJumps;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private ScoreManager scoreManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.SetPlayerOnFloor(true);
            this.playerJumps.ResetJumps();
        }
        else if (collision.gameObject.CompareTag("Flower"))
        {
            Destroy(collision.gameObject);
        }
    }
}
