using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Player
{
    // INHERITANCE
    public Animal(string name,int age)
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
        Debug.Log("Im Walking like an Animal");
    }

    // POLYMORPHISM
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
