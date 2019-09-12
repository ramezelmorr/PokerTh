using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CardStack))]


public class CardStackView : MonoBehaviour {


    CardStack deck;
    Dictionary<int, GameObject> fetchedCards;
    int lastCount;
    public Vector3 start;
    public GameObject cardPrefab;
    public float cardoffset;

     void Start()
    {
        fetchedCards = new Dictionary<int, GameObject>();
        deck = GetComponent<CardStack>();
        ShowCards();
        lastCount = deck.CardCount;


        deck.CardRemoved += deck_CardRemoved;
    }

    private void deck_CardRemoved(object sender, CardRemovedEventArgs e)
    {
        if (fetchedCards.ContainsKey(e.CardIndex))
        {
            Destroy(fetchedCards[e.CardIndex]);
            fetchedCards.Remove(e.CardIndex);
        }
    }

    

    void Update()
    {
       if (lastCount != deck.CardCount)
            { 
            lastCount = deck.CardCount;
            ShowCards();
            }
    }

    void ShowCards ()

    {
        int cardCount = 0;
        if(deck.HasCards) {
            foreach (int i in deck.GetCards())
            {
                float co = cardoffset * cardCount;
                Vector3 temp = start + new Vector3(co, 0f);
                AddCard(temp, i, cardCount);

                cardCount++;

            }   
        }


    }

    void AddCard(Vector3 position, int cardIndex, int positionalIndex)
    {
        if (fetchedCards.ContainsKey(cardIndex))
        {
            return;
        }
        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        cardCopy.transform.position = position;

        CardModul cardModel = cardCopy.GetComponent<CardModul>();



        cardModel.cardIndex = cardIndex;

        cardModel.ToggleFace(true);


        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 51 - positionalIndex;


        fetchedCards.Add(cardIndex, cardCopy);

    } 
}
