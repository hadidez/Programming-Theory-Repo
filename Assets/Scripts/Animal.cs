using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Player
{
    public Animal(string name,int age)
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
        Debug.Log("Im Walking like an Animal");
    }

    //player attacking ...
    protected override void Attack(GameObject target)
    {
        Debug.Log("I have Strong Teeth, I Can Bite Every things");
    }

    //player searching ...
    public void Search()
    {
        Debug.Log("I Can search For Everything, Its My Special Ability");
    }
   
    
}
