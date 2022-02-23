using System.Collections.Generic;
using UnityEngine;

public class InputTabChangeGroup : MonoBehaviour
{
   public List<InputNavigator> m_Inputs;
   void Start()
   {
      if (m_Inputs != null)
      {
         for (var i = 0; i < m_Inputs.Count; i++)
         {
            var input = m_Inputs[i];
            input.group = this;
         }
      }
   }
   public void Change2NextInputField(InputNavigator input)
   {
      if (m_Inputs != null)
      {
         var curindex = m_Inputs.IndexOf(input);
         var count = m_Inputs.Count;
         curindex = (curindex + 1) % count;
         var nextInput = m_Inputs[curindex];
         nextInput.SetSelect();
      }
   }
}
