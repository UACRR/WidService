using Microsoft.Data.SqlClient;
using SharedLib.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using WidServiceLib;

namespace WidServiceLib
{
    public class WidService
    {
        public delegate void ActionInProgress(double percentDone);
        
        public List<string> GetEntityNames()
        {
            return EntityInfo.GetEntityNames();
        }
    }
}
