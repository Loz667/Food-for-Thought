using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter counter;
    [SerializeField] private GameObject[] counterVisuals;

    private void Start()
    {
        PlayerInteraction.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, PlayerInteraction.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == counter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (GameObject countervisual in counterVisuals)
        {
            countervisual.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject countervisual in counterVisuals)
        {
            countervisual.SetActive(false);
        }
    }
}
