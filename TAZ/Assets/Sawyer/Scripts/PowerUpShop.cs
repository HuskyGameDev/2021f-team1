using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShop : MonoBehaviour
{

    public PowerUps powerUps;
    public GameObject player;
    public Canvas shopCanvas;
    public bool shopClosed = true;
    public Canvas[] ItemCanvases = new Canvas[5];
    public int[] shopItems = new int[3];
    public float range = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        SelectPowerUps();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= range)
        {
            DisplayShop();
        }
        else if(Vector2.Distance(player.transform.position, transform.position) > range && !shopClosed)
        {
            CloseShop();
        }
    }

    public void SelectPowerUps() {
        for (int i = 0; i < 3; i++) {
            shopItems[i] = Random.Range(0, 4);
        }
    }

    public void DisplayShop() {
        shopClosed = false;
        shopCanvas.gameObject.SetActive(true);
    }

    public void CloseShop() {
        shopCanvas.gameObject.SetActive(false);
    }
}
