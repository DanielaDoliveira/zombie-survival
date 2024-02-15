using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDead 
{
    public void TakeLife(int damage);
    void Dead();
}
