using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xml.Linq;

namespace Morpho.Envimet.Handlers
{
    public class MorphoConnection: INotifyPropertyChanged
    {
        private string _schema;
        private string _values;
        public string _data;

        public event PropertyChangedEventHandler PropertyChanged;

        public MorphoConnection(string schema, 
            string values)
        {
            _schema = schema;
            _values = values;
        }

        public string GetSchema()
        {
            return _schema;
        }

        public string GetValues()
        {
            return _values;
        }

        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SaveData(string input)
        {
            Data = input;
        }
    }
}
