using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using VInspector;

#region Class Information

// Author: Frank Manford
// Description: Scriptable Object for holding pages of dialogue for textboxes to play.
// Last Updated: 3/01/2024

#endregion

[CreateAssetMenu]
public class TextBoxPage : ScriptableObject
{
    [Tab("Text")]
    [SerializeField][TextArea] string text;
    [SerializeField] TMP_FontAsset font;
    [SerializeField] int size = 32;
    [SerializeField] Color color = Color.white;
    [SerializeField] TextAlignmentOptions alignment;
    [SerializeField] bool textScroll = true;
    [SerializeField][Range(0, 1)] float scrollInterval = 0.1f;
    [SerializeField] string characterName = "name";

    [Tab("Image")]
    [SerializeField] Sprite portrait;
    [SerializeField] LayoutType layoutType = LayoutType.Default;
    [SerializeField] CharacterPosition characterPosition = CharacterPosition.Left;

    public string GetText()
    {
        return text;
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    public Sprite GetPortrait()
    {
        return portrait;
    }

    public LayoutType GetLayoutType()
    {
        return layoutType;
    }

    public CharacterPosition GetCharacterPosition()
    {
        return characterPosition;
    }

    public Color GetColor()
    {
        return color;
    }

    public int GetSize()
    {
        return size;
    }

    public TMP_FontAsset GetFont()
    {
        return font;
    }

    public TextAlignmentOptions GetAlignment()
    {
        return alignment;
    }

    public bool TextScroll()
    {
        return textScroll;
    }

    public float GetScrollInterval()
    {
        return scrollInterval;
    }
}

public enum LayoutType // What parts of the text box ui are enabled
{
    Default, Name, Portrait, Both
}

public enum CharacterPosition // Which side the portrait appears on
{
    Left, Right
}