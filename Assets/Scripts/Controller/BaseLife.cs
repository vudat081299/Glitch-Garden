using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLife : MonoBehaviour
{
    [SerializeField] float baselife = 3f;
    float life;
    [SerializeField] int damage = 1;
    Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        life = baselife - PlayerPrefController.GetDif();
        
        lifeText = GetComponent<Text>();
        lifeText.text = life.ToString();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update star TextField Display
    private void UpdateDisplay()
    {
        lifeText.text = life.ToString();
    }

    // Decrease life
    public void DecreaseLife()
    {
        life -= damage;
        UpdateDisplay();

        // check life
        if (life <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
