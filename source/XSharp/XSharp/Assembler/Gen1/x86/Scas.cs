﻿using System;

namespace XSharp.Assembler.x86
{
    [XSharp.Assembler.OpCode("scas")]
    public class Scas: InstructionWithSize, IInstructionWithPrefix
    {
        public InstructionPrefixes Prefixes
        {
            get;
            set;
        }

        public override void WriteText(XSharp.Assembler.Assembler aAssembler, System.IO.TextWriter aOutput)
        {
            if ((Prefixes & InstructionPrefixes.RepeatTillEqual) != 0)
            {
                aOutput.Write("repne ");
            }
            switch (Size)
            {
                case 32:
                    aOutput.Write("scasd");
                    return;
                case 16:
                    aOutput.Write("scasw");
                    return;
                case 8:
                    aOutput.Write("scasb");
                    return;
                default: throw new Exception("Size not supported!");
            }
        }
    }
}
