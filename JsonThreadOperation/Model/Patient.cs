using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace JsonThreadOperation.Model
{
    public class Patient
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public long MobileNumber { get; set; }
            public string Email { get; set; }
            public string Location { get; set; }
            public string Address { get; set; }
        
    }
}
