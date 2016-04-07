using System.Collections;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    //The texture that's going to replace the current cursor
    public Texture2D cursorTexture;

    private Vector2 cursorHotspot;

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
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        //Replace the 'cursorTexture' with the cursor
        Cursor.SetCursor(this.cursorTexture, cursorHotspot, CursorMode.Auto);
    }
}