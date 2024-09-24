using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{

    public GameObject settingsPanel;
    // Start is called before the first frame update
    void Start()
    {
        HideSettingsPanel();
        Time.timeScale = 1;
        //SceneController.Instance.ContinueGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
}
