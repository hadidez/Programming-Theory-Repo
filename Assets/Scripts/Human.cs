using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Player
{
    public Human(string name,int age)
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
        Debug.Log("Im Moving Like a Human!");
    }

    //player attacking ...
    protected override void Attack(GameObject target)
    {
        Debug.Log("I Can Attack with My Hands");
    }

    //player building ...
    public void Build()
    {
        Debug.Log("I Can Build Some Buildings, Its my Special ability");
    }

    

  
}
