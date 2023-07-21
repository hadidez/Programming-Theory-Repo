using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Player
{
    // INHERITANCE
    public Robot(string name,int age)
    {
        _mName = name;
        _age = age;
    }
    // Update is called once per frame
    void Update()
    {

    }

    // POLYMORPHISM
    //player moving ...
    public override void Move(Vector3 target)
    {
        base.Move(target);
        Debug.Log("Im Walking like a Robot");
    }

    // POLYMORPHISM
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
