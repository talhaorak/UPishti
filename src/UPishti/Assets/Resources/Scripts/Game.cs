using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    GameObject cardBP;
    Light mainLight;
    List<Card> cards = new List<Card>();
    enum State
    {
        None,
        Menu,
        Playing
    }
    State currentState = State.None;
    State previousState = State.None;
    
    void Awake()
    {
        cardBP = Resources.Load<GameObject>("Prefabs/CardBP");
        mainLight = GameObject.Find("MainLight").GetComponent<Light>();
        int a = 0;
    }

	void Start ()
    {
        SetGameMode(State.Menu);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {        
        if(GUI.Button(new Rect(Screen.width/2 - 100, 100, 200, 50), "Start Game"))
        {
            SetGameMode(State.Playing);
        }
    }

    void SetGameMode(State st)
    {
        previousState = currentState;
        currentState = st;
        if (previousState != currentState)
        {
            switch (currentState)
            {
                case State.Menu:
                    EndGame();
                    break;
                case State.Playing:
                    BeginGame();
                    break;
            }
        }
    }

    void BeginGame()
    {
        mainLight.enabled = true;
        mainLight.intensity = 1;
        Camera.main.clearFlags = CameraClearFlags.Skybox;

        for (int shape = 0; shape < 4; shape++)
        {
            for (int number = 0; number < 13; number++)
            {
                Vector3 pos = new Vector3(number * 7.77f, shape * 11, 1);
                Card newCard = (Instantiate(cardBP, pos, Quaternion.Euler(-90, 0, 0)) as GameObject).GetComponent<Card>();
                newCard.SetCard(shape, number);
                cards.Add(newCard);
            }
        }
    }

    void EndGame()
    {
        mainLight.enabled = false;
        mainLight.intensity = 0.1f;
        Camera.main.clearFlags = CameraClearFlags.Color;
        foreach (Card card in cards) Destroy(card.gameObject);
        cards.Clear();
    }
}
