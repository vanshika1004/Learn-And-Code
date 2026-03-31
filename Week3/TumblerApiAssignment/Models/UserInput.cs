using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumblerApiAssignment.Models
{
    /* Holds validated user input and derived values required
     to construct Tumblr API v1 pagination parameters.*/
    public class UserInput
    {
        public string BlogName { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int StartIndex { get; set; }
    }
}
