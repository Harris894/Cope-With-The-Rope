using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionSMB : StateMachineBehaviour
{
    public float m_Damping;
    public int controllerNumber;

    private readonly int m_HashHorizontalPara = Animator.StringToHash("Horizontal_f");
    private readonly int m_HashVerticalPara = Animator.StringToHash("Vertical_f");



    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
          float horizontal = Input.GetAxis(string.Format("Vertical{0}", controllerNumber));
          float vertical = Input.GetAxis(string.Format("Horizontal{0}", controllerNumber)); 

        //float horizontal = Input.GetAxis(string.Format("Left Stick X {0}", controllerNumber));
        //float vertical = Input.GetAxis(string.Format("Left Stick Y {0}", controllerNumber));

        Vector2 input = new Vector2(horizontal, vertical).normalized;

		animator.SetFloat(m_HashHorizontalPara, input.x, m_Damping, Time.deltaTime);
		animator.SetFloat(m_HashVerticalPara, input.y, m_Damping, Time.deltaTime);

        
    }
}
