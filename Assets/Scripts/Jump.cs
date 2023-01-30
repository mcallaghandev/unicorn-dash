using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float maxJumps;

    public float getMaxJumps => this.maxJumps;

    public float currentJumps { get; private set; }

    private void Awake()
    {
        currentJumps = 0;
    }

    public void ResetJumps() => this.currentJumps = 0;

    private void IncrementJump()
    {
        if (JumpsAreLessThanMax())
        {
            currentJumps += 1;
        }
    }

    public bool JumpsAreLessThanMax()
    {
        return this.currentJumps < this.maxJumps;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncrementJump();
        }
    }

    internal bool AreEqualToMax()
    {
        return this.currentJumps == this.maxJumps;
    }
}
