using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject card;
    List<int> cards = new List<int> {0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7};
    public static System.Random random = new System.Random();
    public int shuffle = 0;
    int[] visibleCards = {-1,-2};
    public int matches = 0;
    void Start()
    {
        int originalLength = cards.Count;
        float yPos = 3.5f;
        float xPos = -6f;
        for(int i = 0;i<16;i++){
            shuffle = random.Next(0, (cards.Count));
            var temp = Instantiate(card, new Vector3(xPos, yPos, 0), Quaternion.identity);
            temp.GetComponent<CardScript>().cardIndex = cards[shuffle];
            cards.Remove(cards[shuffle]);
            xPos = xPos + 4;
            if(i == 3){
                yPos = 1.2f;
                xPos = -6f;
            }
            if(i == 7){
                yPos = -1.2f;
                xPos = -6f;
            }
            if(i== 11){
                yPos = -3.5f;
                xPos = -6f;
            }
        }
    }

    public bool cardsFlipped(){
        bool cardsUp = false;
        if(visibleCards[0] >= 0 && visibleCards[1] >= 0)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleCards(int index)
    {
        if(visibleCards[0] == -1)
        {
            visibleCards[0] = index;
        }
        else if (visibleCards[1] == -2)
        {
            visibleCards[1] = index;
        }
    }
    public void RemoveVisibleCards(int index)
    {
        if (visibleCards[0] == index)
        {
            visibleCards[0] = -1;
        }
        else if (visibleCards[1] == index)
        {
            visibleCards[1] = -2;
        }
    }
    public bool CheckMatch()
    {
        if(visibleCards[0] == visibleCards[1])
        {
            visibleCards[0] = -1;
            visibleCards[1] = -2;
            matches++;
            return true;
        }
        return false;
    }    
    private void Awake(){
        card = GameObject.Find("Card");
    }
}
