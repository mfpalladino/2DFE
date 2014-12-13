using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TwoDFE
{
    public class SectorElementParametersDataGridView : DataGridView
    {
        public SectorElementParametersDataGridView()
        {
            SetStyle(ControlStyles.Selectable, false);
        }

        private List<KeyValuePair<string, string>> _clearParameters = new List<KeyValuePair<string, string>>();

        public void ClearParameters()
        {
            SetParameters(_clearParameters);
        }

        public void SetParameters(List<KeyValuePair<string, string>> parameters)
        {
            if (parameters == null)
                parameters = new List<KeyValuePair<string, string>>();

            if (parameters.Count < 10)
                for (int i = 1; i <= 10; i++)
                    parameters.Add(new KeyValuePair<string, string>());

            DataSource = ToBindingList<string, string>(parameters);
        }

        public List<KeyValuePair<string, string>> GetParameters()
        {
            var list = DataSource as DictionaryBindingList<string, string>;

            var result = new List<KeyValuePair<string, string>>(list.Count);
            foreach (var keyValuePair in list)
                result.Add(new KeyValuePair<string, string>(keyValuePair.Key, keyValuePair.Value));

            return result;
        }

        private DictionaryBindingList<TKey, TValue> ToBindingList<TKey, TValue>(List<KeyValuePair<TKey, TValue>> data)
        {
            return new DictionaryBindingList<TKey, TValue>(data);
        }
    }

    public sealed class Pair<TKey, TValue>
    {
        private TKey _key;
        private TValue _value;
        public Pair(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }
        public TKey Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public TValue Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    public class DictionaryBindingList<TKey, TValue>
        : System.ComponentModel.BindingList<Pair<TKey, TValue>>
    {
        private readonly List<KeyValuePair<TKey, TValue>> data;

        public DictionaryBindingList(List<KeyValuePair<TKey, TValue>> data)
        {
            this.data = data;
            Reset();
        }
        public void Reset()
        {
            bool oldRaise = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            try
            {
                Clear();
                foreach (KeyValuePair<TKey, TValue> key in data)
                    Add(new Pair<TKey, TValue>(key.Key, key.Value));
            }
            finally
            {
                RaiseListChangedEvents = oldRaise;
                ResetBindings();
            }
        }
    }
}
