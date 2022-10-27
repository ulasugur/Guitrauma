using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

public class ViewerAnimator : MonoBehaviour
{
    Animator animator;
    public GameplayController gc;
    int Boo2;
    int Cheer2;
    int Boo;
    int Cheer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Boo2 = Animator.StringToHash("Boo2");
        Cheer2 = Animator.StringToHash("Cheer2");
        Boo = Animator.StringToHash("Boo");
        Cheer = Animator.StringToHash("Cheer");
    }


    void Update()
    {
       /*/ if (gc.scoreCount >= -999)
        {         
            animator.SetBool(Cheer, true);
            animator.SetBool(Cheer2, true);
        }
        if (gc.scoreCount <= -1000)
        {
            animator.SetBool(Boo,true);
            animator.SetBool(Boo2,true);
        }/*/
        if(gc.isBooing==true)
        {
            animator.SetBool(Boo, true);
            animator.SetBool(Boo2, true);
        }
        if (gc.isCheering == true)
        {
            animator.SetBool(Cheer, true);
            animator.SetBool(Cheer2, true);
        }
    }
}
