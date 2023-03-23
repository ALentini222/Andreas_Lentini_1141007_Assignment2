using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnMouseDown(){
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
