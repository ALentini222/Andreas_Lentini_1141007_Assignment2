using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TryAgainButton : MonoBehaviour
{
    public void OnMouseDown(){
        SceneManager.LoadScene("GameScene");
    }
}
