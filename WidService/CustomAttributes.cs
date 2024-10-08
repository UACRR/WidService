using System;
using System.Collections.Generic;
using System.Text;

namespace WidServiceLib
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomSeqNrInFileAttribute : Attribute
    {
        private int seqNr;
        public int SeqNr { get { return seqNr; } }

        public CustomSeqNrInFileAttribute(int seqNr)
        {
            this.seqNr = seqNr;
        }
    }
}
