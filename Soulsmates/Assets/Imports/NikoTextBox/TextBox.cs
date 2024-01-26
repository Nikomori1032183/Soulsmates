using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VInspector;
using TMPro;
using UnityEditor;
using Unity.Collections;

#region Class Information

// Author: Frank Manford
// Description: Class for holding information and methods for the the TextBox
// Last Updated: 09/01/2024

#endregion

public class TextBox : MonoBehaviour
{
    [Tab("Text")]
    [SerializeField] TMP_Text textBoxText, name1, name2;

    [Tab("Images")]
    [SerializeField] Image background, portrait1, portrait2;

    [Tab("Icon")]
    [SerializeField] bool icon;
    [SerializeField] Image iconImage;
    [SerializeField] Sprite confirmIcon, skipIcon, exitIcon;
    [SerializeField] bool iconBlink;
    [SerializeField][Range(0, 1)] float blinkInterval;
    bool currentlyBlinking;

    [Tab("Pages")]
    [SerializeField] string pageDirectory;
    List<TextBoxPage> pages = new List<TextBoxPage>();
    int currentPageIndex;
    bool currentlyScrolling;

    // Audio
    TextBoxAudio textBoxAudio;

    // Events
    public delegate void TextBoxDelegate();
    public static event TextBoxDelegate OnOpen;
    public static event TextBoxDelegate OnStartTextScroll;
    public static event TextBoxDelegate OnStopTextScroll;
    public static event TextBoxDelegate OnTextScroll;
    public static event TextBoxDelegate OnConfirm;
    public static event TextBoxDelegate OnExit;

    // Coroutines
    private Coroutine scrollCoroutine;
    private Coroutine blinkCoroutine;

    // Methods
    private void Start()
    {
        // ***CHANGE BELOW***
        // (CONFIRM_PRESS_EVENT_NAME) += ConfirmPress;

        textBoxAudio = GetComponent<TextBoxAudio>();

        currentPageIndex = 0;

        ResetActiveUI();

        // Loading of pages assets
        string[] guids;
        guids = AssetDatabase.FindAssets("t:TextBoxPage", new[] { pageDirectory });
        foreach (string guid in guids)
        {
            Debug.Log("TextBoxPage: " + AssetDatabase.GUIDToAssetPath(guid));
            TextBoxPage page = AssetDatabase.LoadAssetAtPath<TextBoxPage>(AssetDatabase.GUIDToAssetPath(guid));
            pages.Add(page);
        }

        OnOpen?.Invoke();

        LoadPage(pages[currentPageIndex]);
    }

    [Button]
    private void ConfirmPress()
    {
        if (currentlyScrolling)
        {
            StopTextScroll();
            DisplayText(pages[currentPageIndex].GetText());
        }

        else if (NotLastPage())
        {
            NextPage();
        }

        else
        {
            Close();
        }
    }

    private void NextPage()
    {
        currentPageIndex++;

        LoadPage(pages[currentPageIndex]);
    }

    private void Close()
    {
        Destroy(gameObject);
    }

    private void LoadPage(TextBoxPage page)
    {
        // Font
        textBoxText.font = page.GetFont();
        name1.font = page.GetFont();
        name2.font = page.GetFont();

        // Size
        textBoxText.fontSize = page.GetSize();
        name1.fontSize = page.GetSize();
        name2.fontSize = page.GetSize();

        // Color
        textBoxText.color = page.GetColor();

        // Name & Portrait Display
        if (page.GetCharacterPosition() == CharacterPosition.Left)
        {
            name1.text = page.GetCharacterName();
            portrait1.sprite = page.GetPortrait();
        }

        else
        {
            name2.text = page.GetCharacterName();
            portrait2.sprite = page.GetPortrait();
        }

        SetActiveUI(page.GetLayoutType(), page.GetCharacterPosition(), icon);

        if (page.TextScroll())
        {
            StartTextScroll(page.GetText(), page.GetScrollInterval());
        }

        else
        {
            DisplayText(page.GetText());
        }
    }

    private bool NotLastPage()
    {
        return currentPageIndex < pages.Count - 1;
    }

    private void DisplayText(string text)
    {
        textBoxText.text = text;
    }

    private void StartTextScroll(string text, float scrollInterval)
    {
        OnStartTextScroll?.Invoke();

        currentlyScrolling = true;

        SetIconType(IconType.Skip);
        StopIconBlink();

        scrollCoroutine = StartCoroutine(ScrollText(text, scrollInterval));
    }

