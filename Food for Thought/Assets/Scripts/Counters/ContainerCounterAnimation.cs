using UnityEngine;

public class ContainerCounterAnimation : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";

    [SerializeField] private ContainerCounter containerCounter;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.OnPlayerCollectedObject += ContainerCounter_OnPlayerCollectedObject;
    }

    private void ContainerCounter_OnPlayerCollectedObject(object sender, System.EventArgs e)
    {
        anim.SetTrigger(OPEN_CLOSE);
    }
}
