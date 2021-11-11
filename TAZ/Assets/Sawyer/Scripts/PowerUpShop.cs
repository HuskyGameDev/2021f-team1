using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpShop : MonoBehaviour
{

    public PowerUps powerUps;
    public GameObject player;
    public Canvas shopCanvas;
    public bool shopClosed = true;
    //public Canvas[] ItemCanvases = new Canvas[5];
    //public int[] shopItems = new int[3];
    public float range = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        SelectPowerUps();
        shopCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= range)
        {
            DisplayShop();
        }
        else if (Vector2.Distance(player.transform.position, transform.position) > range && !shopClosed)
        {
            CloseShop();
        }
    }

    public void SelectPowerUps() {
        int num = 0;
        for (int i = 0; i < 3; i++) {
            num = Random.Range(0, 4);
            switch (num)
            {
                case 0:
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = "Attack-Up";
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(1).GetComponent<Button>().onClick.AddListener(powerUps.AttackUp);
                    break;
                case 1:
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = "Speed-Up";
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(1).GetComponent<Button>().onClick.AddListener(powerUps.SpeedUp);
                    break;
                case 2:
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = "Health-Up";
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(1).GetComponent<Button>().onClick.AddListener(powerUps.HealthUp);
                    break;
                case 3:
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = "Extra Jump";
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(1).GetComponent<Button>().onClick.AddListener(powerUps.AdditionalJump);
                    break;
                case 4:
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = "Special Cooldown";
                    shopCanvas.gameObject.transform.GetChild(i).GetChild(1).GetComponent<Button>().onClick.AddListener(powerUps.SpecialCooldownReduction);
                    break;
            }

        }
    }

    public void DisplayShop() {
        shopClosed = false;
        shopCanvas.gameObject.SetActive(true);
    }

    public void CloseShop() {
        shopCanvas.gameObject.SetActive(false);
    }

    public void SoldPowerUp(int num) {
        shopCanvas.gameObject.transform.GetChild(num).gameObject.SetActive(false);
        shopCanvas.gameObject.transform.GetChild(num+3).gameObject.SetActive(true);
    }
}
