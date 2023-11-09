using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{

    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private PlayerData m_PlayerData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = m_PlayerData.score.ToString();
        
    }
}
