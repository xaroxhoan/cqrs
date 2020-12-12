 
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Response
    {
        public bool Status { get; set; }
        public string Message { get; set; }

    }
    public class Response<T> : Response
    {

        public T Data  { get; set; }

    }


}



