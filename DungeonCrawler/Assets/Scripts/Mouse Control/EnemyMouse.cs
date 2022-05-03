using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouse : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D cursorTexture2;
    Vector2 cursorHotspot;
    private void OnMouseOver()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        cursorHotspot = new Vector2(cursorTexture2.width / 2, cursorTexture2.height / 2);
        Cursor.SetCursor(cursorTexture2, cursorHotspot, CursorMode.Auto);
    }
    private void OnDestroy()
    {
        cursorHotspot = new Vector2(cursorTexture2.width / 2, cursorTexture2.height / 2);
        Cursor.SetCursor(cursorTexture2, cursorHotspot, CursorMode.Auto);
    }
}
