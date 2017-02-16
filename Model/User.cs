using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        private string id;
        private string username;
        private string cname;
        private string sname;
        private string mail;
        private List<string> clients;
        private string passwd;

        #region Properties

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Cname
        {
            get { return cname; }
            set { cname = value; }
        }

        public string Sname
        {
            get { return sname; }
            set { sname = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public List<string> Clients
        {
            get { return clients; }
            set { clients = value; }
        }

        public string Passwd
        {
            get { return passwd; }
            set { passwd = value; }
        }

        #endregion

        #region Constructors

        public User()
            : this(null, null, null, null, null, new List<string>(), null)
        {

        }

        public User(string id, string username, string cname, string sname, string mail, List<string> clients, string passwd)
        {
            this.id = id;
            this.username = username;
            this.cname = cname;
            this.sname = sname;
            this.mail = mail;
            this.clients = clients;
            this.passwd = passwd;
        }


        #endregion
    }
}
