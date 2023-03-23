using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardScript : MonoBehaviour
{
    GameObject gameController;
    SpriteRenderer spriteRenderer;
    public Sprite[] front;
    public int cardIndex;
    public Sprite back;
    public bool match = false;

    public void OnMouseDown(){
        flipCards();
        if(gameController.GetComponent<GameController>().matches == 8){
            gameOver();
        }
    }
     private void Awake()
    {
        gameController = GameObject.Find("GameController");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void flipCards(){
    if (match == false){
            if (spriteRenderer.sprite == back)
            {
                if (gameController.GetComponent<GameController>().cardsFlipped() == false)
                {
                    spriteRenderer.sprite = front[cardIndex];
                    gameController.GetComponent<GameController>().AddVisibleCards(cardIndex);
                    match = gameController.GetComponent<GameController>().CheckMatch();
                }
            }
        
            else
            {
                spriteRenderer.sprite = back;
                gameController.GetComponent<GameController>().RemoveVisibleCards(cardIndex);
            }
        }
    }
    public void gameOver(){
        SceneManager.LoadScene("GameOver");
    }
}

