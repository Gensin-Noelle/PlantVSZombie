using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    public GameObject inputPanel;
    public GameObject tipsPanel;
    public GameObject helpPanel;
    public GameObject settingsPanel;
    public TMP_InputField usernameInput;
    public TextMeshProUGUI nameText;

    private void Start()
    {
        inputPanel.SetActive(false);
        tipsPanel.SetActive(false);
        helpPanel.SetActive(false);
        settingsPanel.SetActive(false);
        UpdateNameUI();
    }
    public void OnChangeNameButtonClick()
    {
        usernameInput.text = PlayerPrefs.GetString("username", "Enter Account...");
        inputPanel.SetActive(true);
        AudioManager.Instance.PlayClip(Config.button_click);
    }

    public void OnSubmitButtonClick()
    {
        PlayerPrefs.SetString("username", usernameInput.text);//保存用户名
        inputPanel.SetActive(false);
        UpdateNameUI();
        AudioManager.Instance.PlayClip(Config.button_click);
    }

    void UpdateNameUI()
    {
        nameText.text = PlayerPrefs.GetString("username", "welcome");
    }

    public void OnAdventureButtonClick()
    {
        AudioManager.Instance.PlayClip(Config.button_click);
        SceneManager.LoadScene("Scene1");
    }

    public void OnPuzzleModeButtonClick()
    {
        AudioManager.Instance.PlayClip(Config.button_click);
        SceneManager.LoadScene("PuzzleMode1");
    }

    public void DisplayTipsPanel()
    {
        AudioManager.Instance.PlayClip(Config.button_click);
        tipsPanel.SetActive(true);
    }

    public void DisplaySettingsPanel()
    {
        settingsPanel.SetActive(true);
        AudioManager.Instance.PlayClip(Config.button_click);
    }

    public void OnConfirmButtonClick()
    {
        AudioManager.Instance.PlayClip(Config.button_click);
        tipsPanel.SetActive(false);
        helpPanel.SetActive(false);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlayClip(Config.button_click);
        Application.Quit();
    }

    public void OnHelpButtonClick()
    {
        AudioManager.Instance.PlayClip(Config.button_click);
        helpPanel.SetActive(true);
    }
}
