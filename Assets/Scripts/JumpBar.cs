using UnityEngine;
using UnityEngine.UI;

public class JumpBar : MonoBehaviour
{
    [SerializeField] private Jump playerJumps;
    [SerializeField] private Image jumpBarTotal;
    [SerializeField] private Image jumpBarCurrent;

    // Start is called before the first frame update
    void Start()
    {
        jumpBarCurrent.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        jumpBarTotal.fillAmount = 1 - (playerJumps.currentJumps / playerJumps.getMaxJumps);   
    }
}
