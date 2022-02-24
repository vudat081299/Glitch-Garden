using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int star = 100;
    Text starText;
    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update star TextField Display
    private void UpdateDisplay()
    {
        starText.text = star.ToString();
    }

    public bool HaveEnoughStar(int amount)
    {
        return star >= amount;
    }
    
    public void AddStars(int among)
    {
        star += among;
        UpdateDisplay();
    }

    public void SpendStars(int among)
    {
        if (star >= among)
        {
            star -= among;
            UpdateDisplay();
        }
    }
}
