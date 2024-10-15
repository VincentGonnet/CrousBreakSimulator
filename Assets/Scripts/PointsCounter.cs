using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text="0";

    }

    // Update is called once per frame
    public void UpdateScoreText()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.instance.getScore().ToString();
    }
}
