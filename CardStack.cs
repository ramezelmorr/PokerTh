using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{

    List<int> cards;

    public bool isGameDeck;

    public bool createDeck;


    public bool HasCards
    {

        get { return cards != null && cards.Count > 0; }

    }

    public event CardRemovedEventHandler CardRemoved;




 public int CardCount
    {

        get
        {

            if (cards == null)
            {
                return 0;
               }
                 else
                     {

                      return cards.Count;
                        }
                             }
                                  }
    public IEnumerable<int> GetCards()

    {
        foreach (int i in cards)
        {
            yield return i;
        }



    }
    public int Pop()               /*So temp is 0 index in array,
                                   we remove that item from cards array
                                   then we fire a msg to any sub that i removed the card
                                   then we return temp
        
        
        
                                    */
    {
        int temp = cards[0];
        cards.RemoveAt(0);

        if (CardRemoved != null)
        {

            CardRemoved(this, new CardRemovedEventArgs(temp));
        }


        return temp;


    }

    public void Push(int card)
    {
        cards.Add(card);


    }
    public void CreateDeck()

    {



        for (int i = 0; i < 52; i++)
        {

            cards.Add(i);


        }

        int n = cards.Count;
        while (n > 1)
        {


            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }


    }
    void Start()

    {

        cards = new List<int>();

        if (isGameDeck)
        {
            CreateDeck();
        }
    }


}
	

