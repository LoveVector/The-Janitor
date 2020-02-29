using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurrenderNode : Node
{
<<<<<<< HEAD
    
=======
    public override int UpdateNode(EnemyAbstract con)
    {
        if (con.surrender == false)
        {
            Debug.Log("This");
            con.surrender = true;
            con.anim.SetTrigger("Surrender");
            return 2;
        }
        else
        {
            return 2;
        }
    }
>>>>>>> CoolerKyleBranch
}