    private IEnumerator ScrollText(string text, float scrollInterval)
    {
        Debug.Log("ScrollText");
        
        textBoxText.text = ""; // Set text box text to empty

        textBoxText.alpha = 0; // Make text box not visible

        string[] words = text.Split(" "); // Split page text into words

        List<string> processedText = new List<string>();
        int numLines = 1;

        foreach (string word in words) // For each word
        {
            
            textBoxText.text += word; // Add word and a space to text

            yield return new WaitForEndOfFrame();

            if (textBoxText.textInfo.lineCount > numLines) // If number of lines increases, add a "next line"
            {
                numLines++;
                processedText.Add("\n");
            }

            processedText.Add(word);

            textBoxText.text += " ";
            processedText.Add(" ");
        }

        textBoxText.text = ""; // Reset text box text to empty

        textBoxText.alpha = 1; // Make text box visible

        foreach (string word in processedText) // For each processed word
        {
            switch (word)
            {
                case "\n": // New line
                    textBoxText.text += word;
                    break;

                case " ": // Space
                    textBoxText.text += word;
                    break;

                default: // Word
                    foreach (char character in word) // For each character
                    {

                        textBoxText.text += character; // Display the character

                        OnTextScroll?.Invoke();
  
                        yield return new WaitForSeconds(scrollInterval); // Wait for x seconds
                    }
                    break;
            }
        }

        currentlyScrolling = false;
        OnStopTextScroll?.Invoke();

        SelectIconType();
        StartIconBlink();
    }

    private void StopTextScroll()
    {
        StopCoroutine(scrollCoroutine);
        currentlyScrolling = false;

        StartIconBlink();

        OnStopTextScroll?.Invoke();
    }

    private void SetActiveUI(LayoutType layoutType, CharacterPosition characterPosition, bool icon) // Set what UI elements are enabled
    {
        ResetActiveUI();

        switch (layoutType)
        {
            case LayoutType.Default: // Do Nothing

                break;

            case LayoutType.Name: // Enable Name

                if (characterPosition ==  CharacterPosition.Left)
                {
                    name1.gameObject.SetActive(true);
                }

                else
                {
                    name2.gameObject.SetActive(true);
                }

                break;

            case LayoutType.Portrait: // Enable Portrait

                if (characterPosition == CharacterPosition.Left)
                {
                    portrait1.gameObject.SetActive(true);
                }

                else
                {
                    portrait2.gameObject.SetActive(true);
                }

                break;

            case LayoutType.Both: // Enable Name & Portrait

                if (characterPosition == CharacterPosition.Left)
                {
                    name1.gameObject.SetActive(true);
                    portrait1.gameObject.SetActive(true);
                }

                else
                {
                    name2.gameObject.SetActive(true);
                    portrait2.gameObject.SetActive(true);
                }

                break;
        }

        SelectIconType(); // Icon
    }

    private void SelectIconType() // Select icon to display
    {
        if (icon)
        {
            iconImage.gameObject.SetActive(true);

            if (NotLastPage())
            {
                SetIconType(IconType.Confirm);
            }

            else
            {
                SetIconType(IconType.Exit);
            }
        }

        else
        {
            SetIconType(IconType.None);
        }
    }

    private void ResetActiveUI()
    {
        textBoxText.gameObject.SetActive(true);
        background.gameObject.SetActive(true);

        name1.gameObject.SetActive(false);
        name2.gameObject.SetActive(false);
        portrait1.gameObject.SetActive(false);
        portrait2.gameObject.SetActive(false);

        iconImage.gameObject.SetActive(false);
    }

    private void SetIconType(IconType iconType)
    {
        switch (iconType)
        {
            case IconType.None:
                iconImage.gameObject.SetActive(false);
                break;

            case IconType.Confirm:
                iconImage.sprite = confirmIcon;
                break;

            case IconType.Skip:
                iconImage.sprite = skipIcon;
                break;

            case IconType.Exit:
                iconImage.sprite = exitIcon;
                break;
        }
    }

    private void StartIconBlink()
    {
        if (iconBlink)
        {
            currentlyBlinking = true;
            blinkCoroutine = StartCoroutine(IconBlink());
        }
    }

    private IEnumerator IconBlink() // Make icon blink
    {
        while (currentlyBlinking)
        {
            if (iconImage.gameObject.activeSelf)
            {
                iconImage.gameObject.SetActive(false);
            }

            else
            {
                iconImage.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void StopIconBlink()
    {
        currentlyBlinking = false;
        iconImage.gameObject.SetActive(true);

        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
        }
    }

    public enum IconType // Different types of icons
    {
        None, Confirm, Exit, Skip
    }
}