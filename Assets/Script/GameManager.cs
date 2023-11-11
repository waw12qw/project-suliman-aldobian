using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Slider heathSlider;
    public TextMeshProUGUI heathText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void UpdateHealthText(int currentHealth,int maxHealth){
        heathText.text = currentHealth+"/"+maxHealth.ToString();
        float newCurrentHeath =(float)currentHealth/maxHealth;
        heathSlider.value=newCurrentHeath;

    }
}
