using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger2 : MonoBehaviour {

    public Texture2D cursor;

	// Use this for initialization
	void Start () {
        Cursor.SetCursor(cursor, new Vector2(0, 0), CursorMode.Auto);
	}
}
