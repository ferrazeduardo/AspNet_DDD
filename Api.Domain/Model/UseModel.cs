using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UseModel
    {
        private Guid _Id;

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _nome;

        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private DateTime? _CreateAt;

        public DateTime? CreateAt
        {
            get { return _CreateAt; }
            set {
                _CreateAt = value == null ? DateTime.UtcNow : value;
            }
        }

        private DateTime _updateAt;

        public DateTime updateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }


    }
}
