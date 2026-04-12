using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using XiaWorld;
using System.Reflection.Emit;


namespace iguana_acs_fix
{


    class iguana_TributeRework
    {
        [HarmonyPatch(typeof(GameEventMgr), "CheckSchoolEvent")]
        public static class iguana_TributeRework_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                foreach (CodeInstruction codeInstruction in instructions)
                {
                    if (codeInstruction.opcode.Name == "ldc.i4" && codeInstruction.operand.ToString() == "1000")
                    {
                        int newvalue = 5000;
                        codeInstruction.operand = newvalue;
                    }
                }
                return instructions;
            }
        }
    }
}
