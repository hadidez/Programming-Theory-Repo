using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Player
{
    public Robot(string name,int age)
    {
        _mName = name;
        _age = age;
    }
    // Update is called once per frame
    void Update()
    {

    }

    //player moving ...
    protected override void Move(Vector3 target)
    {
        base.Move(target);
        transform.localScale += Vector3.up * Time.deltaTime * 10f;
        Debug.Log("Im Walking like a Robot");
    }

    //player attacking ...
    protected override void Attack(GameObject target)
    {
        Debug.Log("I can Attack With My Eye's Ray...");
    }

    //player computing ...
    public void Compute()
    {
        Debug.Log("Im Computing , Its my Special ability");
    }


}
