using Common.Sie;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Core.Logic
{
    public class SieFileImportManager 
    {
        public int ProcessSieStream(StreamReader stream)
        {
            SieDocument sd = new SieDocument();
            sd.ReadStreamDocument(stream);
            return 0;
        }

    }
}