using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlidingText : MonoBehaviour
{
    public float scrollSpeed=20;
    public GameObject button;

    IEnumerator Text()  //  <-  its a standalone method
    {
        yield return new WaitForSeconds(2f);
          Vector3 pos = transform.position;
      Vector3 localVectorUp=transform.TransformDirection(0,1,0);
      pos += localVectorUp * scrollSpeed * Time.deltaTime;
      transform.position=pos; 
      yield return new WaitForSeconds(35f);
        button.gameObject.SetActive(true);

    }
    public void OnClick()
    {
      SceneManager.LoadScene("DifficultyScreen");
    }
    void Update()
    {
        StartCoroutine(Text()); 
    }
}
