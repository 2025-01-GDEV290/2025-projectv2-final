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

    public string sceneName = "BattleScene";  
   
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
            
            CutsceneComplete?.Invoke(); 
            LoadNextScene();  
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
                StartCoroutine(DisplayText(texts[index]));  
            }
        }
    }

    
    IEnumerator DisplayText(string message)
    {
        foreach (char letter in message.ToCharArray())
        {
            textUI.text += letter;
            yield return new WaitForSeconds(0.1f);  
        }
    }

    
    void LoadNextScene()
    {
        
        SceneManager.LoadScene(sceneName);
    }
}
