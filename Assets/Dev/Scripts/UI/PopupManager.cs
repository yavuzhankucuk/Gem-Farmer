using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel;

    public void OpenPopup()
    {
        popupPanel.SetActive(true);
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}
