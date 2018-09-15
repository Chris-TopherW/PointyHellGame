using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

    public SwordParentController swordParentController;

    public bool ParentIdle()
    {
        return swordParentController.IsIdle();
    }
}
