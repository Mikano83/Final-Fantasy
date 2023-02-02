using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Fantasy
{
    public class Team
    {
        private Entity[] _teamcontent = new Entity[3];
        public Entity[] TeamContent { get { return _teamcontent; } set { _teamcontent = value; } }
    }
}
