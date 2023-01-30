using UnityEngine;

public class FlowerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField]
    private float maxHorizontalSpeed;

    [SerializeField]
    private float maxVerticalSpeed;

    private Vector2 currentVelocity;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        currentVelocity = new Vector2(maxHorizontalSpeed, maxVerticalSpeed);
        InvokeRepeating(nameof(UpdateFlowerWithRandomNewMaxVelocity), 2, 3);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = currentVelocity;
    }

    private void UpdateFlowerWithRandomNewMaxVelocity()
    {
        currentVelocity = new Vector2(Random.Range(-maxHorizontalSpeed, maxHorizontalSpeed), Random.Range(-maxVerticalSpeed, maxVerticalSpeed));
    }
}
