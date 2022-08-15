using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timerText;
    public float time = 0.0f;
    public bool doesDecrease = false;

    void Update()
    {
        if (doesDecrease)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                doesDecrease = false;
                GetComponent<GameManager>().GameEnd();
            }
        }

        timerText.text = "のこり: " + Mathf.Ceil(time);
    }

}
