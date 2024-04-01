using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
public class CutScenetyping : typingeffect
{
    public TMP_Text tmpText;
    public override string m_text { get; set; }
    public alphazero1 alpha;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        m_text = tmpText.text;
        StartCoroutine(_typing());
    }
    
    void Update()
    {
        StartCoroutine(changescene());
    }

    IEnumerator changescene()
    {
        yield return new WaitForSeconds(3.0f);
        alpha.Fadeone();
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(sceneName);
    }
}
