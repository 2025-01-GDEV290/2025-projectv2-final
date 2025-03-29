using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public Image backgroundImage;
    public TMP_Text textUI;
    public Sprite[] backgrounds;
    public string[] texts;
    private int index = 0;
    public Button rightArrowButton;

    public string sceneName = "GameScene";

    public delegate void OnCutsceneComplete();
    public event OnCutsceneComplete CutsceneComplete;

    void Start()
    {
        rightArrowButton.onClick.AddListener(ChangeBackground);
        UpdateBackgroundAndText();
    }

    void ChangeBackground()
    {
        if (index < backgrounds.Length - 1)
        {
            index++;
            UpdateBackgroundAndText();
        }
        else
        {
            rightArrowButton.gameObject.SetActive(false);  // Disable the button
            CutsceneComplete?.Invoke();
            StartCoroutine(DelaySceneLoad());  // Start coroutine for delayed scene load
        }
    }

    void UpdateBackgroundAndText()
    {
        if (index >= 0 && index < backgrounds.Length)
        {
            backgroundImage.sprite = backgrounds[index];

            if (index < texts.Length)
            {
                textUI.text = "";
                // Disable the button while the text is generating
                rightArrowButton.interactable = false;
                StartCoroutine(DisplayText(texts[index]));
            }
            else
            {
                textUI.text = "";  // Optional: display a fallback message if needed
            }
        }
    }

    IEnumerator DisplayText(string message)
    {
        foreach (char letter in message.ToCharArray())
        {
            textUI.text += letter;
            yield return new WaitForSeconds(0.03f);  // Typing speed
        }

        // Enable the button once the text generation is complete
        rightArrowButton.interactable = true;
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(1f);  // Optional delay before scene change
        LoadNextScene();
    }
}
