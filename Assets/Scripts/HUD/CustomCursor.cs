using System.Collections;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    //The texture that's going to replace the current cursor
    public Texture2D cursorTexture;

    //This variable flags whether the custom cursor is active or not
    public bool ccEnabled = false;

    private void Start()
    {
        SetCustomCursor();
    }

    private void OnDisable()
    {
        //Resets the cursor to the default
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void SetCustomCursor()
    {
        //Replace the 'cursorTexture' with the cursor
        Cursor.SetCursor(this.cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}