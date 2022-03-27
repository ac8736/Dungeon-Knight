using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouse : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D cursorTexture2;
    private void OnMouseOver() {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void OnMouseExit() {
        Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void OnDestroy() {
        Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.ForceSoftware);
    }
}
