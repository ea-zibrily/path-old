using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Weapon
{
    Fists =0,
    Weapon1,
    Weapon2
}

public class weaponSwapCommand : Command
{

    public weaponSwapCommand(KeyCode key) : base(key)
    {

    }

}