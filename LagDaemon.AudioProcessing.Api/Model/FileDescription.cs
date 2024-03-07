using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Model
{
    public class FileDescription
    {
        public string? Name
        {
            get; set;
        }
        public string? Path
        {
            get; set;
        }

        public string? Description
        {
            get; set;
        }

        public string? Type
        {
            get; set;
        }

        public FileDescription()
        {
        }


    }
}
