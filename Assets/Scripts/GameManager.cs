using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public static GameManager instance;
    public GameObject[] trunks;
    public List<GameObject> trunkList;


    private float trunkHigh = 2.43f;
    private float initialY = -3.63f;
    private int maxTrunks = 8;
    private bool clearTrunk = false;

    public Text points;
    public Text result;
    public Button tryAgain;
    private int actualyPoints = 0;

    private bool showDeathSound = true;


    public bool gameOver = false;

    void Awake(){

        if (instance == null) {

            instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        trunkList.Clear();
        InitTrunk();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            /* if (Input.GetButtonDown("Left") || Input.GetButtonDown("Right"))
             {

                 CortaTroncos();
                 ReposicionaTronco();
                 SomaPontos();

             }*/
            tryAgain.gameObject.SetActive(false);
            showDeathSound = true;

        }
        else {

            if (actualyPoints < 10)
            {
                result.text = "Really?";
            }
            else
            {
                result.text = "Good Job!";
            }
            tryAgain.gameObject.SetActive(true);
            if (showDeathSound) {
            
                Soundmanager.instance.playSound(Soundmanager.instance.death);
                showDeathSound = false;
            }
        }
	}


    void CreateTrunk(int position) {

        GameObject tronco = Instantiate(clearTrunk ? trunks[Random.Range(0, 3)] : trunks[0]);

        tronco.transform.localPosition = new Vector3(0f,initialY+position*trunkHigh,0f);
        trunkList.Add(tronco);

        clearTrunk = !clearTrunk;
    }

    void InitTrunk() {

        for (int posicao = 0; posicao < maxTrunks; posicao++) {
 
            CreateTrunk(posicao);
        }

    }


    void CutTrunk() {

        Destroy(trunkList[0]);
        trunkList.RemoveAt(0);
        Soundmanager.instance.playSound(Soundmanager.instance.cut);


    }

    void ReplaceTrunk() {


        for (int position = 0; position < trunkList.Count; position++){
            trunkList[position].transform.localPosition = new Vector3(0f, initialY + position * trunkHigh, 0f);
        }
        CreateTrunk(maxTrunks);


    }

    void SumPoints() {

        actualyPoints++;

        points.text = actualyPoints.ToString();

    }

    public void Toque() {

        if (!gameOver)
        {
            CutTrunk();
            ReplaceTrunk();
            SumPoints();
        }

    }
}
