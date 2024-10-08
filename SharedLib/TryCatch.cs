using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib
{
    internal class TryCatch
    {
        public delegate void Try();
        public delegate void Catch(Exception ex);
        private static readonly bool _useTryCatch = true;
        public static void Run(Try tryBlock, Catch catchBlock)
        {
            if(_useTryCatch)
            {
                try
                {
                    tryBlock();
                }
                catch(Exception ex)
                {
                    catchBlock(ex);
                }
            }
            else
            {
                tryBlock();
            }
        }

        public static void RunT(Try tryBlock, Catch catchBlock)
        {
            if (_useTryCatch)
            {
                try
                {
                    tryBlock();
                }
                catch (Exception ex)
                {
                    catchBlock(ex);
                    throw;
                }
            }
            else
            {
                tryBlock();
            }
        }
    }
}
