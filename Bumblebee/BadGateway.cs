﻿using BeetleX.Buffers;
using BeetleX.FastHttpApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bumblebee
{
    public class BadGateway : InnerErrorResult
    {
        public BadGateway(string errormsg) : base("502", "Bad Gateway", new Exception(errormsg), false)
        {

        }

        public override string ContentType => "text/html; charset=utf-8";

        public BadGateway(Exception error) : base("502", "Bad Gateway", error, false)
        {

        }

        public override void Write(PipeStream stream, HttpResponse response)
        {
            stream.WriteLine("<html>");
            stream.WriteLine("<body>");
            stream.Write("<h1>");
            stream.WriteLine(Message);
            stream.Write("</h1>");
            if (!string.IsNullOrEmpty(Error))
            {
                stream.Write("<p>");
                stream.WriteLine(Error);
                stream.Write("</p>");
            }
            if (!string.IsNullOrEmpty(SourceCode))
            {
                stream.Write("<p>");
                stream.WriteLine(SourceCode);
                stream.Write("</p>");
            }
            
            stream.WriteLine("  <hr style=\"margin: 0px; \" /> <p>Bumblebee webapi gateway (<a href=\"https://github.com/ikende\" target=\"_blank\">github.com</a>)</p>");
            stream.WriteLine("<body>");
            stream.WriteLine("</html>");
        }

    }
}
